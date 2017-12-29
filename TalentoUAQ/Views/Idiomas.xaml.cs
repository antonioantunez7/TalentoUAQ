using System;
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
                await DisplayAlert("Información", "Se guardo el Idioma", "Aceptar");
                await Navigation.PopAsync();
            }
        }
    }
}
