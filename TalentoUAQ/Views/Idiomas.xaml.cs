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
    }
}
