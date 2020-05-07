using BuyerDB.Entity;
using BuyerDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyerService.Manager
{
    public class BuyerManager : IBuyerManager
    {
        private readonly IBuyerRepository _ibuyerRepository;
        public BuyerManager(IBuyerRepository ibuyerRepository)
        {
            _ibuyerRepository = ibuyerRepository;
        }
        public async Task<bool> EditBuyerProfile(Buyer buyer)
        {
            bool user = await _ibuyerRepository.EditBuyerProfile(buyer);
            if (user == true)
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
            Buyer buyer = await _ibuyerRepository.GetBuyerProfile(buyerId);
            if (buyer == null)
            {
                return null;
            }
            else
            {
                return buyer;
            }
        }

    }
}