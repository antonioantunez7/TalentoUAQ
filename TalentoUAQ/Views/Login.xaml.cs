using System;
using System.Collections.Generic;
using TalentoUAQ.Models;
using TalentoUAQ.Services;
using Xamarin.Forms;

namespace TalentoUAQ.Views
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        async void Ingresar_Clicked(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                await DisplayAlert("Información", "Ingrese su usuario", "Aceptar");
                txtUsuario.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                await DisplayAlert("Información", "Ingrese su contraseña", "Aceptar");
                txtPassword.Focus();
                return;
            }
            waitActivityIndicador.IsRunning = true;//Pone el de cargando
            btnIngresar.IsEnabled = false;//Deshabilita el boton
            Device.BeginInvokeOnMainThread(async () =>
            {
                //RestClient cliente = new RestClient();
                //var eventos = await cliente.Get<VistaEventos>("http://189.211.201.181:86/CulturaUAQWebservice/api/tbleventos");
                var eventos = "default";
                btnIngresar.IsEnabled = true;//Habilita el boton
                waitActivityIndicador.IsRunning = false;//Quita el de cargando
                if (eventos != null)
                {
                    Usuarios usuario = new Usuarios { idUsuario = 1, nombre = txtUsuario.Text, paterno = "Prueba", materno = "Prueba" };
                    Application.Current.MainPage = new NavigationPage(new MainPage(usuario));//Reemplaza la pagina

                }
                else
                {
                    await DisplayAlert("Información", "Usuario o contraseña no validos", "Aceptar");
                    txtPassword.Text = string.Empty;
                    txtPassword.Focus();
                    return;
                }
                txtPassword.Text = string.Empty;
                txtPassword.Focus();
            });
        }
    }
}
