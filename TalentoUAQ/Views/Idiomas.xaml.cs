using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TalentoUAQ.Views
{
    public partial class Idiomas : ContentPage
    {
        public Idiomas()
        {
            InitializeComponent();
        }
        async void cerrarModal(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }

        void txtPorcentaje_ValueChanged(object sender, EventArgs args)
        {
            double porcentage = txtPorcentaje.Value;
            int valo = Convert.ToInt32(porcentage);
            string valor = valo + "%";
            labelPorcentaje.Text = valor;
        }
    }
}
