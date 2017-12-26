using System;
using System.Collections.Generic;

namespace TalentoUAQ.Models
{
    public class Subcategorias
    {
        public Subcategorias()
        {
        }

        public int cveSubcategoria
        {
            get;
            set;
        }

        public string descSubcategoria
        {
            get;
            set;
        }

        public int cveCategoria{
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

    public class ListaSubcategorias
    {
        public List<Subcategorias> listaSubcategorias { get; set; }
    }

}
