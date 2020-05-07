using BuyerDB.Entity;
using BuyerDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserServices.Manager
{
   public interface IUserManager
    {
        Task<bool> BuyerRegister(Buyer buyer);
        Task<Login> BuyerLogin(Login login);
    }
}
