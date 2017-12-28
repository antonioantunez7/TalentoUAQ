using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
            etiquetaCargando.Text = "Cargando ofertas, por favor espere...";
            svOfertas.Content = etiquetaCargando;

            Device.BeginInvokeOnMainThread(async () =>
            {
                RestClient cliente = new RestClient();
                string titulo = "0";
                if(!string.IsNullOrEmpty(oferta.titulo)){
                    titulo = oferta.titulo;   
                }
                string sueldoInicio = "0";
                if (oferta.sueldoInicio != 0)
                {
                    sueldoInicio = ""+oferta.sueldoInicio;
                }
                string sueldoFin = "0";
                if (oferta.sueldoFin != 0)
                {
                    sueldoFin = "" + oferta.sueldoFin;
                }
                string fechaInicioOferta = oferta.fechaInicioOferta;
                Console.WriteLine("http://189.211.201.181:69/TalentoUAQWebService/api/tblofertasbusqueda/titulo/" + titulo + "/sueldoInicio/" + sueldoInicio + "/sueldoFin/" + sueldoFin + "/fechaInicioOferta/" + fechaInicioOferta + "/fechaFinOferta/0/cveEmpresa/0/cveTipoEmpleo/0/cveSubcategoria/0/cveMunicipio/0");
                Debug.Write("\nfechaDesde: [");
                Debug.Write(fechaInicioOferta);
                Debug.Write("\n]");
                Debug.Write("http://189.211.201.181:69/TalentoUAQWebService/api/tblofertasbusqueda/titulo/" + titulo + "/sueldoInicio/" + sueldoInicio + "/sueldoFin/" + sueldoFin + "/fechaInicioOferta/"+fechaInicioOferta+"/fechaFinOferta/0/cveEmpresa/0/cveTipoEmpleo/0/cveSubcategoria/0/cveMunicipio/0");
                var ofertasResp = await cliente.GetOfertas<ListaOfertas>("http://189.211.201.181:69/TalentoUAQWebService/api/tblofertasbusqueda/titulo/"+titulo+"/sueldoInicio/"+sueldoInicio+"/sueldoFin/"+sueldoFin+"/fechaInicioOferta/"+fechaInicioOferta+"/fechaFinOferta/0/cveEmpresa/0/cveTipoEmpleo/0/cveSubcategoria/0/cveMunicipio/0");
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
                                rangoSueldo = "$" + ofertax.sueldoInicio + " MXN - $" + ofertax.sueldoFin +" MXN",
                                nombreBoton = "Agregar a favoritos"
                            });
                        }
                        listaOfertas.ItemsSource = ofertas;
                        svOfertas.Content = listaOfertas;
                    } else{
                        etiquetaCargando.Text = "No se encontraron ofertas con los criterios seleccionados.";
                        svOfertas.Content = etiquetaCargando;
                    }
                } else{
                    etiquetaCargando.Text = "Error de conexión.";
                    svOfertas.Content = etiquetaCargando;
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

        public string fechaSQLaNormal(string fecha)
        {
            string[] fechaHoralNormal = fecha.Split('T');
            string[] fechaNormal = fechaHoralNormal[0].Split('-');
            return fechaNormal[2] + "/" + fechaNormal[1] + "/" + fechaNormal[0];
        }
    }
}
