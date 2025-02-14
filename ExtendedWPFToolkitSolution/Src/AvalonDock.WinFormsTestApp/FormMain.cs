﻿/************************************************************************

   AvalonDock

   Copyright (C) 2007-2013 Xceed Software Inc.

   This program is provided to you under the terms of the New BSD
   License (BSD) as published at http://avalondock.codeplex.com/license 

   For more features, controls, and fast professional support,
   pick up AvalonDock in Extended WPF Toolkit Plus at http://xceed.com/wpf_toolkit

   Stay informed: follow @datagrid on Twitter or Like facebook.com/datagrids

  **********************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Xceed.Wpf.AvalonDock.Layout;
using Xceed.Wpf.AvalonDock.Layout.Serialization;
using Xceed.Wpf.AvalonDock;

namespace AvalonDock.WinFormsTestApp
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();


        }


        DockingManager _dockingManager = new DockingManager();
        protected override void OnLoad(EventArgs e)
        {
            XmlLayoutSerializer serializer = new XmlLayoutSerializer(_dockingManager);

            serializer.LayoutSerializationCallback += (s, args) =>
                {
                    switch (args.Model.ContentId)
                    {
                        case "toolWindow1":
                            args.Content = new System.Windows.Controls.TextBlock() { Text = args.Model.ContentId };
                            break;
                        default:
                            args.Content = new System.Windows.Controls.TextBox() { Text = args.Model.ContentId };
                            break;
                    }

                };

            serializer.Deserialize(
                new System.IO.StringReader(
                AvalonDock.WinFormsTestApp.Properties.Settings.Default.DefaultLayout));


            //LayoutDocument doc = new LayoutDocument() { Title = "test" };
            //dockingManager.Layout.Descendents().OfType<LayoutDocumentPane>().First().Children.Add(doc);

            dockingManagerHost.Child = _dockingManager;

            base.OnLoad(e);
        }


        private void menuItemAero_Click(object sender, EventArgs e)
        {
          _dockingManager.Theme = new Xceed.Wpf.AvalonDock.Themes.AeroTheme();
          this.SetChecked( menuItemAero );
        }

        private void menuItemVS2010_Click(object sender, EventArgs e)
        {
          _dockingManager.Theme = new Xceed.Wpf.AvalonDock.Themes.VS2010Theme();
          this.SetChecked( menuItemVS2010 );
        }

        private void menuItemMetro_Click( object sender, EventArgs e )
        {
          _dockingManager.Theme = new Xceed.Wpf.AvalonDock.Themes.MetroTheme();
          this.SetChecked( menuItemMetro );
        }

        private void menuItemGeneric_Click(object sender, EventArgs e)
        {
            _dockingManager.Theme = new Xceed.Wpf.AvalonDock.Themes.GenericTheme();
            this.SetChecked( menuItemGeneric );
        }

        private void menuItemExpressionDark_Click( object sender, EventArgs e )
        {
          _dockingManager.Theme = new Xceed.Wpf.AvalonDock.Themes.GenericTheme();
          this.SetChecked( menuItemExpressionDark );
        }

        private void menuItemExpressionLight_Click( object sender, EventArgs e )
        {
          _dockingManager.Theme = new Xceed.Wpf.AvalonDock.Themes.GenericTheme();
          this.SetChecked( menuItemExpressionLight );
        }

        private void SetChecked( ToolStripMenuItem toCheck )
        {
          menuItemAero.Checked = false;
          menuItemGeneric.Checked = false;
          menuItemVS2010.Checked = false;
          menuItemExpressionDark.Checked = false;
          menuItemMetro.Checked = false;

          toCheck.Checked = true;
        }


    }
}
