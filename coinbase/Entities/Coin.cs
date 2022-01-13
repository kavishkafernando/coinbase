using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace coinbase.Entities
{
    public class Coin
    {
        [Key]
        public int coinId { get; set; }
        public string coin { get; set; }
        public double rate { get; set; }
    }
}
