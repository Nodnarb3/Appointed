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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Appointed.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for EditPatientGeneralInfo.xaml
    /// </summary>
    public partial class EditPatientGeneralInfo : Window
    {
        public EditPatientGeneralInfo()
        {
            InitializeComponent();
        }

        private void OnMouseLeftRelease_Discard(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }   
    }
}
