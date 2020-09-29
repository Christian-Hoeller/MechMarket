using System;
using System.Data;
using System.Data.SqlClient;

namespace KeyboardMarket.Classes
{
    public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime Joined { get; set; }
        public string Gender { get; set; }


        public User()
        {
        }

        public User(string username, string email, DateTime joined, string gender)
        {
            Username = username;
            Email = email;
            Gender = gender;
            Joined = joined;
        }

        public bool UserIsRegistered()
        {
            DBContext dBContext = new DBContext();
            DataTable dt = new DataTable();

            using (SqlCommand cmd = new SqlCommand($"SELECT * FROM Users WHERE Username = '{Username}'"))
            {
                dt = dBContext.GetDataReader(cmd);
            }

            return dt.Rows.Count != 0;
        }
    }
}
