using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirstWebApi.Controllers
{
    public class EmptyAPIController : ApiController
    {
        List<string> strings = new List<string> { "value1", "value2", "value3" };
        // GET: api/EmptyAPI
        [HttpGet]
        public List<string> GetStrings()
        {
            return strings;
        }
        //public HttpResponseMessage GetValues()
        //{
        //    var resp = Request.CreateResponse<ApiMessageError>(
        //        HttpStatusCode.BadRequest,
        //        new ApiMessageError("Your code stinks!"));
        //    return resp;
        //}
    }
}
