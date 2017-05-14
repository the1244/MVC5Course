namespace MVC5Course.Models
{
    using Attribute;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(ProductMetaData))]
    public partial class Product : IValidatableObject
    {
        public int 訂單數量
        {
            get {return this.OrderLine.Count;}
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if (this.Price > 100 && this.Stock > 5)
            {
                yield return new ValidationResult("Price < 100 Stock < 5", new string[] { "Pricr,Stock" });
            }
            yield break;
        }
    }
    
    public partial class ProductMetaData
    {
        [Required]
        public int ProductId { get; set; }
        [DisplayName("商品名稱")]
        [商品名稱必須包含aaa字串(ErrorMessage ="必須包含aaa")]
        [StringLength(80, ErrorMessage="欄位長度不得大於 80 個字元")]
        public string ProductName { get; set; }
        [DisplayFormat(DataFormatString ="{0:0}")]
        public Nullable<decimal> Price { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<decimal> Stock { get; set; }
    
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }


}
