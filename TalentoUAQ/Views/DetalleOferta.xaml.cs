using System;
using System.Collections.Generic;
using TalentoUAQ.Models;
using Xamarin.Forms;

namespace TalentoUAQ.Views
{
    public partial class DetalleOferta : ContentPage
    {
        string correoContacto;
        public DetalleOferta(Ofertas oferta)
        {
            InitializeComponent();
            cargaDetalleOferta(oferta);
        }

        void cargaDetalleOferta(Ofertas oferta)
        {
            List<Ofertas> ofertas = new List<Ofertas>{
                new Ofertas { titulo =oferta.titulo,
                    descripcion = oferta.descripcion,
                    sueldoInicio = oferta.sueldoInicio,
                    sueldoFin = oferta.sueldoFin,
                    rangoSueldo = oferta.rangoSueldo,
                    nombreBoton = oferta.nombreBoton,
                    fechaInicioOferta = oferta.fechaInicioOferta,
                    descMunicipioEstado = oferta.descMunicipioEstado,
                    descTipoEmpleo = oferta.descTipoEmpleo,
                    descCategoria = oferta.descCategoria,
                    descSubcategoria = oferta.descSubcategoria,
                    correoContacto = oferta.correoContacto,
                    telefonoContacto = oferta.telefonoContacto,
                    nombreContacto = oferta.nombreContacto
                }
            };
            correoContacto = oferta.correoContacto;
            DetalleDeLaOferta.ItemsSource = ofertas;
        }
        async void enviarCorrero(object sender, System.EventArgs e)
        {
            Device.OpenUri(new Uri("mailto:"+correoContacto));
        }
    }
}
