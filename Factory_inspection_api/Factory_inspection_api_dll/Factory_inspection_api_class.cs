﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Factory_inspection_api;
using System.Threading.Tasks;
using Factory_inspection_api.Controllers;
using System.Net.Http;
using Helper;


namespace Factory_inspection_api
{
    public class Factory_inspection_api_class
    {

        public string erification(string username, string Password)
        {
            string erification_string;
            //Factory_inspection_api Factory_inspection_api = new Factory_inspection_api();
            Controllers.DefaultController defaultcontroller = new DefaultController();
            erification_string= Helper.Json.JsonHelper.SerializeObject(defaultcontroller.GetAllProducts());

            //foreach (var item in defaultcontroller.GetAllProducts())
            //{

            //}
            //erification_string = "";

            return erification_string;

        }

    }
}
