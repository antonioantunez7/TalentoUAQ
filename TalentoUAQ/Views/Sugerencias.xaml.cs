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
            etiquetaCargando.Text = "Cargando sugerencias, por favor espere...";
            svSugerencias.Content = etiquetaCargando;

            Device.BeginInvokeOnMainThread(async () =>
            {
                RestClient cliente = new RestClient();

                var ofertasResp = await cliente.GetOfertas<ListaOfertas>("http://189.211.201.181:69/TalentoUAQWebService/api/sugerencias/"+ Application.Current.Properties["idUsuarioExterno"]);
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
                                fechaInicioOferta = this.fechaSQLaNormalSH(ofertax.fechaInicioOferta),
                                //fechaInicioOferta = this.fechaSQLaNormal(ofertax.fechaInicioOferta),
                                descripcion = ofertax.descripcion,
                                rangoSueldo = "$" + ofertax.sueldoInicio + " MXN - $" + ofertax.sueldoFin + " MXN",
                                nombreBoton = "Agregar a favoritos",
                                nombreEmpresa = ofertax.nombreEmpresa,
                                descCategoria = ofertax.descCategoria,
                                descSubcategoria = ofertax.descSubcategoria,
                                descTipoEmpleo = ofertax.descTipoEmpleo,
                                descMunicipioEstado = ofertax.descMunicipio + ", " + ofertax.descEstado,
                                telefonoContacto = ofertax.telefonoContacto,
                                nombreContacto = ofertax.nombreContacto,
                                idOferta = ofertax.idOferta
                            });
                        }
                        listaSugerencias.ItemsSource = ofertas;
                        svSugerencias.Content = listaSugerencias;
                    } else {
                        etiquetaCargando.Text = "No se encontraron sugerencias.";
                        svSugerencias.Content = etiquetaCargando;
                    }
                } else {
                    etiquetaCargando.Text = "Error de conexión.";
                    svSugerencias.Content = etiquetaCargando;
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

        public string fechaSQLaNormalSH(string fecha)
        {
            string[] fechaHoralNormal = fecha.Split(' ');
            return fechaHoralNormal[0];
        }
    }
}
