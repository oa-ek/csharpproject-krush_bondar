using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthyTreats.Core.Context
{
	public class HealthyContext : IdentityDbContext
	{
		public HealthyContext(DbContextOptions<HealthyContext> options)
			: base(options)
		{
		}
	}
}
