using System;
using System.Collections.Generic;

namespace TalentoUAQ.Models
{
    public class SubcategoriasUsuarios
    {
        public SubcategoriasUsuarios()
        {
        }

        public int idSubcategoriaUsuario
        {
            get;
            set;
        }

        public int cveSubcategoria
        {
            get;
            set;
        }

        public int idUsuarioExterno
        {
            get;
            set;
        }

        public string descSubcategoria
        {
            get;
            set;
        }

        public string activo
        {
            get;
            set;
        }

        public string fechaRegistro
        {
            get;
            set;
        }

        public string fechaActualizacion
        {
            get;
            set;
        }
    }

    public class ListaSubcategoriasUsuarios
    {
        public List<SubcategoriasUsuarios> listaSubcategoriasUsuarios { get; set; }
    }
}
