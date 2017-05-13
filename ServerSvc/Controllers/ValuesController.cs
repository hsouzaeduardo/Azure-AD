using ServerSvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerSvc.Controllers
{
    
    public class CidadesController : ApiController
    {
        // GET api/values
        //http://localhost:52706/api/cidades?nomeCidade=Capivari
        public Cidades Get(string nomeCidade)
        {
            return new Cidades() { Latitude = 10, Longitude = 20, Nome = nomeCidade, Populacao = "1.500.000", Temperatura = 19 };
        }
    }
}
