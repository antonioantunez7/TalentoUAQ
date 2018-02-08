using System;
using System.Collections.Generic;

namespace TalentoUAQ.Models
{
    public class Ofertas
    {
        public Ofertas()
        {
        }

        public int idOferta
        {
            get;
            set;
        }

        public string titulo
        {
            get;
            set;
        }

        public string descripcion
        {
            get;
            set;
        }

        public int sueldoInicio
        {
            get;
            set;
        }

        public int sueldoFin
        {
            get;
            set;
        }

        public string fechaInicioOferta
        {
            get;
            set;
        }

        public string fechaFinOferta
        {
            get;
            set;
        }

        public int cveEmpresa
        {
            get;
            set;
        }

        public string nombreContacto
        {
            get;
            set;
        }

        public string correoContacto
        {
            get;
            set;
        }

        public string telefonoContacto
        {
            get;
            set;
        }

        public int cveTipoEmpleo
        {
            get;
            set;
        }

        public int cveSubcategoria
        {
            get;
            set;
        }

        public int cveMunicipio
        {
            get;
            set;
        }

        //Auxiliares para poder consultar
        public string rangoSueldo
        {
            get;
            set;
        }

        public string nombreBoton
        {
            get;
            set;
        }

        public int cveEstado
        {
            get;
            set;
        }

        public int cveCategoria
        {
            get;
            set;
        }

        public string descTipoEmpleo{
            get;
            set;
        }

        public string descMunicipioEstado{
            get;
            set;
        }

        public string descCategoria{
            get;
            set;
        }

        public string descSubcategoria{
            get;
            set;
        }

        public string nombreEmpresa{
            get;
            set;
        }

        public string descMunicipio{
            get;
            set;
        }

        public string descEstado{
            get;
            set;
        }
        public string idFavorito { get; internal set; }
    }

    public class ListaOfertas
    {
        public List<Ofertas> listaOfertas { get; set; }
    }
}
