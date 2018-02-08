using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;

namespace TalentoUAQ.Views
{
    public partial class DetalleCurriculum : ContentPage
    {
        public DetalleCurriculum()
        {
            InitializeComponent();
        }
        async void guardarModal(object sender, EventArgs args)
        {
            string telefono = txtTelefono.Text;
            string email = correo.Text;
            string objetivo = txtObjetivo.Text;
            bool error = false;
            if (string.IsNullOrEmpty(telefono))
            {
                await DisplayAlert("Error", "Coloca el Telefono", "Aceptar");
                error = true;
            }
            if (string.IsNullOrEmpty(email))
            {
                await DisplayAlert("Error", "Coloca el Correo", "Aceptar");
                error = true;
            }
            if (string.IsNullOrEmpty(objetivo))
            {
                await DisplayAlert("Error", "Coloca el Objetivo Profesional", "Aceptar");
                error = true;
            }
            if (!error)
            {
                HttpClient cliente = new HttpClient();
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("idAspirante", Application.Current.Properties["idAspirante"].ToString()),
                    new KeyValuePair<string, string>("objetivo",objetivo),
                    new KeyValuePair<string, string>("telefono",telefono),
                    new KeyValuePair<string, string>("email",email),
                });

                var myHttpClient = new HttpClient();
                var response = await myHttpClient.PostAsync("http://189.211.201.181:69/TalentoUAQWebService/api/aspirantes/guardar", formContent);

                var json = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Correcto", "Se guardó el Registro", "Aceptar");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "Algo Salio Mal", "Aceptar");
                }
            }
        }
    }
}
