using System;
using System.Collections.Generic;

namespace TalentoUAQ.Models
{
    public class Estados
    {
        public Estados()
        {
        }

        public int cveEstado{
            get;
            set;
        }

        public string descEstado{
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

    public class ListaEstados
    {
        public List<Estados> listaEstados { get; set; }
    }
}
