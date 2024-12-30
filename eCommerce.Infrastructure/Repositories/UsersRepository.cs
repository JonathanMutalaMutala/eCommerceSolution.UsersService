using Dapper;
using eCommerce.Core.Dto;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;


namespace eCommerce.Infrastructure.Repositories
{
    public class UsersRepository : IUSersRepository
    {
        private readonly DapperDbContext dapperDbContext;

        public UsersRepository(DapperDbContext dapperDbContext)
        {
            this.dapperDbContext = dapperDbContext;
        }

        public  async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            user.UserId = Guid.NewGuid();

            string query = "INSERT INTO public.\"Users\"(\"UserId\"," +
                "\"Email\", \"PersonName\", \"Gender\", \"Password\") VALUES(@UserId, @Email, @PersonName, @Gender, @Password)";


            int rowCountAffected = await dapperDbContext.dbConnection.ExecuteAsync(query, user);

            if (rowCountAffected <= 0)
            {
                return null;
            }

            return user;
        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
        {
            string query = "SELECT * FROM public.\"Users\"WHERE \"Email\"=@Email AND  \"Password\"=@Password";
            var parameters = new { Email = email, Password = password };

            var applicationUser = await dapperDbContext.dbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query,parameters);


            return applicationUser; 
        }
    }
}
