using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "請輸入商品名稱")]
        [MaxLength(30), MinLength(3)]
        [RegularExpression("(.+)-(.+)", ErrorMessage = "必須輸入-號")]
        public string ProductName { get; set; }
        [Required]
        [Range(0, 9999, ErrorMessage = "請輸入正確數值")]
        public Nullable<decimal> Price { get; set; }
        [Required]
        public Nullable<decimal> Stock { get; set; }
    }
}