using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using ui.Properties;

namespace ui
{
    public class Database
    {
        private readonly string _ConnectionString = Settings.Default.DbConnectionString;

        public MySqlConnection GetConnection => new MySqlConnection(_ConnectionString);

        public System.Windows.Forms.TextBox box => this.box;
        public System.Windows.Forms.DataGridView dataGridView1 => this.dataGridView1;


        public IEnumerable<dynamic> FetchAllBranches()
        {
            var dbConnection = new Database().GetConnection;
            dbConnection.Open();

            var sql = "SELECT * FROM practicaltest.branches";
            var result = dbConnection.Query<string>(sql);



            //Debug.WriteLine(Convert.ToString(result));
            //Debug.WriteLine(Convert.ToString(branches));


            dbConnection.Close();
            return result;
        }
        public IEnumerable<String> FetchAllOrders()         //DATABASE CONNECTION CREATED FOR ORDER NUMBER READ
        {
            var dbConnection = new Database().GetConnection;
            dbConnection.Open();

            var sqlOrd = "SELECT order_number FROM practicaltest.orders";
            var OrdNum = dbConnection.Query<string>(sqlOrd);
            //string orderNum = string.Join(Environment.NewLine, OrdNum);
            //Debug.WriteLine(Convert.ToString(orderNum));

            dbConnection.Close();
            return OrdNum;
        }
        public IEnumerable<String> FetchAllCustomers()         //DATABASE CONNECTION CREATED FOR ORDER NUMBER READ
        {
            var dbConnection = new Database().GetConnection;
            dbConnection.Open();

            var sqlCust = "SELECT * FROM practicaltest.customers";
            var cust = dbConnection.Query<string>(sqlCust);
            //string orderNum = string.Join(Environment.NewLine, OrdNum);
            //Debug.WriteLine(Convert.ToString(orderNum));

            dbConnection.Close();
            return cust;
        }
        



    }
}
