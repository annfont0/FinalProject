using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinalProject.Pages
{
    public class ProductsModel : PageModel
    {
        readonly IConfiguration _configuration;

        public List<Products> products = new List<Products>();

        string connectionString;

        public ProductsModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnGet()
        {
            products = GetProductList();
        }

        private List<Products> GetProductList()
        {
            connectionString = _configuration.GetConnectionString("ConnectionString");
            List<Products> ProductList = new List<Products>();
            Products products = new Products();
            ProductList = products.GetProducts(connectionString);
            return ProductList;
        }
    }
}
