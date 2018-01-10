using System;
using TalentoUAQ.Models;
using TalentoUAQ.Views;
using Xamarin.Forms;

namespace TalentoUAQ
{
    public partial class App : Application
    {
        public static bool UseMockDataStore = true;
        public static string BackendUrl = "https://localhost:5000";

        public App()
        {
            InitializeComponent();
            if (Application.Current.Properties.ContainsKey("idUsuario")
                && Application.Current.Properties.ContainsKey("nombre")
                && Application.Current.Properties.ContainsKey("paterno")
                && Application.Current.Properties.ContainsKey("materno"))
            {
                var idUsuario = Convert.ToInt32(Application.Current.Properties["idUsuario"]);
                var nombre = (string)Application.Current.Properties["nombre"];
                var paterno = (string)Application.Current.Properties["paterno"];
                var materno = (string)Application.Current.Properties["paterno"];
                Usuarios usuario = new Usuarios { idUsuario = idUsuario, nombre = nombre, paterno = paterno, materno = materno };
                Application.Current.MainPage = new NavigationPage(new MainPage(usuario));//Reemplaza la pagina
            } else{
                MainPage = new Login();    
            }
            //MainPage = new Login();
            /*if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<CloudDataStore>();

            if (Device.RuntimePlatform == Device.iOS)
                MainPage = new MainPage();
            else
                MainPage = new NavigationPage(new MainPage());*/
        }
    }
}
