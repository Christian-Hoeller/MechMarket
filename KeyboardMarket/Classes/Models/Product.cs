using System;
namespace KeyboardMarket.Classes.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public string Condition { get; set; }
        public string Description { get; set; }
        public string Land { get; set; }


        public Product(int id, string email, string title, decimal price, string currency, string condition, string description, string land)
        {
            ID = id;
            Username = email;
            Title = title;
            Price = price;
            Currency = currency;
            Condition = condition;
            Description = description;
            Land = land;
        }
    }
}
