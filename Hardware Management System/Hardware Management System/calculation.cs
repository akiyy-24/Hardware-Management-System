using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hardware_Management_System
{
    public class calculation
    {
        public double Customer_Total(int id, int qty, double dis_I, double dis)
        {
            double price = 0;
            double Tot_Each = 0;
            double Tot_Final;

            MySqlConnection con = new Dbconnection().ConnectDB();
            string query = "SELECT Price_I FROM store WHERE Item_ID = @id";

            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                if (rdr.Read())
                {
                    price = rdr.GetDouble("Price_I");
                }
                rdr.Close();

                // Calculate Tot_Each based on price * qty
                Tot_Each = price * qty;

                // Calculate Tot_Final based on the updated Tot_Each and full discount
                double fullDiscount = 1 - (dis_I + dis);
                Tot_Final = Tot_Each * fullDiscount;

                return Tot_Final;
            }
            else
            {
                throw new Exception($"Item with Item_ID {id} not found in the store.");
            }
        }
    }



}


