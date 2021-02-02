using Laboratorio_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Laboratorio_01.Controllers
{
    public class OperacionController : ApiController
    {
        public IHttpActionResult Post(Operacion op)
        {
            Operacion.Procesar(op);
            return Content(HttpStatusCode.Created, op);
        }
    }
}
