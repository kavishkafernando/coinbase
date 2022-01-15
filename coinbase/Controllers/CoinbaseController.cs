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
        private readonly DatabaseContext _dbContext;

        public CoinbaseController(DatabaseContext dbContext)
        {
            this._dbContext = dbContext;
        }

        // GET: api/Coinbase
        [HttpGet]
        public IEnumerable<Coin> GetAll()
        {
            var CoinsList = this._dbContext.Coins.ToList();
            return CoinsList;
        }

        // GET: api/Coinbase/5
        [HttpGet("{id}", Name = "Get")]
        public Coin Get(int id)
        {
            var coin = this._dbContext.Coins.FirstOrDefault(coin => coin.coinId == id);
            return coin;
        }

        // POST: api/Coinbase
        //[HttpPost]
        //public async Task<Coin> Post([FromBody] Coin value)
        //{
        //        await this._dbContext.Coins.AddAsync(value);
        //        var save = await this._dbContext.SaveChangesAsync();
        //        return value;
        //}

        [HttpPost]
        public async Task<bool> Post([FromBody] Coin request)
        {
            try
            {
                await this._dbContext.Coins.AddAsync(request);
                var save = await this._dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        // PUT: api/Coinbase/5
        [HttpPut("{id}")]
        public async Task<bool> Put(int id, [FromBody] Coin value)
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
        public bool Delete(int id)
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
