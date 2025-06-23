using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class DetailOrderResponse
    {
        public int IdDetailOrder { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public string ProductKey { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
