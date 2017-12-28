using AccountsEntity;
using System.Data.Entity;


namespace AccountsContext
{
    public class DBInitializer : CreateDatabaseIfNotExists<Context>
    {
        public DBInitializer()
        {
        }
        protected override void Seed(Context context)
        {
            context.Roles.Add(
                new ERole
                {
                    Name = "AccountAdministrator",
                    Description = "Admin of Account"
                });
            base.Seed(context);
        }
    }
}
