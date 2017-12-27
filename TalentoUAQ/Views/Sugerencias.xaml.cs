using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TalentoUAQ.Models;
using TalentoUAQ.Services;
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

        async void cargaSugerencias()
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
                                sueldoFin = ofertax.sueldoFin,
                                correoContacto = ofertax.correoContacto,
                                fechaInicioOferta = this.fechaSQLaNormal(ofertax.fechaInicioOferta),
                                descripcion = ofertax.descripcion,
                                rangoSueldo = "$" + ofertax.sueldoInicio + " MXN - $" + ofertax.sueldoFin + " MXN",
                                nombreBoton = "Agregar a favoritos"
                            });
                        }
                        listaSugerencias.ItemsSource = ofertas;
                    }
                }
            });
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

        public string fechaSQLaNormal(string fecha)
        {
            string[] fechaHoralNormal = fecha.Split('T');
            string[] fechaNormal = fechaHoralNormal[0].Split('-');
            return fechaNormal[2] + "/" + fechaNormal[1] + "/" + fechaNormal[0];
        }
    }
}
