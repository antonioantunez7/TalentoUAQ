using System;
namespace TalentoUAQ.Models
{
    public class Ofertas
    {
        public Ofertas()
        {
        }

        public int idOferta{
            get;
            set;
        }

        public string titulo{
            get;
            set;
        }

        public string descripcion{
            get;
            set;
        }

        public int sueldoInicio{
            get;
            set;
        }

        public int sueldoFin{
            get;
            set;
        }

        public string fechaInicioOferta{
            get;
            set;
        }

        public string fechaFinOferta{
            get;
            set;
        }

        public int cveEmpresa{
            get;
            set;
        }

        public string nombreContacto{
            get;
            set;
        }

        public string correoContacto{
            get;
            set;
        }

        public string telefonoContacto{
            get;
            set;
        }

        public int cveTipoEmpleo{
            get;
            set;
        }

        public int cveSubcategoria{
            get;
            set;
        }

        public int cveMunicipio{
            get;
            set;
        }

    }
}
