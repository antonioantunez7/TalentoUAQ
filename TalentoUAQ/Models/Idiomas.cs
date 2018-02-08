using System;
using System.Collections.Generic;

namespace TalentoUAQ.Models
{
    public class IdiomasModel
    {
        public IdiomasModel()
        {
        }

        public string idIdioma{get;set;}
        public string idAspirante{get;set;}
        public string idioma{get;set;}
        public string porcentaje{get;set;}
        public string activo{get;set;}
        public string fechaRegistro{get;set;}
        public string fechaActualizacion{get;set;}
    }

    public class ListaIdiomas
    {
        public List<IdiomasModel> listaIdiomas { get; set; }
    }

}
