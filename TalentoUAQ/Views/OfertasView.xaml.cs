using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TalentoUAQ.Models;
using Xamarin.Forms;

namespace TalentoUAQ.Views
{
    public partial class OfertasView : ContentPage
    {
        public ObservableCollection<Ofertas> ofertas { get; set; }
        public OfertasView(Ofertas oferta)
        {
            InitializeComponent();
            cargaOfertas(oferta);
        }

        void cargaOfertas(Ofertas oferta)
        {
            ofertas = new ObservableCollection<Ofertas>();
            ofertas.Add(new Ofertas{
                titulo = oferta.titulo, 
                sueldoInicio = oferta.sueldoInicio, 
                sueldoFin = oferta.sueldoFin});

            ofertas.Add(new Ofertas
            {
                titulo = oferta.titulo,
                sueldoInicio = oferta.sueldoInicio,
                sueldoFin = oferta.sueldoFin
            });
            listaOfertas.ItemsSource = ofertas;
        }

        async void seleccionaOferta_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var oferta = e.SelectedItem as Ofertas;
            if (oferta != null)
            {
                await Navigation.PushAsync(new DetalleOferta(oferta));
                listaOfertas.SelectedItem = null;//Para que automaticamente se deseleccione el elemento
            } 
        }
    }
}
