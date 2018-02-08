﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using TalentoUAQ.Models;
using TalentoUAQ.Services;
using Xamarin.Forms;

namespace TalentoUAQ.Views
{
    public partial class Curriculum : ContentPage
    {
        public ObservableCollection<Experiencias> experiencias { get; set; }
        public ObservableCollection<Estudios> escolaridades { get; set; }
        public ObservableCollection<IdiomasModel> idio { get; set; }
        public ObservableCollection<SubcategoriasUsuarios> subcategoriasUsuarios { get; set; }
        public Curriculum()
        {
            InitializeComponent();
            cargarGeneral();
            cargarSubcategorias();
        }

        public async void cargarGeneral() {
            Device.BeginInvokeOnMainThread(async () =>
            {
                RestClient cliente = new RestClient();
                System.Diagnostics.Debug.Write("**************************");
                System.Diagnostics.Debug.Write("http://189.211.201.181:69/TalentoUAQWebService/api/DatosGenerales/" + Application.Current.Properties["idAspirante"]);
                System.Diagnostics.Debug.Write("**************************");
                var curriculumGeneral = await cliente.GetCurriculumGeneral<ListaCurriculumGeneral>("http://189.211.201.181:69/TalentoUAQWebService/api/DatosGenerales/" + Application.Current.Properties["idAspirante"]);
                if (curriculumGeneral != null)
                {
                    if (curriculumGeneral.listaCurriculumGeneral.Count > 0)
                    {
                        foreach (var general in curriculumGeneral.listaCurriculumGeneral)
                        {
                            experiencias = new ObservableCollection<Experiencias>();
                            escolaridades = new ObservableCollection<Estudios>();
                            idio = new ObservableCollection<IdiomasModel>();
                            objetivo.Text = general.objetivo;
                            telefono.Text = general.telefono;
                            correo.Text = general.email;
                            sueldoDeseado.Text = general.sueldoDeseado;
                            foreach (var expe in general.tblexperiencias)
                            {
                                string fechaIn = "";
                                string fechaFi = "";
                                if (expe.fechaInicio != "" && expe.fechaInicio != null)
                                {
                                    fechaIn = fechaSQLaNormal(expe.fechaInicio);
                                }
                                else {
                                    fechaIn = expe.fechaInicio;
                                }
                                if (expe.fechaFin != "" && expe.fechaFin != null)
                                {
                                    fechaFi = fechaSQLaNormal(expe.fechaFin);
                                }
                                else
                                {
                                    fechaFi = expe.fechaFin;
                                }
                                experiencias.Add(new Experiencias {
                                    idExperiencia = expe.idExperiencia,
                                    cargo = expe.cargo,
                                    institucion= expe.institucion,
                                    fechaInicio = fechaIn,
                                    fechaFin = fechaFi
                                });
                            }
                            foreach (var edu in general.tblescolaridades) {
                                string fechaIn = "";
                                string fechaFi = "";
                                if (edu.fechaInicio != "" && edu.fechaInicio != null)
                                {
                                    fechaIn = fechaSQLaNormal(edu.fechaInicio);
                                }
                                else
                                {
                                    fechaIn = edu.fechaInicio;
                                }
                                if (edu.fechaFin != "" && edu.fechaFin != null)
                                {
                                    fechaFi = fechaSQLaNormal(edu.fechaFin);
                                }
                                else
                                {
                                    fechaFi = edu.fechaFin;
                                }
                                escolaridades.Add(new Estudios {
                                    idEscolaridad=edu.idEscolaridad,
                                    fechaInicio= fechaIn,
                                    escuela=edu.escuela,
                                    carrera=edu.carrera,
                                    fechaFin= fechaFi
                                });
                            }
                            foreach (var idi in general.tblidiomas)
                            {
                                idio.Add(new IdiomasModel
                                {
                                    idioma=idi.idioma,
                                    idIdioma=idi.idIdioma,
                                    porcentaje=idi.porcentaje
                                });
                            }
                            Double totalExperiencias = 80 * experiencias.Count;
                            ListaExperiencia.HeightRequest = totalExperiencias;
                            Double totalEstudios = 80 * escolaridades.Count;
                            ListaEstudios.HeightRequest = totalEstudios;
                            Double totalIdiomas = 35 * idio.Count;
                            ListaIdiomas.HeightRequest = totalIdiomas;
                            ListaExperiencia.ItemsSource = experiencias;
                            ListaEstudios.ItemsSource = escolaridades;
                            ListaIdiomas.ItemsSource = idio;
                        }
                        
                    }
                }
                
            });
        }
        void cargarSubcategorias()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                RestClient cliente = new RestClient();
                var subcategoriasUsuariosTodas = await cliente.GetSubcategoriasUsuarios<ListaSubcategoriasUsuarios>("http://189.211.201.181:69/TalentoUAQWebService/api/subcategoriasusuario/" + Application.Current.Properties["idUsuarioExterno"]);
                if (subcategoriasUsuariosTodas != null)
                {
                    if (subcategoriasUsuariosTodas.listaSubcategoriasUsuarios.Count > 0)
                    {
                        subcategoriasUsuarios = new ObservableCollection<SubcategoriasUsuarios>();
                        foreach (var scu in subcategoriasUsuariosTodas.listaSubcategoriasUsuarios) {
                            subcategoriasUsuarios.Add(new SubcategoriasUsuarios {
                                idSubcategoriaUsuario = scu.idSubcategoriaUsuario,
                                descSubcategoria = scu.descSubcategoria,
                            });
                        }
                        int totalSubcategorias = subcategoriasUsuarios.Count;
                        Double total = 35 * totalSubcategorias;
                        ListaSubcategoriasUsuarios.HeightRequest = total;
                        ListaSubcategoriasUsuarios.ItemsSource = subcategoriasUsuarios;
                    }
                }
            });
            
        }
        async void agregarModalDescripcion(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new DetalleCurriculum());
        }
        async void agregarModalEspecialidad(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new AreaEspecialidad());
        }
        async void agregarModalExperiencia(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Experiencia());
        }
        async void agregarModalEducacion(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Educacion());
        }
        async void agregarModalIdiomas(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Idiomas());
        }
        async void eliminarEspecialidad_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var subcategoriaUsuario = e.SelectedItem as SubcategoriasUsuarios;
            var answer = await DisplayAlert("Confirmar", "¿Deseas Eliminar esta especialidad?", "Si", "No");
            if (answer) {
                HttpClient cliente = new HttpClient();
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("idSubcategoriaUsuario", subcategoriaUsuario.idSubcategoriaUsuario.ToString()),
                    new KeyValuePair<string, string>("activo","N"),
                });
                var myHttpClient = new HttpClient();
                var response = await myHttpClient.PostAsync("http://189.211.201.181:69/TalentoUAQWebService/api/subcategoriasusuario/guardar", formContent);
                var json = await response.Content.ReadAsStringAsync();
                //await DisplayAlert("Mensaje", json, "Aceptar");
                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Mensaje", "Registro Eliminado", "Aceptar");
                    cargarGeneral();
                    cargarSubcategorias();
                }
                else
                {
                    await DisplayAlert("Error", "Algo Salio Mal", "Aceptar");
                }
            }
        }
        async void verEstudio(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var estudio = e.SelectedItem as Estudios;
            var answer = await DisplayAlert("Confirmar", "Desea Eliminar el Estudio", "Si", "No");
            if (answer) {
                HttpClient cliente = new HttpClient();
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("idAspirante", Application.Current.Properties["idAspirante"].ToString()),
                    new KeyValuePair<string, string>("idEscolaridad", estudio.idEscolaridad.ToString()),
                    new KeyValuePair<string, string>("activo","N"),
                });

                var myHttpClient = new HttpClient();
                var response = await myHttpClient.PostAsync("http://189.211.201.181:69/TalentoUAQWebService/api/escolaridades/guardar", formContent);

                var json = await response.Content.ReadAsStringAsync();
                //await DisplayAlert("Mensaje", json, "Aceptar");
                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Mensaje", "Registro Eliminado", "Aceptar");
                    cargarGeneral();
                }
                else
                {
                    await DisplayAlert("Error", "Algo Salio Mal", "Aceptar");
                }
                
            }
        }
        async void verExperiencia(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var exp = e.SelectedItem as Experiencias;
            var answer = await DisplayAlert("Confirmar", "¿Deseas Eliminar esta Experiencia?", "Si", "No");
            if (answer)
            {
                HttpClient cliente = new HttpClient();
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("idAspirante", Application.Current.Properties["idAspirante"].ToString()),
                    new KeyValuePair<string, string>("idExperiencia", exp.idExperiencia.ToString()),
                    new KeyValuePair<string, string>("activo","N"),
                });

                var myHttpClient = new HttpClient();
                var response = await myHttpClient.PostAsync("http://189.211.201.181:69/TalentoUAQWebService/api/experiencias/guardar", formContent);

                var json = await response.Content.ReadAsStringAsync();
                await DisplayAlert("Mensaje", json, "Aceptar");
                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Mensaje", "Registro Eliminado", "Aceptar");
                    cargarGeneral();
                }
                else
                {
                    await DisplayAlert("Error", "Algo Salio Mal", "Aceptar");
                }

            }
        }
        async void verIdiomas(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var idio = e.SelectedItem as IdiomasModel;
            var answer = await DisplayAlert("Confirmar", "¿Deseas Eliminar este Idioma?", "Si", "No");
            if (answer)
            {
                HttpClient cliente = new HttpClient();
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("idAspirante", Application.Current.Properties["idAspirante"].ToString()),
                    new KeyValuePair<string, string>("idIdioma", idio.idIdioma.ToString()),
                    new KeyValuePair<string, string>("activo","N"),
                });

                var myHttpClient = new HttpClient();
                var response = await myHttpClient.PostAsync("http://189.211.201.181:69/TalentoUAQWebService/api/idiomas/guardar", formContent);

                var json = await response.Content.ReadAsStringAsync();
                await DisplayAlert("Mensaje", json, "Aceptar");
                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Mensaje", "Registro Eliminado", "Aceptar");
                    cargarGeneral();
                }
                else
                {
                    await DisplayAlert("Error", "Algo Salio Mal", "Aceptar");
                }

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
