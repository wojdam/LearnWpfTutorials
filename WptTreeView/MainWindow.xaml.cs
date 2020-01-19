using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace WptTreeView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach(var drive in Directory.GetLogicalDrives())
            {
                var item = new TreeViewItem();

                item.Header = drive;
                item.Tag = drive;

                item.Items.Add(null);

                item.Expanded += Folder_Expanded;

                this.FolderView.Items.Add(item);
            }
        }

        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {
            var item = sender as TreeViewItem;

            var fullPath = (string)item.Tag;

            if (item.Items.Count != 1 || item.Items[0] != null)
                return;

            item.Items.Clear();

            string[] dirs;
            string[] files;

            try
            {
                files = Directory.GetFiles(fullPath);

                dirs = Directory.GetDirectories(fullPath);
            }
            catch(UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            foreach (var fx in dirs)
            {
                var directoryName = Path.GetFileName(fx);

                var subItem = new TreeViewItem()
                {
                    Header = directoryName,

                    Tag = fx
                };

                subItem.Items.Add(null);

                subItem.Expanded += Folder_Expanded;

                item.Items.Add(subItem);
            }

            foreach (var fx in files)
            {
                var directoryName = Path.GetFileName(fx);

                var subItem = new TreeViewItem()
                {
                    Header = directoryName,

                    Tag = fx
                };

                subItem.Expanded += Folder_Expanded;

                item.Items.Add(subItem);
            }



        }
    }
}
