namespace CpmPedidos.Repository
{
    public class BaseRepository
    {
        protected const int TamanhoPagina = 5;

        protected readonly ApplicationDbContext DbContext;

        // 6 Base repository
        public BaseRepository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}