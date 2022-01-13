using System;
using coinbase.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace coinbase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinbaseController : ControllerBase
    {
        private readonly CoinContext _dbContext;

        public CoinbaseController(CoinContext dbContext)
        {
            this._dbContext = dbContext;
        }

        // GET: api/Coinbase
        [HttpGet]
        public IEnumerable<Coin> GetCoinList()
        {
            var CoinsList = this._dbContext.Coins.ToList();
            return CoinsList;
        }

        // GET: api/Coinbase/5
        [HttpGet("{id}", Name = "Get")]
        public Coin GetCoinById(int id)
        {
            var coin = this._dbContext.Coins.FirstOrDefault(coin => coin.coinId == id);
            return coin;
        }

        // POST: api/Coinbase
        [HttpPost]
        public async Task<Coin> AddCoin([FromBody] Coin value)
        {
                await this._dbContext.Coins.AddAsync(value);
                var save = await this._dbContext.SaveChangesAsync();
                return value;
        }

        // PUT: api/Coinbase/5
        [HttpPut("{id}")]
        public async Task<bool> UpdateCoin(int id, [FromBody] Coin value)
        {
            try
            {
                var coin = this._dbContext.Coins.FirstOrDefault(coin => coin.coinId == id);
                if (coin == null) return false;

                coin.coin = value.coin;
                coin.rate = value.rate;
                this._dbContext.Coins.Update(coin);
                await this._dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public bool DeleteCoin(int id)
        {
            try
            {
                var coin = this._dbContext.Coins.FirstOrDefault(coin => coin.coinId == id);
                if (coin == null) return false;

                this._dbContext.Coins.Remove(coin);
                this._dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
