using System;
using System.Collections.Generic;
using System.Net.Http;
using TalentoUAQ.Models;
using Xamarin.Forms;

namespace TalentoUAQ.Views
{
    public partial class Idiomas : ContentPage
    {
        public Idiomas()
        {
            InitializeComponent();
        }

        void txtPorcentaje_ValueChanged(object sender, EventArgs args)
        {
            double porcentage = txtPorcentaje.Value;
            int valo = Convert.ToInt32(porcentage);
            string valor = valo + "%";
            labelPorcentaje.Text = valor;
        }
        async void guardarIdioma(object sender, EventArgs args)
        {
            string idiomaNombre = txtIdioma.Text;
            int porcentajeDominio = Convert.ToInt32(txtPorcentaje.Value);
            bool error = false;
            if (string.IsNullOrEmpty(idiomaNombre))
            {
                await DisplayAlert("Error", "Coloca el Idioma", "Aceptar");
                error = true;
            }
            if (porcentajeDominio < 30)
            {
                await DisplayAlert("Error", "el Porcentaje no puede ser menor a 30%", "Aceptar");
                error = true;
            }
            if (!error)
            {
                HttpClient cliente = new HttpClient();
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("idAspirante", "1"),
                    new KeyValuePair<string, string>("idioma",idiomaNombre),
                    new KeyValuePair<string, string>("porcentaje",porcentajeDominio.ToString()),
                    new KeyValuePair<string, string>("activo","S"),
                });

                var myHttpClient = new HttpClient();
                var response = await myHttpClient.PostAsync("http://189.211.201.181:69/TalentoUAQWebService/api/idiomas/guardar", formContent);

                var json = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    await Navigation.PopAsync();
                    await DisplayAlert("Correcto", "Se guardó el Registro", "Aceptar");
                }
                else
                {
                    await DisplayAlert("Error", "Algo Salio Mal", "Aceptar");
                }
            }
        }
    }
}
