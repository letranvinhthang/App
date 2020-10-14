using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WPF_BanHang.Models;

namespace WPF_BanHang.Model
{
    public class DataProvider
    {
        private static DataProvider ins;
        public static DataProvider Ins
        {
            get
            {
                if (ins == null)
                    ins = new DataProvider();
                return ins;
            }
            set
            {
                ins = value;
            }
         }
    }
  
}
