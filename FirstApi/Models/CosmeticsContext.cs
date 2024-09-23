using FirstApi.Models;
using Microsoft.EntityFrameworkCore;
namespace FirstApi.Data
{
	public class CosmeticsContext : DbContext
	{
		
		public CosmeticsContext(DbContextOptions options) :base(options) 
		{
		}
		public virtual DbSet<Makeup> Makeup { get; set; }

	}
}
