﻿using Prism;
using Prism.Ioc;
using MyLeasing.Prism.ViewModels;
using MyLeasing.Prism.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyLeasing.Common.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MyLeasing.Prism
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTU0ODcxQDMxMzcyZTMzMmUzMFVRTmF0S1dvOW9VVVJ3aFVrRWgzazBYL0xhZnJndnhvSVNDVU1GckJnL3M9");
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/LoginPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<PropertiesPage, PropertiesPageViewModel>();
            containerRegistry.RegisterForNavigation<PropertyPage, PropertyPageViewModel>();
            containerRegistry.RegisterForNavigation<ContractsPage, ContractsPageViewModel>();
            containerRegistry.RegisterForNavigation<ContractPage, ContractPageViewModel>();
            containerRegistry.RegisterForNavigation<PropertyTabbedPage, PropertyTabbedPageViewModel>();
            containerRegistry.RegisterForNavigation<LeasingMasterDetailPage, LeasingMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<ModifyUserPage, ModifyUserPageViewModel>();
            containerRegistry.RegisterForNavigation<MapPage, MapPageViewModel>();
            containerRegistry.RegisterForNavigation<RegisterPage, RegisterPageViewModel>();
            containerRegistry.RegisterForNavigation<RememberPasswordPage, RememberPasswordViewModel>();
        }
    }
}
