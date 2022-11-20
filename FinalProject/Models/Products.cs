using System.Data.SqlClient;

namespace FinalProject.Models
{
    public class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductPicture { get; set; }
        public string ProductBrand { get; set; }
        public string ProductCategory { get; set; }
        public int ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public int ProductLikes { get; set; }

        public List<Products> GetProducts (string connectionString) {
            List<Products> ProductList = new List<Products>();
            SqlConnection con = new SqlConnection(connectionString);
            string selectSQL = "SELECT * FROM GetProductsData";

            con.Open();

            SqlCommand cmd = new SqlCommand(selectSQL, con);

            SqlDataReader dr = cmd.ExecuteReader();

            if(dr != null)
            {
                while (dr.Read())
                {
                    Products products = new Products();
                    products.ProductId = Convert.ToInt32(dr["ProductId"]);
                    products.ProductName = dr["ProductName"].ToString();
                    products.ProductPicture = dr["ProductPicture"].ToString();
                    products.ProductBrand = dr["ProductBrand"].ToString();
                    products.ProductCategory = dr["ProductCategory"].ToString();
                    products.ProductPrice = Convert.ToInt32(dr["ProductPrice"]);
                    products.ProductDescription = dr["ProductDescription"].ToString();
                    products.ProductLikes = Convert.ToInt32(dr["ProductLikes"]);

                    ProductList.Add(products);
                }
            }
            return ProductList;
        }
        public Products GetProductsData(string connectionString, int ProductId) {
            SqlConnection con = new SqlConnection(connectionString);

            string selectSQL = "SELECT * FROM GetProductsData WHERE ProductId =" + ProductId;

            con.Open();

            SqlCommand cmd = new SqlCommand(selectSQL, con);

            SqlDataReader dr = cmd.ExecuteReader();

            Products products = new Products();

            if (dr != null)
            {
                while (dr.Read())
                {
                    products.ProductId = Convert.ToInt32(dr["ProductId"]);
                    products.ProductName = dr["ProductName"].ToString();
                    products.ProductPicture = dr["ProductPicture"].ToString();
                    products.ProductBrand = dr["ProductBrand"].ToString();
                    products.ProductCategory = dr["ProductCategory"].ToString();
                    products.ProductPrice = Convert.ToInt32(dr["ProductPrice"]);
                    products.ProductDescription = dr["ProductDescription"].ToString();
                    products.ProductLikes = Convert.ToInt32(dr["ProductLikes"]);
                }
            }
            return products;
        }

    }
}
