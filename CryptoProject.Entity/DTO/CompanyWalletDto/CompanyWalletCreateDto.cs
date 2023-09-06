﻿using CryptoProject.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapProject.Entity.DTO.CompanyWalletDto
{
    public class CompanyWalletCreateDto:IDto
    {
        public int CoinId { get; set; }
        public decimal Amount { get; set; }
    }
}
