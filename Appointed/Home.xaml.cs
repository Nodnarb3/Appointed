﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Appointed.Views;
using Appointed.Views.Sidebar;
using Appointed.Views.Dialogs;

namespace Appointed
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();

            ShowHomeSidebar();

        }

        private void ShowHomeSidebar()
        {
            HomeSidebar homeSidebar = new HomeSidebar();

            SidebarView.SetSidebarView(homeSidebar);

            Button newPatientBtn = new Button
            {
                Content = new Image()
                {
                    Source = Assets.ResourceManager.Instance.Images["NewPatientIcon"],
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(8d)
                }
            };

            SidebarView.SetLeftQuickNavButton(newPatientBtn);
            SidebarView.SetRightQuickNavButton(null);
            Grid.SetColumnSpan(newPatientBtn, 2);

            newPatientBtn.Click += (object sender, RoutedEventArgs args) => { new NewPatientDialog().ShowDialog(); };
        }
    }
}
