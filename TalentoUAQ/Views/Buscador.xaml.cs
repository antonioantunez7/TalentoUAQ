using System;
using System.Collections.Generic;
using TalentoUAQ.Models;
using Xamarin.Forms;

namespace TalentoUAQ.Views
{
    public partial class Buscador : ContentPage
    {
        List<Categorias> categorias;
        public Buscador()
        {
            InitializeComponent();
            cargaCategorias();
        }

        void cargaCategorias(){
            categorias = new List<Categorias>{
                new Categorias {cveCategoria = 1, descCategoria = "Ingeniería"},
                new Categorias {cveCategoria = 2, descCategoria = "Educación"},
                new Categorias {cveCategoria = 3, descCategoria = "Biología"}
            };
            foreach(var categoria in categorias){
                cmbCategoria.Items.Add(categoria.descCategoria);    
            }
        }

        async void seleccionaCategoria_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var posicion = cmbCategoria.SelectedIndex;
            if (posicion > -1)
            { 
                await DisplayAlert("Información", categorias[posicion].cveCategoria +" "+ categorias[posicion].descCategoria, "Aceptar");             
            }
        }
    }
}
