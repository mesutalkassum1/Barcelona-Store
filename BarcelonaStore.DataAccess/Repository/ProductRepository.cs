using BarcelonaStore.DataAccess;
using BarcelonaStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcelonaStore.DataAccess.Repository.IRepository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Product obj)
        {
            var objFromDb = _db.Products.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb == null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.ISBN = obj.Description;
                objFromDb.Price = obj.Price;
                objFromDb.Price5 = obj.Price5;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.Price10 = obj.Price10;
                objFromDb.Description = obj.Description;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.MaterialTypeId = obj.MaterialTypeId;
                if(objFromDb.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
