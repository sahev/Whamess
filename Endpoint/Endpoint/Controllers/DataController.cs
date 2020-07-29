using Endpoint.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;

namespace Endpoint.Controllers
{
     
    public class DataController : ApiController
    {
        public HttpResponseMessage Post(Response response)
        {
            
            List<Response> res = new List<Response>();

            res.Add(response);

            string number = response.number;
            string text = response.text;
            
            try
            {
                if (number.Length != 13)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { error = "Numero invalido!" });
                }
                if (text == "")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { error = "Insira uma mensagem!" });
                }

                Runcmdline execute = new Runcmdline();
                execute.executesend(number, text);
                return Request.CreateResponse(HttpStatusCode.OK, new { success = "Mensagem enviada!" });
            }

            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

        }

    }

}



