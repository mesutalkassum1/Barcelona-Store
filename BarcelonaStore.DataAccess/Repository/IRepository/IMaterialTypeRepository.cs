using BarcelonaStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcelonaStore.DataAccess.Repository.IRepository
{
    public interface IMaterialTypeRepository : IRepository<MaterialType>
    {
        void Update(MaterialType obj);
    }
}
