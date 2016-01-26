using System;

using Xamarin.Forms;
using BizDeducter.View;

namespace BizDeducter
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            MainPage = new RootPage();

           /* var button = new Button { Text = "Click Me" };

            button.Clicked += (sender, e) => 
                {
                    MainPage = new RootPage();
                };

            MainPage = new ContentPage
            {
                    Title = "Hello Tom",
                    Content = button
            };*/
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

