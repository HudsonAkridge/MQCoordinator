﻿using System;
using System.Linq;
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
            ux_ListOfPlugins.Items.AddRange(PluginManager.LoadedPlugins.Select(x => x.Key).ToArray());
        }

        private void ux_RunPlugin_Click(object sender, EventArgs e)
        {
            var pluginName = ux_ListOfPlugins.Text;
            var plugin = PluginManager.GetPluginInstance(pluginName);
            plugin.HandleMessage(new KbbMessage("Sarasota, Florida"));
        }
    }
}
