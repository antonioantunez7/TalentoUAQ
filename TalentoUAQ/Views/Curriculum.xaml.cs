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
            //cargaOpcionesCurriculum();
        }

        /*void cargaOpcionesCurriculum()
        {
            opciones = new ObservableCollection<Opciones>();
            opciones.Add(new Opciones { idOpcion = 1, nombre = "Descripción", detalle = "", icono = "acerca.png" });
            opciones.Add(new Opciones { idOpcion = 2, nombre = "Mi area de especialidad", detalle = "Puedes tener máximo 3", icono = "acerca.png" });
            opciones.Add(new Opciones { idOpcion = 3, nombre = "Experiencia", detalle = "", icono = "acerca.png" });
            opciones.Add(new Opciones { idOpcion = 4, nombre = "Educación", detalle = "", icono = "acerca.png" });
            listaOpcionesCurriculum.ItemsSource = opciones;
        }*/
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
<<<<<<< HEAD
            await Navigation.PushAsync(new Idiomas());
=======
            Button boton = (Button)sender;
            await DisplayAlert("Información", "xd: "+boton, "Aceptar");
            await Navigation.PushModalAsync(new DetalleCurriculum());
>>>>>>> edab5ac... a
        }
    }
}
