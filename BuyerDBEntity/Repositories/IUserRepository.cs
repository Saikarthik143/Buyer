using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BuyerDBEntity.Entity;
using BuyerDBEntity.Models;
namespace BuyerDBEntity.Repositories
{
    public interface IUserRepository
    {
        Task<bool> BuyerRegister(Buyer buyer);
        Task<Buyer> BuyerLogin(Login login);
    }
}
