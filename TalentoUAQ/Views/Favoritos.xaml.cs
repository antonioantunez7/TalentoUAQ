using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TalentoUAQ.Models;
using TalentoUAQ.Services;
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
        async void cargaFavoritos()
        {
            etiquetaCargando.Text = "Cargando favoritos, por favor espere...";
            svFavoritos.Content = etiquetaCargando;
            Device.BeginInvokeOnMainThread(async () =>
            {
                RestClient cliente = new RestClient();
                var ofertasResp = await cliente.GetOfertas<ListaOfertas>("http://148.240.202.160:69/TalentoUAQWebService/api/tblofertas/favoritos/usuario/" + Application.Current.Properties["idUsuarioExterno"]);
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
                                fechaInicioOferta =ofertax.fechaInicioOferta,
                                //fechaInicioOferta = this.fechaSQLaNormal(ofertax.fechaInicioOferta),
                                descripcion = ofertax.descripcion,
                                rangoSueldo = "$" + ofertax.sueldoInicio + " MXN - $" + ofertax.sueldoFin + "MXN",
                                nombreBoton = "Eliminar de favoritos",
                                nombreEmpresa = ofertax.nombreEmpresa,
                                descCategoria = ofertax.descCategoria,
                                descSubcategoria = ofertax.descSubcategoria,
                                descTipoEmpleo = ofertax.descTipoEmpleo,
                                descMunicipioEstado = ofertax.descMunicipio + ", " + ofertax.descEstado,
                                telefonoContacto = ofertax.telefonoContacto,
                                nombreContacto = ofertax.nombreContacto,
                                idFavorito=ofertax.idFavorito
                            });
                        }
                        listaFavoritos.ItemsSource = ofertas;
                        svFavoritos.Content = listaFavoritos;
                    } else {
                        etiquetaCargando.Text = "Aún no tienes favoritos.";
                        svFavoritos.Content = etiquetaCargando;
                    }
                } else {
                    etiquetaCargando.Text = "Error de conexión.";
                    svFavoritos.Content = etiquetaCargando;
                }
            }); 
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
        protected override void OnAppearing()
        {
            base.OnAppearing();
            cargaFavoritos();
        }
    }
}
