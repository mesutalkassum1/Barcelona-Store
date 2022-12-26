using Barcelona_Store.Data;
using BarcelonaStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcelonaStore.DataAccess.Repository.IRepository
{
    public class MaterialTypeRepository : Repository<MaterialType>, IMaterialTypeRepository
    {
        private ApplicationDbContext _db;
        public MaterialTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(MaterialType obj)
        {
            _db.MaterialTypes.Update(obj);
        }
    }
}
