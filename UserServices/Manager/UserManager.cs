using BuyerDB.Entity;
using BuyerDB.Models;
using BuyerDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserServices.Manager
{
    public class UserManager:IUserManager
    {
        private readonly IUserRepository _repo;
        public UserManager(IUserRepository repo)
        {
            _repo = repo;
        }
        public async Task<bool> BuyerRegister(Buyer buyer)
        {
            bool user = await _repo.BuyerRegister(buyer);
            return user;

        }

        public async Task<Login> BuyerLogin(Login login)
        {
            Buyer buyer = new Buyer();
            Login login1 = await _repo.BuyerLogin(login);
            if (buyer.Buyername == login.userName && buyer.Password == login.userPassword)
            {
                return login1;
            }
            else
            {
                Console.WriteLine("Invalid");
                return login1;
            }
        }

    }
}

