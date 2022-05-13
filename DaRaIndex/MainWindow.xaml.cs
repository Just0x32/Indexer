﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DaRaIndex
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel viewModel = new ViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void GetFoldersList_Click(object sender, RoutedEventArgs e) => viewModel.GetFoldersList();

        private void IndexSelected_Click(object sender, RoutedEventArgs e)
        {
            viewModel.IndexSelected(GetSelectedIndexes(FoldersList.SelectedItems));
        }

        private void UnindexSelected_Click(object sender, RoutedEventArgs e)
        {
            viewModel.UnindexSelected(GetSelectedIndexes(FoldersList.SelectedItems));
        }

        private int[] GetSelectedIndexes(System.Collections.IList selectedItems)
        {
            int[] selectedIndexes = new int[selectedItems.Count];

            for (int i = 0; i < selectedItems.Count; i++)
                selectedIndexes[i] = FoldersList.Items.IndexOf(selectedItems[i]);

            return selectedIndexes;
        }
    }
}
