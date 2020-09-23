using System;
namespace KeyboardMarket.Classes.Models
{
    public class Land
    {
        public int ID { get; set; }
        public string Value { get; set; }

        public Land(int id, string value)
        {
            ID = id;
            Value = value;
        }
    }
}
