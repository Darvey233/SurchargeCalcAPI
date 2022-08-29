using Microsoft.EntityFrameworkCore;

namespace GoFreightAPI.Models
{
    [Keyless]
    public class GoFreightItem
    {
        public long CustomerID { get; set; }
        public double Subtotal { get; set; }
        public double SurchargeAmount { get; set; }
        public double Total { get; set; }
    }
}