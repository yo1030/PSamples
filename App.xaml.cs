﻿using Prism.Ioc;
using PSamples.ViewModels;
using PSamples.Views;
using System.Windows;

namespace PSamples
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA>();
            containerRegistry.RegisterDialog<ViewB, ViewBViewModel>();
        }
    }
}
