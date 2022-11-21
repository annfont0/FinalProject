using System.Data.SqlClient;

namespace FinalProject.Models
{
    public class Customers
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerUsername { get; set; }
        public DateTime CustomerBirthday { get; set; }
        public string CustomerGender { get; set; }
        public string CustomerNationality { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerEmail { get; set; }
        public int CustomerPhone { get; set; }
        public string CustomerPassword {get; set;}

        public List<Customers> GetCustomers(string connectionString)
        {
            List<Customers> CustomerList = new List<Customers>();
            SqlConnection con = new SqlConnection(connectionString);
            string selectSQL = "SELECT * FROM GetCustomersData";

            con.Open();

            SqlCommand cmd = new SqlCommand(selectSQL, con);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr != null)
            {
                while (dr.Read())
                {
                    Customers customers = new Customers();
                    customers.CustomerId = Convert.ToInt32(dr["CustomerId"]);
                    customers.CustomerName = dr["CustomerName"].ToString();
                    customers.CustomerUsername = dr["CustomerUsername"].ToString();
                    customers.CustomerBirthday = Convert.ToDateTime(dr["CustomerBirthday"]);
                    customers.CustomerGender = dr["CustomerGender"].ToString();
                    customers.CustomerNationality = dr["CustomerNationality"].ToString();
                    customers.CustomerAddress = dr["CustomerAddress"].ToString();
                    customers.CustomerEmail = dr["CustomerEmail"].ToString();
                    customers.CustomerPhone = Convert.ToInt16(dr["CustomerPhone"]);
                    customers.CustomerPassword = dr["CustomerPassword"].ToString();

                    CustomerList.Add(customers);
                }
            }
            return CustomerList;
        }
        public Customers GetCustomersData(string connectionString, int CustomerId)
        {
            SqlConnection con = new SqlConnection(connectionString);

            string selectSQL = "SELECT * FROM GetCustomersData WHERE CustomerId =" + CustomerId;

            con.Open();

            SqlCommand cmd = new SqlCommand(selectSQL, con);

            SqlDataReader dr = cmd.ExecuteReader();

            Customers customers = new Customers();

            if (dr != null)
            {
                while (dr.Read())
                {
                    customers.CustomerId = Convert.ToInt32(dr["CustomerId"]);
                    customers.CustomerName = dr["CustomerName"].ToString();
                    customers.CustomerUsername = dr["CustomerUsername"].ToString();
                    customers.CustomerBirthday = Convert.ToDateTime(dr["CustomerBirthday"]);
                    customers.CustomerGender = dr["CustomerGender"].ToString();
                    customers.CustomerNationality = dr["CustomerNationality"].ToString();
                    customers.CustomerAddress = dr["CustomerAddress"].ToString();
                    customers.CustomerEmail = dr["CustomerEmail"].ToString();
                    customers.CustomerPhone = Convert.ToInt16(dr["CustomerPhone"]);
                    customers.CustomerPassword = dr["CustomerPassword"].ToString();
                }
            }
            return customers;
        }

        public void CreateAccount (string connectionString, Customers customers)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("CreateCustomer", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@CustomerName", customers.CustomerName));
                    cmd.Parameters.Add(new SqlParameter("@CustomerUsername", customers.CustomerUsername));
                    cmd.Parameters.Add(new SqlParameter("@CustomerBirthday", customers.CustomerBirthday));
                    cmd.Parameters.Add(new SqlParameter("@CustomerGender", customers.CustomerGender));
                    cmd.Parameters.Add(new SqlParameter("@CustomerNationality", customers.CustomerName));
                    cmd.Parameters.Add(new SqlParameter("@CustomerAddress", customers.CustomerUsername));
                    cmd.Parameters.Add(new SqlParameter("@CustomerEmail", customers.CustomerBirthday));
                    cmd.Parameters.Add(new SqlParameter("@CustomerPhone", customers.CustomerGender));
                    cmd.Parameters.Add(new SqlParameter("@CustomerPassword", customers.CustomerGender));

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
              
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
