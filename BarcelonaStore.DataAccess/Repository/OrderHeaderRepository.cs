using BarcelonaStore.DataAccess;
using BarcelonaStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcelonaStore.DataAccess.Repository.IRepository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
	{
        private ApplicationDbContext _db;
        public OrderHeaderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(OrderHeader obj)
        {
            _db.OrderHeaders.Update(obj);
        }

		public void UpdateStatus(int id, string orderStatus, string? patmentStatus = null)
		{
            var orderFromDb = _db.OrderHeaders.FirstOrDefault(u=> u.Id == id);
            if (orderFromDb != null)
            {
                 orderFromDb.OrderStatus = orderStatus;
                if(patmentStatus != null)
                {
                    orderFromDb.PaymentStatus= patmentStatus;
                }
            }
		}

		public void UpdateStripePaymentId(int id, string sessionId, string patmentIntintId)
		{
			var orderFromDb = _db.OrderHeaders.FirstOrDefault(u => u.Id == id);
            orderFromDb.PaymentDate = DateTime.Now;
            orderFromDb.SessionId = sessionId;
            orderFromDb.PaymentIntentId = patmentIntintId;
			}
		}
	}

