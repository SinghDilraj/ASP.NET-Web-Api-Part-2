namespace Web_Api_Payments.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Web_Api_Payments.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Web_Api_Payments.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            if (!context.CreditCards.Any())
            {
                context.CreditCards.AddOrUpdate(card => card.Id,
                    new Models.Domain.CreditCard() { IdentificationNumber = "011", Brand = "Visa" },
                    new Models.Domain.CreditCard() { IdentificationNumber = "021", Brand = "Master Card" },
                    new Models.Domain.CreditCard() { IdentificationNumber = "031", Brand = "American Express" }
                    );
            }

            context.SaveChanges();
        }
    }
}
