using System;
using System.Collections.Generic;

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
                await DisplayAlert("Correcto", "Se guardó el Registro", "Aceptar");
                await Navigation.PopAsync();
            }
        }
    }
}
