using System;
using System.Collections.Generic;
using TalentoUAQ.Models;
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
                await DisplayAlert("Correcto", "Se guardarón los datos", "Aceptar");
                await Navigation.PopAsync();
            }
        }

    }
}