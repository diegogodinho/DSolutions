using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Dados
{
    public class SingletonDBContext
    {
        public ContextDB dbContext
        {
            get
            {
                //string ocKey = "key_" + HttpContext.Current.GetHashCode().ToString("x");
                //if (!HttpContext.Current.Items.Contains(ocKey))
                //    HttpContext.Current.Items.Add(ocKey, new ContextDB());
                //return HttpContext.Current.Items[ocKey] as ContextDB;
                return new ContextDB();
            }
        }
        private SingletonDBContext()
        {

        }
        private static Object obj = new object();

        private static SingletonDBContext _instance;

        public static SingletonDBContext Current
        {
            get
            {
                lock (obj)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonDBContext();
                    }
                }
                return _instance;
            }
        }

    }
}
