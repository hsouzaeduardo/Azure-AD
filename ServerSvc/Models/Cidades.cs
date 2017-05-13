using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerSvc.Models
{
    public class Cidades
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Temperatura { get; set; }
        public string Nome { get; set; }
        public string Populacao { get; set; }
    }
}