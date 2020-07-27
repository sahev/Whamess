using Endpoint.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.EnterpriseServices;

namespace Endpoint.Controllers
{
     
    public class DataController : ApiController
    {

        public List<Response> Post(Response response)
        {

            List<Response> res = new List<Response>();
            res.Add(response);

            string number = response.number;
            string text = response.text;

            Runcmdline execute = new Runcmdline();
            
            execute.executesend(number, text);

            return res;

        }

    }
}



