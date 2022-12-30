using BarcelonaStore.DataAccess;
using BarcelonaStore.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcelonaStore.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            MaterialType = new MaterialTypeRepository(_db);
            Product = new ProductRepository(_db);
            Company= new CompanyRepository(_db);
        }
        public ICategoryRepository Category { get; private set; }
        public IMaterialTypeRepository MaterialType { get; private set; }
        public IProductRepository Product { get; private set; }
        public ICompanyRepository Company { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
