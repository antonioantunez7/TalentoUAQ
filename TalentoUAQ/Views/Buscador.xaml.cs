using System;
using System.Collections.Generic;
using System.Diagnostics;
using TalentoUAQ.Models;
using TalentoUAQ.Services;
using Xamarin.Forms;

namespace TalentoUAQ.Views
{
    public partial class Buscador : ContentPage
    {
        List<Categorias> lcategorias;
        List<Subcategorias> lsubcategorias;
        List<Salarios> salarios;
        List<Desde> desdes;
        List<Estados> lestados;
        public Buscador()
        {
            InitializeComponent();
            cargaEstados();
            cargaCategorias();
            cargaSalarios();
            cargarDesde();
        }

        async void cargaCategorias(){
            Device.BeginInvokeOnMainThread(async () =>
            {
                RestClient cliente = new RestClient();
                var categorias = await cliente.GetCategorias<ListaCategorias>("http://189.211.201.181:69/TalentoUAQWebService/api/tblcategorias");
                if(categorias != null){
                    if(categorias.listaCategorias.Count > 0){
                        lcategorias = new List<Categorias>();
                        lcategorias.Add(new Categorias
                        {
                            cveCategoria = 0,
                            descCategoria = "Todas"
                        });
                        foreach(var categoria in categorias.listaCategorias){
                            lcategorias.Add(new Categorias
                            {
                                cveCategoria = categoria.cveCategoria,
                                descCategoria = categoria.descCategoria
                            });    
                        }
                        cmbCategoria.Items.Clear();
                        foreach (var categoria in lcategorias)
                        {
                            cmbCategoria.Items.Add(categoria.descCategoria);
                        }
                    }    
                }
            }); 
        }

        /*async*/ void seleccionaEstado_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var posicion = cmbEstado.SelectedIndex;
            if (posicion > -1)
            { 
                //await DisplayAlert("Información", lestados[posicion].cveEstado + " " + lestados[posicion].descEstado, "Aceptar");
            }
        }

        async void seleccionaCategoria_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var posicion = cmbCategoria.SelectedIndex;
            if (posicion > -1)
            {
                //await DisplayAlert("Información", lcategorias[posicion].cveCategoria + " " + lcategorias[posicion].descCategoria, "Aceptar");
                cargaSubcategorias(lcategorias[posicion].cveCategoria);
            }
        }

        async void cargaSubcategorias(int cveCategoria){
            Device.BeginInvokeOnMainThread(async () =>
            {
                RestClient cliente = new RestClient();
                var subcategorias = await cliente.GetSubcategorias<ListaSubcategorias>("http://189.211.201.181:69/TalentoUAQWebService/api/tblsubcategorias/categoria?cveCategoria="+cveCategoria);
                if(subcategorias != null){
                    if(subcategorias.listaSubcategorias.Count > 0){
                        lsubcategorias = new List<Subcategorias>();
                        lsubcategorias.Add(new Subcategorias
                        {
                            cveSubcategoria = 0,
                            descSubcategoria = "Todas"
                        });
                        foreach(var subcategoria in subcategorias.listaSubcategorias){
                            lsubcategorias.Add(new Subcategorias
                            {
                                cveSubcategoria = subcategoria.cveSubcategoria,
                                descSubcategoria = subcategoria.descSubcategoria
                            });
                        }
                        cmbSubCategoria.Items.Clear();
                        foreach (var subcategoria in lsubcategorias)
                        {
                            cmbSubCategoria.Items.Add(subcategoria.descSubcategoria);
                        }
                    }    
                }
            });          

        }

        /*void cargaSubcategorias(int cveCategoria)
        {
            lsubcategorias = new List<Subcategorias>();
            lsubcategorias.Add(new Subcategorias
            {
                cveSubcategoria = 0,
                descSubcategoria = "Todas"
            });
            //Codigo por quitar y dejar el de arriba 
            if (cveCategoria == 17){//17:Tecnologías de la Información / Sistemas
                lsubcategorias.Add(new Subcategorias { cveSubcategoria = 232, descSubcategoria = "TELECOMUNICACIONES Y SISTEMAS MÓVILES" });
                lsubcategorias.Add(new Subcategorias { cveSubcategoria = 233, descSubcategoria = "ADMINISTRACIÓN DE BASES DE DATOS" });
                lsubcategorias.Add(new Subcategorias { cveSubcategoria = 234, descSubcategoria = "ADMINISTRACIÓN DE PROYECTOS DE TI" });
                lsubcategorias.Add(new Subcategorias { cveSubcategoria = 235, descSubcategoria = "ADMINISTRACIÓN DE SERVIDORES" });
                lsubcategorias.Add(new Subcategorias { cveSubcategoria = 239, descSubcategoria = "DESARROLLADOR / PROGRAMADOR DE SOFTWARE" });
                lsubcategorias.Add(new Subcategorias { cveSubcategoria = 240, descSubcategoria = "DESARROLLADOR / PROGRAMADOR WEB" });
                lsubcategorias.Add(new Subcategorias { cveSubcategoria = 251, descSubcategoria = "SISTEMAS INFORMÁTICOS" });
            }
            cmbSubCategoria.Items.Clear();
            foreach (var subcategoria in lsubcategorias)
            {
                cmbSubCategoria.Items.Add(subcategoria.descSubcategoria);
            }
        }*/

        async void buscarEmpleo_Clicked(object sender, System.EventArgs e)
        {
            //await DisplayAlert("Información", "Los datos son los siguientes", "Aceptar");
            string palabra = txtPalabra.Text;

            var posicionCveEstado = cmbEstado.SelectedIndex;
            int cveEstado = 0;
            if (posicionCveEstado > -1)
            {
                cveEstado = lestados[posicionCveEstado].cveEstado;
                //await DisplayAlert("Información", lestados[posicionCveEstado].cveEstado+" "+lestados[posicionCveEstado].descEstado, "Aceptar");    
            }
            //await DisplayAlert("Información", palabra, "Aceptar");
            var posicionIdDesde = cmbDesde.SelectedIndex;
            int numeroDiasDesde = 0;//Hace cuantos dias se publico la oferta
            if (posicionIdDesde > -1)
            {
                numeroDiasDesde = desdes[posicionIdDesde].numeroDias;
                //await DisplayAlert("desde", desdes[posicionIdDesde].idDesde + " " + desdes[posicionIdDesde].descripcion, "Aceptar");
            }
            var posicionCveCategoria = cmbCategoria.SelectedIndex;
            int cveCategoria = 0;
            if(posicionCveCategoria > -1){
                cveCategoria = lcategorias[posicionCveCategoria].cveCategoria;
                //await DisplayAlert("Información", categorias[posicionCveCategoria].cveCategoria+" "+categorias[posicionCveCategoria].descCategoria, "Aceptar");    
            }

            var posicionCveSubcategoria = cmbSubCategoria.SelectedIndex;
            int cveSubcategoria = 0;
            if (posicionCveSubcategoria > -1)
            {
                cveSubcategoria = lsubcategorias[posicionCveSubcategoria].cveSubcategoria;
                //await DisplayAlert("Información", subcategorias[posicionCveSubcategoria].cveSubcategoria + " " + subcategorias[posicionCveSubcategoria].descSubcategoria, "Aceptar");
            }
            var posicionSalario = cmbSalario.SelectedIndex;
            int sueldoInicio = 0;
            int sueldoFin = 0;
            if(posicionSalario > -1){
                sueldoInicio = salarios[posicionSalario].salarioInicio;
                sueldoFin = salarios[posicionSalario].salarioFin;
                //await DisplayAlert("Salario inicio", salarios[posicionSalario].salarioInicio+" "+salarios[posicionSalario].descripcionSalario, "Aceptar");           
                //await DisplayAlert("Salario fin", salarios[posicionSalario].salarioFin+" "+salarios[posicionSalario].descripcionSalario, "Aceptar");           
            }
            DateTime fecha_actual = DateTime.Today;
            string fechaInicioOferta = fecha_actual.ToString();
            fechaInicioOferta = this.fechaDateTimeaNormal(fechaInicioOferta);
            if(numeroDiasDesde != 0){
                DateTime fechaInicio = DateTime.Today.AddDays(-numeroDiasDesde);  
                fechaInicioOferta = fechaInicio.ToString();
                fechaInicioOferta = this.fechaDateTimeaNormal(fechaInicioOferta);
            }

            Ofertas oferta = new Ofertas
            {
                titulo = palabra,
                cveSubcategoria = cveSubcategoria,
                sueldoInicio = sueldoInicio,
                sueldoFin = sueldoFin,
                fechaInicioOferta = fechaInicioOferta,
                cveCategoria = cveCategoria,
                cveEstado = cveEstado
            };
            await Navigation.PushAsync(new OfertasView(oferta));
        }

        void cargaSalarios(){
            salarios = new List<Salarios>{
                new Salarios {idSalario = 0, salarioInicio = 0, salarioFin = 0, descripcionSalario = "Todos"},
                new Salarios {idSalario = 1, salarioInicio = 0, salarioFin = 5000, descripcionSalario = "$0 MXN - $5,000 MXN"},
                new Salarios {idSalario = 2, salarioInicio = 5000, salarioFin = 10000, descripcionSalario = "$5,000 MXN - $10,000 MXN"},
                new Salarios {idSalario = 3, salarioInicio = 10000, salarioFin = 15000, descripcionSalario = "$10,000 MXN - $15,000 MXN"},
                new Salarios {idSalario = 4, salarioInicio = 15000, salarioFin = 20000, descripcionSalario = "$15,000 MXN - $20,000 MXN"},
                new Salarios {idSalario = 5, salarioInicio = 20000, salarioFin = 30000, descripcionSalario = "$20,000 MXN - $30,000 MXN"},
                new Salarios {idSalario = 6, salarioInicio = 30000, salarioFin = 40000, descripcionSalario = "$30,000 MXN - $40,000 MXN"},
                new Salarios {idSalario = 7, salarioInicio = 40000, salarioFin = 50000, descripcionSalario = "$40,000 MXN - $50,000 MXN"},
                new Salarios {idSalario = 8, salarioInicio = 50000, salarioFin = 65000, descripcionSalario = "$50,000 MXN - $65,000 MXN"},
                new Salarios {idSalario = 9, salarioInicio = 65000, salarioFin = 80000, descripcionSalario = "$65,000 MXN - $80,000 MXN"},
                new Salarios {idSalario = 10, salarioInicio = 80000, descripcionSalario = "$80,000 MXN O MAS"}
            };
            cmbSalario.Items.Clear();
            foreach (var salario in salarios)
            {
                cmbSalario.Items.Add(salario.descripcionSalario);
            }    
        }

        /*async*/ void seleccionaSalario_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var posicionSalario = cmbSalario.SelectedIndex;
            if (posicionSalario > -1)
            {
                //await DisplayAlert("Información", salarios[posicionSalario].idSalario + " " + salarios[posicionSalario].descripcionSalario, "Aceptar");
            }
        }

        void cargarDesde(){
            desdes = new List<Desde>{
                new Desde {idDesde = 0, numeroDias = 0, descripcion = "Hoy"},
                new Desde {idDesde = 1, numeroDias = 1, descripcion = "Ayer"},
                new Desde {idDesde = 2, numeroDias = 2, descripcion = "Hace 2 días"},
                new Desde {idDesde = 3, numeroDias = 3, descripcion = "Hace 3 días"},
                new Desde {idDesde = 4, numeroDias = 4, descripcion = "Hace 4 días"},
                new Desde {idDesde = 5, numeroDias = 5, descripcion = "Hace 5 días"},
                new Desde {idDesde = 6, numeroDias = 6, descripcion = "Hace 6 días"},
                new Desde {idDesde = 7, numeroDias = 7, descripcion = "Hace 7 días"},
                new Desde {idDesde = 8, numeroDias = 14, descripcion = "Hace 14 días"},
                new Desde {idDesde = 9, numeroDias = 30, descripcion = "Hace 30 días"},
                new Desde {idDesde = 10, numeroDias = 60, descripcion = "Hace 60 días"},
            };
            cmbDesde.Items.Clear();
            foreach (var desde in desdes)
            {
                cmbDesde.Items.Add(desde.descripcion);
            } 
        }

        /*async*/ void seleccionaDesde_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var posicionDesde = cmbDesde.SelectedIndex;
            if (posicionDesde > -1)
            {
                //await DisplayAlert("Información", desdes[posicionDesde].idDesde + " " + desdes[posicionDesde].descripcion, "Aceptar");
            } 
        }

        public string fechaDateTimeaNormal(string fecha)
        {
            // 12/28/2017 12:00:00 a.m.
            string[] fechaMDA = fecha.Split(' ');
            string[] fechaNormal = fechaMDA[0].Split('/');
            string dia = fechaNormal[1];
            if(Convert.ToInt32(dia) < 10){
                dia = "0"+dia;    
            }
            string mes = fechaNormal[0];
            if (Convert.ToInt32(mes) < 10)
            {
                mes = "0" + mes;
            }
            string anio = fechaNormal[2];
            return dia + "-" + mes + "-" + anio;
        }

        async void cargaEstados()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                RestClient cliente = new RestClient();
                var estados = await cliente.GetEstados<ListaEstados>("http://189.211.201.181:69/TalentoUAQWebService/api/tblestados");
                if (estados != null)
                {
                    if (estados.listaEstados.Count > 0)
                    {
                        lestados = new List<Estados>();
                        lestados.Add(new Estados
                        {
                            cveEstado = 0,
                            descEstado = "Todos"
                        });
                        foreach (var estado in estados.listaEstados)
                        {
                            lestados.Add(new Estados
                            {
                                cveEstado = estado.cveEstado,
                                descEstado = estado.descEstado
                            });
                        }
                        cmbEstado.Items.Clear();
                        foreach (var estado in lestados)
                        {
                            cmbEstado.Items.Add(estado.descEstado);
                        }
                    }
                }
            });
        }
    }
}
