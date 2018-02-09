using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Text;
using System.Reflection;
using System.Net.Http.Headers;
using System.IO;

namespace Factory_inspection_api.Controllers
{
    public class testapiController : ApiController
    {

        public static bool image_upload( byte[] image)
        {
            //var resp = new HttpResponseMessage(HttpStatusCode.OK);
            
            return true;
        }

        //public static byte[] image_download(string job_no)
        //{


        //    byte[] image_no = image_download;

        //    return image_no;
        //}

    }
}
