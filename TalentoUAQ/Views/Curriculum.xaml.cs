using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TalentoUAQ.Models;
using Xamarin.Forms;

namespace TalentoUAQ.Views
{
    public partial class Curriculum : ContentPage
    {
        public ObservableCollection<Ofertas> ofertas { get; set; }
        public ObservableCollection<SubcategoriasUsuarios> subcategoriasUsuarios { get; set; }
        public Curriculum()
        {
            InitializeComponent();
            cargarOfertas();
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
        void cargarOfertas() {
            subcategoriasUsuarios = new ObservableCollection<SubcategoriasUsuarios>();
            subcategoriasUsuarios.Add(new SubcategoriasUsuarios { idSubcategoriaUsuario = 1, desSubcategoria="Desarrollador Xamarin" });
            subcategoriasUsuarios.Add(new SubcategoriasUsuarios { idSubcategoriaUsuario = 2, desSubcategoria = "Desarrollador PHP" });
            subcategoriasUsuarios.Add(new SubcategoriasUsuarios { idSubcategoriaUsuario = 3, desSubcategoria = "Desarrollador .NET" });
            subcategoriasUsuarios.Add(new SubcategoriasUsuarios { idSubcategoriaUsuario = 4, desSubcategoria = "Desarrollador Java" });
            ListaSubcategoriasUsuarios.ItemsSource = subcategoriasUsuarios;
        }

        async void eliminarEspecialidad_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var answer = await DisplayAlert("Confirmar", "¿Deseas Eliminar esta especialidad?", "Si", "No");
        }
    }
}
