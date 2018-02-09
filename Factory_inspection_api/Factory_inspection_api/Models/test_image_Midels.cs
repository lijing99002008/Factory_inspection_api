using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Factory_inspection_api.Models
{
    public class test_image_Midels
    {

            /// <summary>
            /// id
            /// </summary>
            public int Id { get; set; }
            /// <summary>
            /// 工单号
            /// </summary>      
            public string job_no { get; set; }

            /// <summary>
            /// 检验号
            /// </summary>
            public string test_no { get; set; }

            /// <summary>
            /// 疵点图
            /// </summary>
            public string image { get; set; }
            
        }
        public class test_detail_imageMap : EntityTypeConfiguration<test_image_Midels>
        {
            public test_detail_imageMap()
            {
                //定义主键
                this.HasKey(t => new { t.Id});






            }
        
    }
}