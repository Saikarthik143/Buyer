using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BuyerDBEntity.Entity;
using BuyerDBEntity.Models;
using Microsoft.EntityFrameworkCore;

namespace BuyerDBEntity.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BuyerContext _buyerContext;
        public UserRepository(BuyerContext buyerContext)
        {
            _buyerContext = buyerContext;
        }
        public async Task<bool> BuyerRegister(Buyer buyer)
        {
            _buyerContext.Buyer.Add(buyer);
            var user = await _buyerContext.SaveChangesAsync();
            if (user > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Buyer> BuyerLogin(Login login)
        {
            try
            {
                Buyer buyer = await _buyerContext.Buyer.SingleOrDefaultAsync(e => e.Buyername == login.userName && e.Password == login.userPassword);
                return buyer;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
