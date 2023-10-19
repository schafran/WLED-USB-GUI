using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WLED_GUI;

internal class MyApplicationContext : ApplicationContext
{
    readonly NotifyIcon notifyIcon = new();
    readonly Form1 controlWindow = new();

    public MyApplicationContext()
    {
        ToolStripMenuItem configMenuItem = new("Configuration", null, new EventHandler(ShowConfig));
        ToolStripMenuItem exitMenuItem = new ("Exit", null, new EventHandler(Exit));
        
        ContextMenuStrip contextMenuStrip = new();
        contextMenuStrip.Items.Add(configMenuItem);
        contextMenuStrip.Items.Add(new ToolStripSeparator());
        contextMenuStrip.Items.Add(exitMenuItem);

        //notifyIcon.Icon = Properties.Resources.AppIcon;
        notifyIcon.Text = "WLED GUI";
        notifyIcon.Icon = Icon.ExtractAssociatedIcon(Assembly.GetCallingAssembly().Location);
        notifyIcon.ContextMenuStrip = contextMenuStrip;
        notifyIcon.Visible = true;
    }

    void ShowConfig(object? sender, EventArgs e)
    {
        // If we are already showing the window, merely focus it.
        if (controlWindow.Visible)
        {
            controlWindow.Activate();
        }
        else
        {
            controlWindow.ShowDialog();
        }
    }

    void Exit(object? sender, EventArgs e)
    {
        // We must manually tidy up and remove the icon before we exit.
        // Otherwise it will be left behind until the user mouses over.
        notifyIcon.Visible = false;
        Application.Exit();
    }


}
