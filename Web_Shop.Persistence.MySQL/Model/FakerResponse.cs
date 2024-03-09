using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Shop.Persistence.MySQL.Model
{
    public class FakerResponse
    {
        public string? textResponse { get; set; }
        public int recordCount { get; set; } = 0;
    }
}
