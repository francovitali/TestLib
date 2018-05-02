using System;
using System.Collections.Generic;
using System.Text;

namespace TestLib.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public String Token { get; set; }
    }
}
