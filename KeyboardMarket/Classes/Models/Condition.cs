using System;
namespace KeyboardMarket.Classes.Models
{
    public class Condition
    {
        public int ID { get; set; }
        public string Value { get; set; }

        public Condition(int id, string value)
        {
            ID = id;
            Value = value;
        }
    }
}
