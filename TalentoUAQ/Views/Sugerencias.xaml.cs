using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TalentoUAQ.Models;
using Xamarin.Forms;

namespace TalentoUAQ.Views
{
    public partial class Sugerencias : ContentPage
    {
        public ObservableCollection<Ofertas> ofertas { get; set; }
        public Sugerencias()
        {
            InitializeComponent();
            cargaSugerencias();
        }

        void cargaSugerencias()
        {
            ofertas = new ObservableCollection<Ofertas>();
            ofertas.Add(new Ofertas
            {
                titulo = "Sugerencia 1",
                sueldoInicio = 5000,
                sueldoFin = 20000
            });

            ofertas.Add(new Ofertas
            {
                titulo = "Sugerencia 2",
                sueldoInicio = 3000,
                sueldoFin = 50000
            });

            listaSugerencias.ItemsSource = ofertas;
        }

        async void seleccionaSugerencia_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var oferta = e.SelectedItem as Ofertas;
            if (oferta != null)
            {
                await Navigation.PushAsync(new DetalleOferta(oferta));
                listaSugerencias.SelectedItem = null;//Para que automaticamente se deseleccione el elemento
            }
        }
    }
}
