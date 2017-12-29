using System;
using System.Collections.Generic;

namespace TalentoUAQ.Models
{
    public class Experiencias
    {
        public Experiencias()
        {
        }

        public int idExperiencia
        {
            get;
            set;
        }

        public string idAspirante
        {
            get;
            set;
        }

        public string empresa
        {
            get;
            set;
        }

        public string puesto
        {
            get;
            set;
        }

        public string fechaInicio
        {
            get;
            set;
        }

        public string fechaFin
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

    public class ListaExperiencias
    {
        public List<Experiencias> listaExperiencias { get; set; }
    }

}
