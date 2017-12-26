using System;
using System.Collections.Generic;
using TalentoUAQ.Models;
using Xamarin.Forms;

namespace TalentoUAQ.Views
{
    public partial class AreaEspecialidad : ContentPage
    {
        List<Categorias> categorias;
        List<Subcategorias> subcategorias;
        public AreaEspecialidad()
        {
            InitializeComponent();
            cargaCategorias();
        }
        void cargaCategorias()
        {
            categorias = new List<Categorias>{
                new Categorias {cveCategoria = 1, descCategoria = "Ingeniería"},
                new Categorias {cveCategoria = 2, descCategoria = "Educación"},
                new Categorias {cveCategoria = 3, descCategoria = "Biología"}
            };
            cmbCategoriaD.Items.Clear();
            foreach (var categoria in categorias)
            {
                cmbCategoriaD.Items.Add(categoria.descCategoria);
            }
        }
        void seleccionaCategoriaD_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var posicion = cmbCategoriaD.SelectedIndex;
            if (posicion > -1)
            {
                cargaSubcategoriasD(categorias[posicion].cveCategoria);
            }
        }
        void cargaSubcategoriasD(int cveCategoria)
        {
            subcategorias = new List<Subcategorias>{
                new Subcategorias {cveSubcategoria = 1, descSubcategoria = "Computacion", cveCategoria = 1},
                new Subcategorias {cveSubcategoria = 2, descSubcategoria = "Redes", cveCategoria = 1},
                new Subcategorias {cveSubcategoria = 3, descSubcategoria = "Matematicas", cveCategoria = 2},
                new Subcategorias {cveSubcategoria = 4, descSubcategoria = "Quimica", cveCategoria = 2},
                new Subcategorias {cveSubcategoria = 5, descSubcategoria = "Fauna", cveCategoria = 3}
            };
            cmbSubCategoriaD.Items.Clear();
            foreach (var subcategoria in subcategorias)
            {
                if (subcategoria.cveCategoria == cveCategoria)
                {
                    cmbSubCategoriaD.Items.Add(subcategoria.descSubcategoria);
                }
            }
        }
        async void cerrarModal(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }
    }
}
