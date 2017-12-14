﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TalentoUAQ.Models;
using Xamarin.Forms;

namespace TalentoUAQ.Views
{
    public partial class Favoritos : ContentPage
    {
        public ObservableCollection<Ofertas> ofertas { get; set; }
        public Favoritos()
        {
            InitializeComponent();
            cargaFavoritos();
        }

        void cargaFavoritos()
        {
            ofertas = new ObservableCollection<Ofertas>();
            ofertas.Add(new Ofertas
            {
                titulo = "Mi favorito 1",
                sueldoInicio = 5000,
                sueldoFin = 20000
            });

            ofertas.Add(new Ofertas
            {
                titulo = "Mi favorito 2",
                sueldoInicio = 3000,
                sueldoFin = 50000
            });

            listaFavoritos.ItemsSource = ofertas;
        }

        async void seleccionaFavorito_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {   
            var oferta = e.SelectedItem as Ofertas;
            if (oferta != null)
            {
                await Navigation.PushAsync(new DetalleOferta(oferta));
                listaFavoritos.SelectedItem = null;//Para que automaticamente se deseleccione el elemento
            } 
        }
    }
}
