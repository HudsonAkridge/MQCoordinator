using System;
using System.Windows.Forms;
using MQCoordinator.Messaging;

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
            PluginManager.LoadAllPlugins();
        }

        private void ux_RunPlugin_Click(object sender, EventArgs e)
        {
            var pluginName = ux_pluginName.Text;
            var plugin = PluginManager.GetPluginInstance(pluginName);
            plugin.HandleMessage(new KbbMessage("Sarasota, Florida"));
        }
    }
}
