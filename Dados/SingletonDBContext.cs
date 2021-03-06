﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public class SingletonDBContext
    {
        public ContextDB dbContext
        {
            get;
            private set;
        }
        private SingletonDBContext()
        {
            dbContext = new ContextDB();
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
