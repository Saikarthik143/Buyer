﻿using BuyerDB.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuyerDB.Models
{
   public class Login
    {
        public string userName { get; set; }
        public string userPassword { get; set; }
        public string buyerId { get; set; }

        public static implicit operator Login(Buyer v)
        {
            throw new NotImplementedException();
        }
    }
}
