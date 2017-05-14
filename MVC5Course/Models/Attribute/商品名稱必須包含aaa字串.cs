using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models.Attribute
{
    public class 商品名稱必須包含aaa字串 : DataTypeAttribute
    {
        public 商品名稱必須包含aaa字串() : base(DataType.Text)
        {

        }

        public override bool IsValid(object obj)
        {
            string str = (string)obj;
            return str.Contains("aaa");
        }
    }
}