﻿using APS4.Vues;

namespace APS4
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new ConnexionVue();
            MainPage = new NavigationPage(new ConnexionVue());
            //MainPage = new AppShell();
        }
    }
}