using System;
using System.Collections.Concurrent;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using MQCoordinator.Plugins.Interfaces;

namespace MQCoordinator
{
    public static class PluginManager
    {
        private static readonly Lazy<ConcurrentDictionary<string, Type>> _loadedPlugins = new Lazy<ConcurrentDictionary<string, Type>>(() => new ConcurrentDictionary<string, Type>());
        public static ConcurrentDictionary<string, Type> LoadedPlugins => _loadedPlugins.Value;

        public static void LoadAllPlugins()
        {
            //Expects plugins to be nested in subfolders in a directory under the current folder. e.g. C:\App\bin\Plugins\
            var pluginDirs = Directory.GetDirectories(Path.Combine(Directory.GetCurrentDirectory(), ConfigurationManager.AppSettings["PluginFolder"]));
            foreach (var pluginDir in pluginDirs)
            {
                var pluginFolderName = new DirectoryInfo(pluginDir).Name;
                Type type;
                if (TryLoadSpecificPlugin(pluginFolderName, out type))
                {
                    LoadedPlugins.AddOrUpdate(pluginFolderName, type, (key, oldValue) => type);
                }
            }
        }

        public static bool TryLoadSpecificPlugin(string pluginName, out Type pluginType)
        {
            pluginType = null;
            try
            {
                //Expects plugins to be nested in subfolders in a directory under the current folder. e.g. C:\App\bin\Plugins\Kbb.
                //Kbb would be the plugin name passed in in this scenario
                var pluginDir = Path.Combine(Directory.GetCurrentDirectory(), ConfigurationManager.AppSettings["PluginFolder"], pluginName);

                //.plug is just a rename of the .dll to differentiate between the plugin dll and the dependency dlls to simplify the loading process (not going through all the types of dependent libraries reduces significant effort)
                var pluginPath = Directory.GetFiles(pluginDir, "*.plug").SingleOrDefault();
                if (pluginPath == null) { return false; }

                //LoadFrom is an implicit load with any depenencies you find in the folder with the dll
                var pluginAssembly = Assembly.LoadFrom(pluginPath);
                pluginType = pluginAssembly.GetTypes().SingleOrDefault(x => x.GetInterface(typeof(IMessageDispatchPlugin).Name, false) != null);
                
                var dependencyPaths = Directory.GetFiles(pluginDir, "*.dll");
                foreach (var dependencyPath in dependencyPaths)
                {
                    var assembly = Assembly.LoadFrom(dependencyPath);
                    var types = assembly.GetTypes();
                    Console.WriteLine(types.Count());
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return pluginType != null;
        }

        public static IMessageDispatchPlugin GetPluginInstance(string pluginName)
        {
            Type type;
            if (!LoadedPlugins.TryGetValue(pluginName, out type)) { return null; }

            //Could load these into a static dictionary if we didn't need instance members of the plugin created each time (e.g. like IoC Singletons or something)
            var ctor = type.GetConstructor(new Type[] { });
            var pluginInstance = (IMessageDispatchPlugin)ctor?.Invoke(new object[] { });

            return pluginInstance;
        }

        public static void HandleMessageForLoadedPlugins(ExampleMessage message)
        {
            foreach (var loadedPluginEntry in LoadedPlugins.Keys)
            {
                var plugin = GetPluginInstance(loadedPluginEntry);
                plugin.HandleMessage(message); //Could async this if needed
            }
        }
    }
}
