using System;
using System.Linq;
using System.Collections.Generic;
using MVC5Course.ViewModels;
using System.Data.Entity;

namespace MVC5Course.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{
        public Product Find(int? id)
        {
            return this.All().FirstOrDefault(q => q.ProductId == id);
        }

        public Product FindProduct單筆資料(int? id)
        {
            return this.All().FirstOrDefault(q => q.ProductId == id);
        }

        public IQueryable<Product> getAllList(bool? Active)
        {
            return this.All().Where(p => p.Active.HasValue && p.Active.Value == Active).OrderByDescending(a => a.ProductId);
        }

        public IQueryable<ProductViewModel> getProductViewList()
        {
            //return this.All().Where(p => p.Active.HasValue && p.Active.Value == Active).OrderByDescending(a => a.ProductId);

            return this.All().Where(p => p.Active == true)
                     .Select(p => new ProductViewModel()
                     {
                         ProductId = p.ProductId,
                         Price = p.Price,
                         Stock = p.Stock,
                         ProductName = p.ProductName
                     }).Take(10);
        }

        public void Update(Product product)
        {
            this.UnitOfWork.Context.Entry(product).State = EntityState.Modified;
        }

        public override void Delete(Product entity)
        {
            entity.Is刪除 = true;
        }
    }

	public  interface IProductRepository : IRepository<Product>
	{

	}
}