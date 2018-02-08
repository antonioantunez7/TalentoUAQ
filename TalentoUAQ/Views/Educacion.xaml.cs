using System;
using System.Collections.Generic;
using System.Net.Http;
using TalentoUAQ.Models;
using TalentoUAQ.Views;
using Xamarin.Forms;

namespace TalentoUAQ.Views
{
    public partial class Educacion : ContentPage
    {
        List<NivelesAcademicos> nivelesAcademicos;
        public Educacion()
        {
            InitializeComponent();
            cargarNivelesAcademicos();
        }
        void cargarNivelesAcademicos()
        {
            nivelesAcademicos = new List<NivelesAcademicos>{
                new NivelesAcademicos {idNivelAcademico = 1, desNivelAcademico = "Secundaria"},
                new NivelesAcademicos {idNivelAcademico = 2, desNivelAcademico = "Bachillerato"},
                new NivelesAcademicos {idNivelAcademico = 3, desNivelAcademico = "Estudios Universitario sin Terminar"},
                new NivelesAcademicos {idNivelAcademico = 3, desNivelAcademico = "Técnico Titulado"},
                new NivelesAcademicos {idNivelAcademico = 3, desNivelAcademico = "Estudios Universitario - no titulado"},
                new NivelesAcademicos {idNivelAcademico = 3, desNivelAcademico = "Estudios Universitario - titulado"},
                new NivelesAcademicos {idNivelAcademico = 3, desNivelAcademico = "Diplomado"},
                new NivelesAcademicos {idNivelAcademico = 3, desNivelAcademico = "Maestria"},
                new NivelesAcademicos {idNivelAcademico = 3, desNivelAcademico = "Doctorado"}
            };
            cmbNivelAcademico.Items.Clear();
            foreach (var nivel in nivelesAcademicos)
            {
                cmbNivelAcademico.Items.Add(nivel.desNivelAcademico);
            }
        }
        async void guardarEducacion(object sender, EventArgs args)
        {
            string escuela = txtEscuela.Text;
            int posicion = cmbNivelAcademico.SelectedIndex;
            int nivelAcademico = 0;
            if (posicion > -1)
            {
                nivelAcademico = nivelesAcademicos[posicion].idNivelAcademico;
            }
            string carrera = txtCarrera.Text;
            bool error = false;
            if (string.IsNullOrEmpty(escuela))
            {
                error = true;
                await DisplayAlert("Error", "Captura la escuela donde estudiaste", "Aceptar");
            }
            if (nivelAcademico == 0)
            {
                error = true;
                await DisplayAlert("Error", "Seecciona un nivel Academico", "Aceptar");
            }
            if (string.IsNullOrEmpty(carrera))
            {
                error = true;
                await DisplayAlert("Error", "Captura la Carrera o e título", "Aceptar");
            }
            if (!error)
            {
                HttpClient cliente = new HttpClient();
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("idAspirante", Application.Current.Properties["idAspirante"].ToString()),
                    new KeyValuePair<string, string>("escuela",escuela),
                    new KeyValuePair<string, string>("carrera",carrera),
                    new KeyValuePair<string, string>("fechaInicio",fechaInicio.Date.ToString("yyyy/MM/dd")),
                    new KeyValuePair<string, string>("fechaInicio",fechaFin.Date.ToString("yyyy/MM/dd")),
                    new KeyValuePair<string, string>("activo","S"),
                });
                var myHttpClient = new HttpClient();
                var response = await myHttpClient.PostAsync("http://189.211.201.181:69/TalentoUAQWebService/api/escolaridades/guardar", formContent);
                var json = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Correcto", "Se guardó el Registro", "Aceptar");
                    var detalle = new Curriculum();
                    detalle.cargarGeneral();
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