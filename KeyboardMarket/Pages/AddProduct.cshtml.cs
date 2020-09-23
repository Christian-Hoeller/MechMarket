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
    public class AddProductModel : PageModel
    {
        public List<Currency> Currencies { get; set; }

        public void OnGet()
        {
            Currencies = GetCurrencies();
        }



        public List<Currency> GetCurrencies()
        {
            DBContext dBContext = new DBContext();
            DataTable dt = new DataTable();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Currencies]"))
            {
                dt = dBContext.GetDataReader(cmd);
            }

            List<Currency> Currencies = new List<Currency>();

            foreach (DataRow row in dt.Rows)
            {
                int id = Convert.ToInt32(row["CurrencyID"]);
                string currency = row["Currency"].ToString();
                Currencies.Add(new Currency(id, currency));
            }
            return Currencies;
        }
    }
}
