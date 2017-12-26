using System;
using System.Collections.Generic;

namespace TalentoUAQ.Models
{
    public class Categorias
    {
        public Categorias()
        {
        }

        public int cveCategoria{
            get;
            set;
        }

        public string descCategoria{
            get;
            set;
        }

        public string activo{
            get;
            set;
        }

        public string fechaRegistro{
            get;
            set;
        }

        public string fechaActualizacion{
            get;
            set;
        }
    }

    public class ListaCategorias
    {
        public List<Categorias> listaCategorias { get; set; }
    }
}
