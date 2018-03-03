using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using TalentoUAQ.Models;
using TalentoUAQ.Services;
using Xamarin.Forms;

namespace TalentoUAQ.Views
{
    public partial class DetalleCurriculum : ContentPage
    {
        public DetalleCurriculum()
        {
            InitializeComponent();
            cargarDatos();
        }
        public async void cargarDatos()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                RestClient cliente = new RestClient();
                var curriculumGeneral = await cliente.GetCurriculumGeneral<CurriculumGeneral>("http://148.240.202.160:69/TalentoUAQWebService/api/DatosGenerales/" + Application.Current.Properties["idAspirante"]);
                if (curriculumGeneral != null)
                {
                    if (curriculumGeneral.idUsuarioExterno != "")
                    {
                        salarioDeseado.Text = curriculumGeneral.sueldoDeseado;
                        txtTelefono.Text = curriculumGeneral.telefono;
                        correo.Text = curriculumGeneral.email;
                        txtObjetivo.Text = curriculumGeneral.objetivo;
                    }
                }
            });
        }
        async void guardarModal(object sender, EventArgs args)
        {
            string telefono = txtTelefono.Text;
            string email = correo.Text;
            string objetivo = txtObjetivo.Text;
            string sueldoDeseado = salarioDeseado.Text;
            bool error = false;
            if (string.IsNullOrEmpty(telefono))
            {
                await DisplayAlert("Error", "Coloca el Telefono", "Aceptar");
                error = true;
            }
            if (!telefono.ToCharArray().All(Char.IsDigit))
            {
                await DisplayAlert("Error", "El telefono debe ser numerico", "Back");
                error = true;
            }

            if (string.IsNullOrEmpty(email))
            {
                await DisplayAlert("Error", "Coloca el Correo", "Aceptar");
                error = true;
            }
            var regex = new System.Text.RegularExpressions.Regex(@"\S+@\S+\.\S+");
            if (!regex.IsMatch(email))
            {
                await DisplayAlert("Error", "El formato del correo no es correcto", "Back");
                return;
            }
            if (string.IsNullOrEmpty(sueldoDeseado))
            {
                await DisplayAlert("Error", "Coloca el Sueldo Deseado", "Aceptar");
                error = true;
            }
            if (!sueldoDeseado.ToCharArray().All(Char.IsDigit))
            {
                await DisplayAlert("Error", "El Sueldo deseado debe ser numerico", "Back");
                error = true;
            }
            if (string.IsNullOrEmpty(objetivo))
            {
                await DisplayAlert("Error", "Coloca el Objetivo Profesional", "Aceptar");
                error = true;
            }
            if (!error)
            {
                HttpClient cliente = new HttpClient();
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("idAspirante", Application.Current.Properties["idAspirante"].ToString()),
                    new KeyValuePair<string, string>("objetivo",objetivo),
                    new KeyValuePair<string, string>("telefono",telefono),
                    new KeyValuePair<string, string>("sueldoDeseado",sueldoDeseado),
                    new KeyValuePair<string, string>("email",email),
                });

                var myHttpClient = new HttpClient();
                var response = await myHttpClient.PostAsync("http://148.240.202.160:69/TalentoUAQWebService/api/aspirantes/guardar", formContent);

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
