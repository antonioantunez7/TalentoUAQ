using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TalentoUAQ.Models;
using Xamarin.Forms;

namespace TalentoUAQ.Views
{
    public partial class Curriculum : ContentPage
    {
        public ObservableCollection<Opciones> opciones { get; set; }
        public Curriculum()
        {
            InitializeComponent();
        }

        async void agregarModalDescripcion(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new DetalleCurriculum());
        }
        async void agregarModalEspecialidad(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new AreaEspecialidad());
        }
        async void agregarModalExperiencia(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Experiencia());
        }
        async void agregarModalEduacacion(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Educacion());
        }
        async void agregarModalIdiomas(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Idiomas());
        }
    }
}
