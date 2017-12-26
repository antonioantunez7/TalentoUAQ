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
        void cargarNivelesAcademicos() {
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
        async void cerrarModal(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }
    }
}
