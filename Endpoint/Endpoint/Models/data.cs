using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Endpoint.Models
{
    public class Response
    {
        public string number { get; set; }
        public string text { get; set; }


        public List<Response> data()
        {
            Response res = new Response();

            res.number = "";
            res.text = "";
            
            List<Response> data = new List<Response>();

            data.Add(res);

            return data;

        }

     }

}