﻿using SAKD.ViewModels;

namespace SAKD.Views
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage
    {
        public LoginPage()
        {
            InitializeComponent();
            DataContext = new LoginViewModel(this);
        }
    }
}
