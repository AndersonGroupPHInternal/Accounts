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
                    Description = "This role can access all modules with regards in Accounts."

                });
            base.Seed(context);
        }
    }
}
