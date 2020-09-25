using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public List<Land> Lands { get; set; }


        #region Bindproperties

        [BindProperty]
        [Required, StringLength(255, ErrorMessage = "Length can't be longer than 255")]
        public string Title { get; set; }

        //[Range(1, 9999, ErrorMessage = "Value must be between 1 and 9999")]
        //[Required]
        //[Column(TypeName = "decimal(16, 6)")]
        //public decimal Price { get; set; }

        [BindProperty]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [BindProperty]
        public string Currency { get; set; }

        [BindProperty]
        public string Description { get; set; }

        [BindProperty]
        public string Land { get; set; }

        #endregion



        public void OnGet()
        {
            Currencies = GetCurrencies();
            Lands = GetLands();
        } 

        public async Task OnPostAddProduct()
        {
            string sqlCommand = "INSERT INTO [dbo].[Products](Email, Title, Price, Currency, Condition, Description, Land)" +
                $"VALUES()";
        }


        private List<Currency> GetCurrencies()
        {
            DBContext dBContext = new DBContext();
            DataTable dt = new DataTable();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Currencies"))
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

        private List<Land> GetLands()
        {
            DBContext dBContext = new DBContext();
            DataTable dt = new DataTable();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Lands"))
            {
                dt = dBContext.GetDataReader(cmd);
            }

            List<Land> Land = new List<Land>();

            foreach (DataRow row in dt.Rows)
            {
                int id = Convert.ToInt32(row["LandID"]);
                string land = row["Land"].ToString();
                Land.Add(new Land(id, land));
            }
            return Land;
        }
    }
}
