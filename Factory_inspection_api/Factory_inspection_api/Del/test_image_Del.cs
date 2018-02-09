using Factory_inspection_api.Context_base;
using Factory_inspection_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factory_inspection_api.Del
{  
    public class test_image_Del 
    {

        protected internal DbContext_base db;
        public List<test_image_Midels> GetList(string JOB_no)
        {     
            try
            {
                return db.test_image_Midels.Where(d => d.job_no == JOB_no).Select(e => e).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

    }
}