using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCTaskTwo.ViewModel;

namespace MVCTaskTwo.Models
{
    public class AppDBContext:IdentityDbContext
    {
        public AppDBContext() 
        {
        }
        public AppDBContext(DbContextOptions<AppDBContext> options) :base(options) 
        {
        }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var constr = config.GetSection("constr").Value;
            optionsBuilder.UseSqlServer(constr);

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<RegistrationViewModel>().HasNoKey();
            builder.Entity<LoginViewModel>().HasNoKey();
            builder.Entity<RoleViewModel>().HasNoKey();
        }
        public DbSet<MVCTaskTwo.ViewModel.RegistrationViewModel> RegistrationViewModel { get; set; } = default!;
        public DbSet<MVCTaskTwo.ViewModel.LoginViewModel> LoginViewModel { get; set; } = default!;
        public DbSet<MVCTaskTwo.ViewModel.RoleViewModel> RoleViewModel { get; set; } = default!;
    }
}
