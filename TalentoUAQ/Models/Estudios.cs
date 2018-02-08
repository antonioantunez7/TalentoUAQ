using System;
using System.Collections.Generic;

namespace TalentoUAQ.Models
{
    public class Estudios
    {
        public Estudios()
        {
        }

        public string idEscolaridad { get;set;}
        public string idAspirante { get;set;}
        public string escuela { get;set;}
        public string carrera { get; set;}
        public string fechaInicio { get;set;}
        public string fechaFin{get;set;}
        public string activo{get;set;}
        public string fechaRegistro{get;set;}
        public string fechaActualizacion { get; set; }
    }

    public class ListaEstudios
    {
        public List<Estudios> listaEstudios { get; set; }
    }

}
