﻿using System;
using System.Collections.Generic;

namespace TalentoUAQ.Models
{
    public class CurriculumGeneral
    {
        public CurriculumGeneral()
        {
        }

        public string idAspirante{get;set;}
        public string idUsuarioExterno { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string objetivo { get; set; }
        public string sueldoDeseado { get; set; }
        public string activo { get; set; }
        public string fechaRegistro { get; set; }
        public string fechaActualizacion { get; set; }
        public List<Estudios> tblescolaridades { get; set; }
        public List<Experiencias> tblexperiencias { get; set; }
        public List<IdiomasModel> tblidiomas { get; set; }
    }
    public class ListaCurriculumGeneral
    {
        public List<CurriculumGeneral> listaCurriculumGeneral { get; set; }
    }

}
