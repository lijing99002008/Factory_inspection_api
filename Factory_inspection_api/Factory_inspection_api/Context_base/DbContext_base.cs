using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Helper;
using Factory_inspection_api.Models;

namespace Factory_inspection_api.Context_base
{
    public class DbContext_base : DbContext
    {
        public DbContext_base() : base(GetConnStr())
        {

            //((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 300;//设置超时时间(未测试)

            //Database.SetInitializer(new Initializer());//执行这名就会执行初始化器
            //Database.SetInitializer<Context>(new DropCreateDatabaseIfModelChanges<Context>());
        }

        #region 生成表的部分

        public virtual DbSet<test_image_Midels> test_image_Midels { get; set; }

        #endregion



        #region 解密后得到连接字符串
        /// <summary>
        /// 得到解密后的连接字符串
        /// </summary>
        /// <returns>返回解密后的连接字符串</returns>
        private static string GetConnStr()
        {



            //Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ////根据Key读取<connectionString>元素的Value
            //string name = config.AppSettings.Settings["connectionString"].Value;

            //string name=ConfigurationSettings.AppSettings["connectionString"];

            string name = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
            string connstr = Helper.DEncrypt.Security.DecryptDES(name);

            return connstr;

        }
        #endregion
    }
}