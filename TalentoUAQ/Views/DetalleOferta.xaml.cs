using System;
using System.Collections.Generic;
using TalentoUAQ.Models;
using Xamarin.Forms;

namespace TalentoUAQ.Views
{
    public partial class DetalleOferta : ContentPage
    {
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
                    sueldoFin = oferta.sueldoFin
                }
            };
            DetalleDeLaOferta.ItemsSource = ofertas;
        }
    }
}
