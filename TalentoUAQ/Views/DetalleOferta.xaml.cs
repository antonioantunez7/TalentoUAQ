using System;
using System.Collections.Generic;
using System.Net.Http;
using TalentoUAQ.Models;
using Xamarin.Forms;

namespace TalentoUAQ.Views
{
    public partial class DetalleOferta : ContentPage
    {
        string correoContacto;
        string idFavorito;
        string idOferta;
        string idUsuarioExterno;
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
                    nombreContacto = oferta.nombreContacto,
                    idFavorito=oferta.idFavorito,
                    idOferta=oferta.idOferta
                }
            };
            idFavorito = oferta.idFavorito;
            idOferta = oferta.idOferta.ToString();
            idUsuarioExterno= Application.Current.Properties["idUsuarioExterno"].ToString();
            correoContacto = oferta.correoContacto;
            DetalleDeLaOferta.ItemsSource = ofertas;
        }
        async void enviarCorrero(object sender, System.EventArgs e)
        {
            Device.OpenUri(new Uri("mailto:"+correoContacto));
        }
        async void AgregarEliminar(object sender, System.EventArgs e)
        {
            Button button = (Button)sender;
            var answer = await DisplayAlert("Correcto", "Estas Seguro de "+button.Text, "Si","No");
            if (answer) {
                if (button.Text == "Eliminar de favoritos") {
                    System.Diagnostics.Debug.Write("mames",idFavorito);
                    HttpClient cliente = new HttpClient();
                    var formContent = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("idFavorito",idFavorito),
                        new KeyValuePair<string, string>("activo","N"),
                    });

                    var myHttpClient = new HttpClient();
                    var response = await myHttpClient.PostAsync("http://148.240.202.160:69/TalentoUAQWebService/api/favoritos/guardar", formContent);

                    var json = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        await DisplayAlert("Correcto", "Se eliminó el Registro", "Aceptar");
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert("Error", "Algo Salio Mal", "Aceptar");
                    }
                }
                else{
                    HttpClient cliente = new HttpClient();
                    var formContent = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("idOferta",idOferta),
                        new KeyValuePair<string, string>("idUsuarioExterno",idUsuarioExterno),
                        new KeyValuePair<string, string>("activo","S")
                    });

                    var myHttpClient = new HttpClient();
                    var response = await myHttpClient.PostAsync("http://148.240.202.160:69/TalentoUAQWebService/api/favoritos/guardar", formContent);

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
}
