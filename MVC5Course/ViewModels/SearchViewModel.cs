using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.ViewModels
{
    public class SearchViewModel : IValidatableObject
    {
        public  SearchViewModel(){
            this.min = 0;
            this.max = 9999;
            
            }

        public string q { get; set; }

        [Range(0, 9999, ErrorMessage = "請輸入正確數值")]
        public int min { get; set; }
        [Range(0, 9999, ErrorMessage = "請輸入正確數值")]
        public int max { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.min > this.max)
            {
                yield return new ValidationResult("請輸入正確數值", new string[] { "min,max" });
            }
            yield break;
        }
    }
}