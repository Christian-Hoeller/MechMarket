using System;
namespace KeyboardMarket.Classes.Models
{
    public class Currency
    {
        public int ID { get; set; }
        public string Value { get; set; }

        public Currency(int id, string value)
        {
            ID = id;
            Value = value;
        }
    }
}
