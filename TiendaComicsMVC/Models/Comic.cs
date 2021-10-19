using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaComicsMVC.Models
{
    public class Comic
    {
        //Clase diseñada para Colocar los datos que se estaran ocupando para el programa que seria el modelo Comic, estos vienen desde la base de datos
        public int id { set; get; }
        public int numepisodio { set; get; }
        public string nombre { set; get; }
        public string tipocomic { set; get; }
        public double costo { set; get; }
        public string editorial { set; get; }
        public string foto { set; get; }
    }
}