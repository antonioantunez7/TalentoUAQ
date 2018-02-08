using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;

namespace TalentoUAQ.Views
{
    public partial class Experiencia : ContentPage
    {
        public Experiencia()
        {
            InitializeComponent();
        }
        async void guardarExperiencia(object sender, EventArgs args)
        {
            bool error = false;
            if (string.IsNullOrEmpty(txtEmpresa.Text))
            {
                await DisplayAlert("Error", "Coloca el nombre de la Empresa ", "Aceptar");
            }
            if (string.IsNullOrEmpty(txtPuesto.Text))
            {
                error = true;
                await DisplayAlert("Error", "Coloca el Puesto", "Aceptar");
            }
            if (!error)
            {
                HttpClient cliente = new HttpClient();
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("idAspirante", Application.Current.Properties["idAspirante"].ToString()),
                    new KeyValuePair<string, string>("institucion",txtEmpresa.Text),
                    new KeyValuePair<string, string>("cargo",txtPuesto.Text),
                    new KeyValuePair<string, string>("fechaInicio",fechaInicio.Date.ToString("yyyy/MM/dd")),
                    new KeyValuePair<string, string>("fechaInicio",fechaFin.Date.ToString("yyyy/MM/dd")),
                    new KeyValuePair<string, string>("activo","S"),
                });

                var myHttpClient = new HttpClient();
                var response = await myHttpClient.PostAsync("http://189.211.201.181:69/TalentoUAQWebService/api/experiencias/guardar", formContent);

                var json = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Correcto", "Se guardó el Registro", "Aceptar");
                    var detalle = new Curriculum();
                    detalle.cargarGeneral();
                    await Navigation.PopAsync();
                }
                else {
                    await DisplayAlert("Error", "Algo Salio Mal", "Aceptar");
                }
                            
            }
        }
    }
}
