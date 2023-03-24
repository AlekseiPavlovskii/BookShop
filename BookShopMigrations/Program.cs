using DatabaseProvider;

namespace BookShopMigrations
{
    public class Program
    {
        private const string ConnectionString =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Books;Pooling=true;Integrated Security=SSPI";


        public static void Main(string[] args)
        {
            ApplicationContext context = new ApplicationContext(ConnectionString);
        }
    }
}
