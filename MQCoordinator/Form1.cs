using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using MQCoordinator.Plugins.Interfaces;

namespace MQCoordinator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ux_LoadAndRun_Click(object sender, EventArgs e)
        {
            var pluginDirs = Directory.GetDirectories(Directory.GetCurrentDirectory());
            foreach (var pluginDir in pluginDirs)
            {
                var pluginPaths = Directory.GetFiles(pluginDir, "*.plug");
                foreach (var pluginPath in pluginPaths)
                {
                    var pluginAssembly = Assembly.LoadFrom(pluginPath);
                    var types = pluginAssembly.GetTypes();
                    foreach (var type in types)
                    {
                        if (type.GetInterface(typeof(IMessageDispatchPlugin).Name, false) == null) continue;

                        var ctor = type.GetConstructor(new Type[] { });
                        var pluginInstance = (IMessageDispatchPlugin)ctor?.Invoke(new object[] { });
                        pluginInstance?.HandleMessage(new ExampleMessage { BodyText = "Here's a Test" });
                    }
                }
            }
        }
    }
}
