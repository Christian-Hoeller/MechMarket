using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using KeyboardMarket.Classes;
using KeyboardMarket.Classes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KeyboardMarket.Pages
{
    public class AllProductsModel : PageModel
    {

        public List<Product> Products { get; set; }

        public void OnGet()
        {
            Products = GetProducts();
        }


        private List<Product> GetProducts()
        {
            string commandText = "SELECT Products.ProductID, Users.Username, Products.Title, " +
                "Products.Description, Products.Price, Currencies.Currency, " +
                "Lands.Land, Conditions.Condition " +
                "FROM Products " +
                "INNER JOIN Lands ON Products.Land = Lands.LandID " +
                "INNER JOIN Conditions ON Products.Condition = Conditions.ConditionID " +
                "INNER JOIN Currencies ON Products.Currency = Currencies.CurrencyID " +
                "INNER JOIN Users ON Products.Email = Users.Email";

            SqlCommand command = new SqlCommand(commandText);

            DBContext dBContext = new DBContext();
            DataTable dt = new DataTable();

            using (command)
            {
                try
                {
                    dt = dBContext.GetDataReader(command);
                }
                catch (Exception ex)
                {
                }
            }

            List<Product> products = new List<Product>();
            foreach(DataRow row in dt.Rows)
            {
                int id = Convert.ToInt32(row["ProductID"]);
                string username = (string)row["Username"];
                string title = (string)row["Title"];
                decimal price = (decimal)row["Price"];
                string currency = (string)row["Currency"];
                string condition = (string)row["Condition"];
                string description = (string)row["Description"];
                string land = (string)row["Land"];
                products.Add(new Product(id, username, title, price, currency, condition, description, land));
            }

            return products;
        }
    }
}
