using Microsoft.EntityFrameworkCore;
using ReactJs.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ReactJs.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        #region DbSet Section
        public DbSet<Employee> Employees { get; set; }

        public DbSet<ContactUs> ContactUs { get; set; }

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // get ApplyConfiguration method with reflection
            var applyGenericMethod = typeof(ModelBuilder).GetMethod("ApplyConfiguration", BindingFlags.Instance | BindingFlags.Public);
            // replace GetExecutingAssembly with assembly where your configurations are if necessary
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes()
                .Where(c => c.IsClass && !c.IsAbstract && !c.ContainsGenericParameters))
            {
                // use type.Namespace to filter by namespace if necessary
                foreach (var iface in type.GetInterfaces())
                {
                    // if type implements interface IEntityTypeConfiguration<SomeEntity>
                    if (iface.IsConstructedGenericType && iface.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
                    {
                        // make concrete ApplyConfiguration<SomeEntity> method
                        var applyConcreteMethod = applyGenericMethod.MakeGenericMethod(iface.GenericTypeArguments[0]);
                        // and invoke that with fresh instance of your configuration type
                        applyConcreteMethod.Invoke(modelBuilder, new object[] { Activator.CreateInstance(type) });
                        break;
                    }
                }
            }

        }

    }
}
