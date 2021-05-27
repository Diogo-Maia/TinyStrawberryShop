using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace Mady
{
    class DB_Manager
    {
        /*private readonly string connectionString = $"URI=file:" +
        $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}" +
        $"/StrawberryShop.db;";*/

        private readonly string conn = $"URI=file:" +
        $"{AppDomain.CurrentDomain.BaseDirectory}" +
        $"/StrawberryShop.db;";


        public void PushOrder(string name, string adress, string items,
            string insta, string price,
            string notes = "", int done = 0, int deliever = 0)
        {
            SQLiteConnection sqlConnect = 
                new SQLiteConnection(conn);
            sqlConnect.Open();

            using (var order = new SQLiteCommand(sqlConnect))
            {
                order.CommandText = "INSERT INTO Orders(Name, Adress, Items, InstaHandle, Notes, Done, Price, Delievered) VALUES (@n, @a, @i, @in, @no, @d, @p, @d)";
                order.Parameters.AddWithValue("@n", name);
                order.Parameters.AddWithValue("@a", adress);
                order.Parameters.AddWithValue("@i", items);
                order.Parameters.AddWithValue("@in", insta);
                order.Parameters.AddWithValue("@no", notes);
                order.Parameters.AddWithValue("@d", done);
                order.Parameters.AddWithValue("@p", price);
                order.Parameters.AddWithValue("@d", deliever);
                order.ExecuteNonQuery();
            }
            
        }

        public void UpdateOrder(string key, string name, string adress, string items,
            string insta, string notes, int done, int deliever)
        {
            SQLiteConnection sqlConnect =
                new SQLiteConnection(conn);
            sqlConnect.Open();

            using (var order = new SQLiteCommand(sqlConnect))
            {
                order.CommandText = "UPDATE Orders SET Name=@n, Adress=@a, Items=@i, InstaHandle=@in, Notes=@no, Done=@d, Delievered=@de WHERE OrderID=@key";
                order.Parameters.AddWithValue("@n", name);
                order.Parameters.AddWithValue("@a", adress);
                order.Parameters.AddWithValue("@i", items);
                order.Parameters.AddWithValue("@in", insta);
                order.Parameters.AddWithValue("@no", notes);
                order.Parameters.AddWithValue("@d", done);
                order.Parameters.AddWithValue("@de", deliever);
                order.Parameters.AddWithValue("@key", key);
                order.ExecuteNonQuery();
            }

        }

        public DataTable GetOrders()
        {
            SQLiteConnection sqlConnect =
                new SQLiteConnection(conn);
            sqlConnect.Open();

            SQLiteDataAdapter da;
            DataTable dt = new DataTable();

            try 
            {
                using (var cmd = sqlConnect.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Orders WHERE Done=0 OR Delievered=0 ";
                    da = new SQLiteDataAdapter(cmd.CommandText, sqlConnect);
                    da.Fill(dt);

                    return dt;
                }
            }catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public DataTable GetAllOrders()
        {
            SQLiteConnection sqlConnect =
                new SQLiteConnection(conn);
            sqlConnect.Open();

            SQLiteDataAdapter da;
            DataTable dt = new DataTable();

            try
            {
                using (var cmd = sqlConnect.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Orders";
                    da = new SQLiteDataAdapter(cmd.CommandText, sqlConnect);
                    da.Fill(dt);

                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable Search(string insta)
        {
            SQLiteConnection sqlConnect =
                new SQLiteConnection(conn);
            sqlConnect.Open();

            SQLiteDataAdapter da;
            DataTable dt = new DataTable();

            try
            {
                using (var cmd = sqlConnect.CreateCommand())
                {
                    cmd.CommandText = $"SELECT * FROM Orders WHERE Insta=\"{insta}\"";
                    //cmd.Parameters.AddWithValue("@in", "\'" + insta + "'");
                    da = new SQLiteDataAdapter(cmd.CommandText, sqlConnect);
                    da.Fill(dt);

                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
