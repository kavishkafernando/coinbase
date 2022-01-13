using System;
using Microsoft.EntityFrameworkCore;
using coinbase.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coinbase
{
    public class CoinContext : DbContext
    {
        public CoinContext(DbContextOptions<CoinContext> options) :base(options)
        {}

        public DbSet<Coin> Coins { get; set; }
    }
}
