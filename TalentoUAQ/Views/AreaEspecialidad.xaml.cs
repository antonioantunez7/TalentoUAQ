using System;
using System.Collections.Generic;
using System.Net.Http;
using TalentoUAQ.Models;
using TalentoUAQ.Services;
using Xamarin.Forms;

namespace TalentoUAQ.Views
{
    public partial class AreaEspecialidad : ContentPage
    {
        List<Categorias> categorias;
        List<Subcategorias> subcategorias;
        private List<Categorias> lcategorias;
        private List<Subcategorias> lsubcategorias;

        public AreaEspecialidad()
        {
            InitializeComponent();
            cargaCategorias();
        }
        void cargaCategorias()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                RestClient cliente = new RestClient();
                var categorias = await cliente.GetCategorias<ListaCategorias>("http://148.240.202.160:69/TalentoUAQWebService/api/tblcategorias");
                if (categorias != null)
                {
                    if (categorias.listaCategorias.Count > 0)
                    {
                        lcategorias = new List<Categorias>();
                        foreach (var categoria in categorias.listaCategorias)
                        {
                            lcategorias.Add(new Categorias
                            {
                                cveCategoria = categoria.cveCategoria,
                                descCategoria = categoria.descCategoria
                            });
                        }
                        cmbCategoriaD.Items.Clear();
                        foreach (var categoria in lcategorias)
                        {
                            cmbCategoriaD.Items.Add(categoria.descCategoria);
                        }
                    }
                }
            });
        }
        void seleccionaCategoriaD_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var posicion = cmbCategoriaD.SelectedIndex;
            if (posicion > -1)
            {
                cargaSubcategoriasD(lcategorias[posicion].cveCategoria);
            }
        }
        void cargaSubcategoriasD(int cveCategoria)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                RestClient cliente = new RestClient();
                var subcategorias = await cliente.GetSubcategorias<ListaSubcategorias>("http://148.240.202.160:69/TalentoUAQWebService/api/tblsubcategorias/categoria?cveCategoria=" + cveCategoria);
                if (subcategorias != null)
                {
                    if (subcategorias.listaSubcategorias.Count > 0)
                    {
                        lsubcategorias = new List<Subcategorias>();
                        foreach (var subcategoria in subcategorias.listaSubcategorias)
                        {
                            lsubcategorias.Add(new Subcategorias
                            {
                                cveSubcategoria = subcategoria.cveSubcategoria,
                                descSubcategoria = subcategoria.descSubcategoria
                            });
                        }
                        cmbSubCategoriaD.Items.Clear();
                        foreach (var subcategoria in lsubcategorias)
                        {
                            cmbSubCategoriaD.Items.Add(subcategoria.descSubcategoria);
                        }
                    }
                }
            });
        }
        async void guardarSubcategoria(object sender, EventArgs args)
        {
            var subcategoria = 0;
            var posicionSubcategoria = cmbSubCategoriaD.SelectedIndex;
            if (posicionSubcategoria > -1)
            {
                subcategoria = lsubcategorias[posicionSubcategoria].cveSubcategoria;
            }
            if (subcategoria == 0)
            {
                await DisplayAlert("Error", "Selecciona una subcategoria", "Aceptar");
            }
            else
            {
                HttpClient cliente = new HttpClient();
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("idUsuarioExterno", "1"),
                    new KeyValuePair<string, string>("cveSubcategoria",subcategoria.ToString()),
                    new KeyValuePair<string, string>("activo","S"),
                });

                var myHttpClient = new HttpClient();
                var response = await myHttpClient.PostAsync("http://148.240.202.160:69/TalentoUAQWebService/api/subcategoriasusuario/guardar", formContent);

                var json = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Correcto", "Se guardó el Registro", "Aceptar");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "Algo Salio Mal", "Aceptar");
                }
            }

        }
    }
}
