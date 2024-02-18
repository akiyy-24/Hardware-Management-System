using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Hardware_Management_System
{
    public class ItemDB
    {
        public DataTable Store_SelectAll()
        {
            MySqlConnection con = new Dbconnection().ConnectDB();
            string query = "select*from store";
            MySqlCommand cmd = new MySqlCommand(query, con);
            con.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(rdr);
            return table;
        }

     /*   public store findbyitemID(string itemID)
        {
                 MySqlConnection con = new Dbconnection().ConnectDB();
                string query = "select * from store where Item_ID=@Item_ID" + itemID;
                MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Item_ID", guna2TextBox2.Text);
                con.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                store store = new store();
                while (rdr.Read())
                {
                    store.Name = rdr.GetString("Name_I");
                }
                return store;
               
        }*/
        public DataTable Customer_SelectAll()
        {
            MySqlConnection con = new Dbconnection().ConnectDB();
            string query = "select*from bill";
            MySqlCommand cmd = new MySqlCommand(query, con);
            con.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(rdr);
            return table;
        }
        public DataTable Dealer_SelectAll()
        {
            MySqlConnection con = new Dbconnection().ConnectDB();
            string query = "select*from dealer";
            MySqlCommand cmd = new MySqlCommand(query, con);
            con.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(rdr);
            return table;
        }
        public DataTable Return_SelectAll()
        {
            using (MySqlConnection con = new Dbconnection().ConnectDB())
            {
                string query = "SELECT Item_ID, Dealer_ID, Quantity_R, CAST(`Date` AS CHAR) AS Date FROM `cus_return`";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    con.Open();
                    using (MySqlDataReader rdr1 = cmd.ExecuteReader())
                    {
                        DataTable table1 = new DataTable();
                        table1.Load(rdr1);
                        return table1;
                    }
                }
            }
        }



        public void Customer_Insert(string name, int id, int qty, double dis_I, double dis, double Tot_Each)
        {
            MySqlConnection con = new Dbconnection().ConnectDB();

            // Use parameterized query to prevent SQL injection
            string sql = "INSERT INTO bill (Name_I, Item_ID, Quantity_B, Discount_I, Discount, Total) VALUES (@name, @id, @qty, @dis_I, @dis, @Tot_Each)";

            MySqlCommand cmd = new MySqlCommand(sql, con);

            // Add parameters
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@qty", qty);
            cmd.Parameters.AddWithValue("@dis_I", dis_I);
            cmd.Parameters.AddWithValue("@dis", dis);
            cmd.Parameters.AddWithValue("@Tot_Each", Tot_Each);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                // Handle exceptions
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void Customer_Delete(int id)
        {
            MySqlConnection con = new Dbconnection().ConnectDB();
            string sql = "delete from bill where Item_ID=@Item_ID";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Item_ID", id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //Dealer Table
        public void Dealer_Insert(int D_ID, int Item_ID, string Com_Name, string D_Name, int D_qty, double D_Price)
        {
            using (MySqlConnection con = new Dbconnection().ConnectDB())
            {
                string sql = "INSERT INTO dealer (Dealer_ID, Name_D, Item_ID, Company, Price_D, Quantity_D) VALUES (@D_ID, @D_Name, @Item_ID, @Com_Name, @D_Price, @D_qty)";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@D_ID", D_ID);
                cmd.Parameters.AddWithValue("@D_Name", D_Name);
                cmd.Parameters.AddWithValue("@Item_ID", Item_ID);
                cmd.Parameters.AddWithValue("@Com_Name", Com_Name);
                cmd.Parameters.AddWithValue("@D_Price", D_Price);
                cmd.Parameters.AddWithValue("@D_qty", D_qty);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Dealer_Delete(int Item_ID)
        {
            using (MySqlConnection con = new Dbconnection().ConnectDB())
            {
                string sql = "DELETE FROM `dealer` WHERE Item_ID = @Item_ID";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    try
                    {
                        cmd.Parameters.AddWithValue("@Item_ID", Item_ID);
                       

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        con.Close();
                    }
            }
        }


        //Cus_return table
        public void Return_Insert(int Item_ID, int Dealer_ID, int Quantity_R, DateTime selectedDateTime)
        {
            using (MySqlConnection con = new Dbconnection().ConnectDB())
            {
                if (con == null)
                {
                    Console.WriteLine("Failed to connect to the database.");
                    return;
                }

                string sql = "INSERT INTO `cus_return` (Item_ID, Dealer_ID, Quantity_R, Date) VALUES (@ItemID, @DealerID, @QuantityR, @ReturnDate)";

                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@ItemID", Item_ID);
                    cmd.Parameters.AddWithValue("@DealerID", Dealer_ID);
                    cmd.Parameters.AddWithValue("@QuantityR", Quantity_R);
                    cmd.Parameters.AddWithValue("@ReturnDate", selectedDateTime);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error executing query: " + ex.Message);
                    }
                }
            }
        }


        public void Return_Delete(int Item_ID)
        {
            using (MySqlConnection con = new Dbconnection().ConnectDB())
            {
                string sql = "DELETE FROM `cus_return` WHERE Item_ID = @Item_ID";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                try  
                {
                    cmd.Parameters.AddWithValue("@Item_ID", Item_ID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                        con.Close();
                }
                catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        con.Close();
                    }
            }
        }

    }
}
