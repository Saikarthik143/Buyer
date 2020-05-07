using BuyerDBEntity.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuyerDBEntity.Repositories
{
  public  class BuyerRepository:IBuyerRepository
    {
        private readonly BuyerContext _context;
        public BuyerRepository(BuyerContext context)
        {
            _context = context;
        }
        public async Task<bool> EditBuyerProfile(Buyer buyer)
        {
            _context.Update(buyer);
            var user = await _context.SaveChangesAsync();
            if (user > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Buyer> GetBuyerProfile(string buyerId)
        {
            Buyer buyer = await _context.Buyer.FindAsync(buyerId);
            if (buyer == null)
                return null;
            else
                return buyer;
        }

       
    }
}
