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
        public ObservableCollection<Estudios> estudios { get; set; }
        public ObservableCollection<Experiencias> experiencias { get; set; }
        public ObservableCollection<IdiomasModel> idiomasModel { get; set; }
        public Curriculum()
        {
            InitializeComponent();
            cargarOfertas();
            cargarEstudios();
            cargarExperiencia();
            cargarIdiomas();
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
        async void agregarModalEducacion(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Educacion());
        }
        async void agregarModalIdiomas(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Idiomas());
        }
        void cargarOfertas()
        {
            subcategoriasUsuarios = new ObservableCollection<SubcategoriasUsuarios>();
            subcategoriasUsuarios.Add(new SubcategoriasUsuarios { idSubcategoriaUsuario = 1, desSubcategoria = "Desarrollador Xamarin" });
            subcategoriasUsuarios.Add(new SubcategoriasUsuarios { idSubcategoriaUsuario = 2, desSubcategoria = "Desarrollador PHP" });
            subcategoriasUsuarios.Add(new SubcategoriasUsuarios { idSubcategoriaUsuario = 3, desSubcategoria = "Desarrollador .NET" });
            subcategoriasUsuarios.Add(new SubcategoriasUsuarios { idSubcategoriaUsuario = 4, desSubcategoria = "Desarrollador Java" });
            int totalSubcategorias = subcategoriasUsuarios.Count;
            Double total = 35 * totalSubcategorias;
            ListaSubcategoriasUsuarios.HeightRequest = total;
            ListaSubcategoriasUsuarios.ItemsSource = subcategoriasUsuarios;
        }
        void cargarEstudios()
        {
            estudios = new ObservableCollection<Estudios>();
            estudios.Add(new Estudios { idEstudio = 1, escuela = "Universiad Tecnológica del Valle de Toluca", carrera = "Tecnologias de la Información y Comunicación", fechaInicio = "01/10/2015", fechaFin = "01/10/2018" });
            estudios.Add(new Estudios { idEstudio = 2, escuela = "Centro de Estudios Tecnológicos industrial y de servicios #23", carrera = "Informatica", fechaInicio = "01/10/2012", fechaFin = "01/10/2015" });
            Double totalEstudios = 80 * estudios.Count;
            ListaEstudios.HeightRequest = totalEstudios;
            ListaEstudios.ItemsSource = estudios;
        }
        void cargarExperiencia()
        {
            experiencias = new ObservableCollection<Experiencias>();
            experiencias.Add(new Experiencias { idExperiencia = 1, empresa = "Andrades Company", puesto = "Desarrollador Movil", fechaInicio = "01/10/2015", fechaFin = "01/10/2018" });
            experiencias.Add(new Experiencias { idExperiencia = 2, empresa = "Poder Judicial del Estado de México", puesto = "Desarrollador Web", fechaInicio = "01/10/2015", fechaFin = "01/10/2018" });
            experiencias.Add(new Experiencias { idExperiencia = 3, empresa = "Secrtaría de la Contraloria del Gobierno del estado de México", puesto = "Desarrollador", fechaInicio = "01/10/2015", fechaFin = "01/10/2018" });
            Double totalExperiencia = 80 * experiencias.Count;
            ListaExperiencia.HeightRequest = totalExperiencia;
            ListaExperiencia.ItemsSource = experiencias;
        }
        void cargarIdiomas()
        {
            idiomasModel = new ObservableCollection<IdiomasModel>();
            idiomasModel.Add(new IdiomasModel { idIdioma = 1, idioma = "Español", porcentaje = 100 });
            idiomasModel.Add(new IdiomasModel { idIdioma = 1, idioma = "ingles", porcentaje = 50 });
            Double totalIdiomas = 35 * idiomasModel.Count;
            ListaIdiomas.HeightRequest = totalIdiomas;
            ListaIdiomas.ItemsSource = idiomasModel;
        }
        async void eliminarEspecialidad_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var answer = await DisplayAlert("Confirmar", "¿Deseas Eliminar esta especialidad?", "Si", "No");
        }
        async void verEstudio(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var answer = await DisplayAlert("Confirmar", "¿Deseas Eliminar esta especialidad?", "Si", "No");
        }
        async void verExperiencia(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var answer = await DisplayAlert("Confirmar", "¿Deseas Eliminar esta especialidad?", "Si", "No");
        }
        async void verIdiomas(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var answer = await DisplayAlert("Confirmar", "¿Deseas Eliminar esta especialidad?", "Si", "No");
        }
    }
}
