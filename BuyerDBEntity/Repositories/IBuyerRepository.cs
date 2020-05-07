using BuyerDBEntity.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuyerDBEntity.Repositories
{
   public interface IBuyerRepository
    {
        Task<bool> EditBuyerProfile(Buyer buyer);
        Task<Buyer> GetBuyerProfile(string buyerId);
    }
}
