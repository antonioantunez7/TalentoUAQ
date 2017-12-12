using System;
using System.Collections.Generic;
using TalentoUAQ.Models;
using Xamarin.Forms;

namespace TalentoUAQ.Views
{
    public partial class Buscador : ContentPage
    {
        List<Categorias> categorias;
        List<Subcategorias> subcategorias;
        List<Salarios> salarios;
        List<Desde> desdes;
        public Buscador()
        {
            InitializeComponent();
            cargaCategorias();
            cargaSalarios();
            cargarDesde();
        }

        void cargaCategorias(){
            categorias = new List<Categorias>{
                new Categorias {cveCategoria = 1, descCategoria = "Ingeniería"},
                new Categorias {cveCategoria = 2, descCategoria = "Educación"},
                new Categorias {cveCategoria = 3, descCategoria = "Biología"}
            };
            cmbCategoria.Items.Clear();
            foreach(var categoria in categorias){
                cmbCategoria.Items.Add(categoria.descCategoria);    
            }
        }

        void seleccionaCategoria_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var posicion = cmbCategoria.SelectedIndex;
            if (posicion > -1)
            { 
                cargaSubcategorias(categorias[posicion].cveCategoria);
            }
        }

        void cargaSubcategorias(int cveCategoria){
            subcategorias = new List<Subcategorias>{ 
                new Subcategorias {cveSubcategoria = 1, descSubcategoria = "Computacion", cveCategoria = 1},
                new Subcategorias {cveSubcategoria = 2, descSubcategoria = "Redes", cveCategoria = 1},
                new Subcategorias {cveSubcategoria = 3, descSubcategoria = "Matematicas", cveCategoria = 2},
                new Subcategorias {cveSubcategoria = 4, descSubcategoria = "Quimica", cveCategoria = 2},
                new Subcategorias {cveSubcategoria = 5, descSubcategoria = "Fauna", cveCategoria = 3}
            };  
            cmbSubCategoria.Items.Clear();
            foreach(var subcategoria in subcategorias){
                if(subcategoria.cveCategoria == cveCategoria){
                    cmbSubCategoria.Items.Add(subcategoria.descSubcategoria);   
                }   
            }
        }

        async void buscarEmpleo_Clicked(object sender, System.EventArgs e)
        {
            //await DisplayAlert("Información", "Los datos son los siguientes", "Aceptar");
            string palabra = txtPalabra.Text;
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
                cveCategoria = categorias[posicionCveCategoria].cveCategoria;
                //await DisplayAlert("Información", categorias[posicionCveCategoria].cveCategoria+" "+categorias[posicionCveCategoria].descCategoria, "Aceptar");    
            }

            var posicionCveSubcategoria = cmbSubCategoria.SelectedIndex;
            int cveSubcategoria = 0;
            if (posicionCveSubcategoria > -1)
            {
                cveSubcategoria = subcategorias[posicionCveSubcategoria].cveSubcategoria;
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

            Ofertas oferta = new Ofertas
            {
                titulo = palabra,
                cveSubcategoria = cveSubcategoria,
                sueldoInicio = sueldoInicio,
                sueldoFin = sueldoFin
            };
            await Navigation.PushAsync(new OfertasView(oferta));
        }

        void cargaSalarios(){
            salarios = new List<Salarios>{
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
    }
}
