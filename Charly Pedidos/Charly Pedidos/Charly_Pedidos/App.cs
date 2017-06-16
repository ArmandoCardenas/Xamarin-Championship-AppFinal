using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Charly_Pedidos.Views;
using Xamarin.Forms;

namespace Charly_Pedidos
{
    public class App : Application
    {
        public App()
        {
            MainPage = new Principal();
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
