﻿using Shop.Data.Infrastructure;
using WebDemo.Models;

namespace Shop.Data.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
    }

    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        //public IEnumerable<Product> GetListProductByTag(string tagId, int page, int pageSize, out int totalRow)
        //{
        //    //var query = from p in DbContext.Products
        //    //            join pt in DbContext.ProductTags
        //    //            on p.ID equals pt.ProductID
        //    //            where pt.TagID == tagId
        //    //            select p;
        //    //totalRow = query.Count();

        //    //return query.OrderByDescending(x => x.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize);
        //}
    }
}