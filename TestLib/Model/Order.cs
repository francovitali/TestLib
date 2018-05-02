using System;
using System.Collections.Generic;
using System.Text;

namespace TestLib.Model
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double OriginalPrice { get; set; }
        public double Discount { get; set; }
        public String Token { get; set; }
    }
}
