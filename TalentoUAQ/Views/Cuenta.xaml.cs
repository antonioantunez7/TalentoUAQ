﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TalentoUAQ.Models;
using Xamarin.Forms;

namespace TalentoUAQ.Views
{
    public partial class Cuenta : ContentPage
    {
        public ObservableCollection<Opciones> opciones { get; set; }
        public Cuenta(Usuarios usuario)
        {
            InitializeComponent();
            cargaDetalleCuenta(usuario);
            cargaOpciones();
        }

        void cargaDetalleCuenta(Usuarios usuario)
        {
            List<Usuarios> usuarios = new List<Usuarios>{
                new Usuarios { nombre = usuario.nombre+" "+usuario.paterno+" "+usuario.materno
                }
            };
            DetalleCuenta.ItemsSource = usuarios;
        }

        void cargaOpciones(){
            opciones = new ObservableCollection<Opciones>();
            //opciones.Add(new Opciones { idOpcion = 1, nombre = "Mis favoritos", detalle = "Sin detalle", icono = "acerca.png" });
            opciones.Add(new Opciones { idOpcion = 2, nombre = "Sugerencias", detalle = "Sin detalle", icono = "sugerencias.png" });
            opciones.Add(new Opciones { idOpcion = 3, nombre = "Acerca de", detalle = "Sin detalle", icono = "acerca.png" });
            opciones.Add(new Opciones { idOpcion = 4, nombre = "Cerrar sesion", detalle = "Sin detalle", icono = "salir.png" });
            listaOpciones.ItemsSource = opciones;
        }

        async void seleccionaOpcion_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var opcion = e.SelectedItem as Opciones;
            if (opcion != null)
            {
                if (opcion.idOpcion == 1)//1:Mis favoritos
                {
                    await Navigation.PushAsync(new Favoritos());
                } else if (opcion.idOpcion == 2)//2:Sugerencias
                {
                    await Navigation.PushAsync(new Sugerencias());
                } else if (opcion.idOpcion == 3)//3:Acerca de
                {
                    await Navigation.PushAsync(new AcercaDe());
                } else if (opcion.idOpcion == 4)//4:Salir
                {
                    var resp = await this.DisplayAlert("Confirmación", "¿Desea cerrar sesión?", "SI", "NO");
                    if (resp)
                    {
                        //Destruye las variables de sesión (persistencia de los datos)
                        if (Application.Current.Properties.ContainsKey("idUsuario")
                            && Application.Current.Properties.ContainsKey("nombre") 
                            && Application.Current.Properties.ContainsKey("paterno") 
                            && Application.Current.Properties.ContainsKey("materno")
                            && Application.Current.Properties.ContainsKey("idUsuarioExterno")
                            && Application.Current.Properties.ContainsKey("idAspirante"))
                        {
                            Application.Current.Properties.Remove("idUsuario");
                            Application.Current.Properties.Remove("nombre");
                            Application.Current.Properties.Remove("paterno");
                            Application.Current.Properties.Remove("materno");
                            Application.Current.Properties.Remove("idUsuarioExterno");
                            Application.Current.Properties.Remove("idAspirante");
                        }
                        Application.Current.MainPage = new NavigationPage(new Login());
                    }
                } else {
                    //await DisplayAlert("Información", opcion.nombre, "Aceptar");
                }
                listaOpciones.SelectedItem = null;//Para que automaticamente se deseleccione el elemento
            }     
        }
    }
}
