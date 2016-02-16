using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestApp2.Pages;
using TestApp2.Services;
using TestApp2.ViewModels;
using Xamarin.Forms;

namespace TestApp2
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            var device = DependencyService.Get<IDevice>();
            this.MainPage = new MainPage(new MainViewModel(new ShapeFactory(new RandomizerService(),device)),device);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

    }
}
