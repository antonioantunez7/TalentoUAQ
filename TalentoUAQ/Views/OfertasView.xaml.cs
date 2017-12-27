using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TalentoUAQ.Models;
using TalentoUAQ.Services;
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

        async void cargaOfertas(Ofertas oferta)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                RestClient cliente = new RestClient();

                var ofertasResp = await cliente.GetOfertas<ListaOfertas>("http://189.211.201.181:69/TalentoUAQWebService/api/tblofertasbusqueda/titulo/0/sueldoInicio/0/sueldoFin/0/fechaInicioOferta/0/fechaFinOferta/0/cveEmpresa/0/cveTipoEmpleo/0/cveSubcategoria/0/cveMunicipio/0");
                if (ofertasResp != null)
                {
                    if (ofertasResp.listaOfertas.Count > 0)
                    {
                        ofertas = new ObservableCollection<Ofertas>();
                        foreach (var ofertax in ofertasResp.listaOfertas)
                        {
                            ofertas.Add(new Ofertas
                            {
                                titulo = ofertax.titulo,
                                sueldoInicio = ofertax.sueldoInicio,
                                sueldoFin = ofertax.sueldoFin
                            });
                        }
                        listaOfertas.ItemsSource = ofertas;
                    }
                }
            }); 
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
