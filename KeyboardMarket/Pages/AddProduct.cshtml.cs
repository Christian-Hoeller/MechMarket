using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
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
        public List<Condition> Conditions { get; set; }


        #region Bindproperties

        [BindProperty]
        [Required, StringLength(255, ErrorMessage = "Length can't be longer than 255")]
        public string Title { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]

        [BindProperty]
        public decimal Price { get; set; }

        [BindProperty]
        public string Currency { get; set; }

        [BindProperty]
        public string Description { get; set; }

        [BindProperty]
        public string Land { get; set; }

        [BindProperty]
        public string Condition { get; set; }

        #endregion



        public void OnGet()
        {
            Currencies = GetCurrencies();
            Lands = GetLands();
            Conditions = GetConditions();
        } 

        public IActionResult OnPostAddProduct()
        {
            if (ModelState.IsValid)
            {
                string email = User.FindFirstValue(ClaimTypes.Email);

                string sqlCommand = "INSERT INTO [dbo].[Products](Email, Title, Price, Currency, Condition, Description, Land)" +
               $"VALUES('{email}', '{Title}',{Price}, {Currency}, {Condition}, '{Description}', {Land})";

                DBContext dBContext = new DBContext();

                using (SqlCommand cmd = new SqlCommand(sqlCommand))
                {
                    dBContext.ExecuteNonQuery(cmd);
                    return new RedirectToPageResult("/index");
                }
            }
            return Page();
        }

        private List<Condition> GetConditions()
        {
            DBContext dBContext = new DBContext();
            DataTable dt = new DataTable();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Conditions"))
            {
                dt = dBContext.GetDataReader(cmd);
            }

            List<Condition> Conditions = new List<Condition>();

            foreach (DataRow row in dt.Rows)
            {
                int id = Convert.ToInt32(row["ConditionID"]);
                string currency = row["Condition"].ToString();
                Conditions.Add(new Condition(id, currency));

            }
            return Conditions;
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
