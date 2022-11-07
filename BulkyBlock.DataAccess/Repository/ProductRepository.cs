using BulkyBlock.DataAccess.Repository.IRepository;
using BulkyBlock.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBlock.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
           
        }
       

        public void Update(Product category)
        {
            var objFromDb = _db.Products.FirstOrDefault(u=>u.Id==category.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = category.Title;
                objFromDb.Description = category.Description;
                objFromDb.Price = category.Price;
                objFromDb.CategoryId = category.CategoryId;
                objFromDb.Author = category.Author;
                objFromDb.ISBN = category.ISBN;
                objFromDb.Price50 = category.Price50;
                objFromDb.Price100 = category.Price100;
                objFromDb.ListPrice = category.ListPrice;
                objFromDb.CoverTypeId = category.CoverTypeId;
                if(category.ImageUrl != null)
                {
                    objFromDb.ImageUrl = category.ImageUrl;
                }
            }
        }
    }
}
