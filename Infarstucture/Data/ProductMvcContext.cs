using Microsoft.EntityFrameworkCore;
using ProductsMvc.Models;

namespace ProductsMvc.Infarstucture.Data
{
    public class ProductMvcContext:DbContext
    {
        public DbSet<Product> Products { get; set; }


        public ProductMvcContext(DbContextOptions dbOptions) : base(dbOptions)
        {
        }
    }

}
