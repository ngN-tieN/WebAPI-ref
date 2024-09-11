using ContosoPizza.Data;

namespace ContosoPizza.RepositoryManager
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly ContosoPizzaContext _context;
        public Repository(ContosoPizzaContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(Add)} entity must not be null");

            }

            try
            {
                _context.Add(entity);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved:{ex.Message}");
            }
        }

        public IQueryable<TEntity> GetAll()
        {

            try
            {
                return _context.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldnt retrieve entities:{ex.Message}");
            }

        }
        public void Update(TEntity entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException($"{nameof(Add)} entity must not be null");

            }
            try
            {
                _context.Update(entity);

            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }
        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(Add)} entity must not be null");

            }
            try
            {
                _context.Remove(entity);

            }
            catch (Exception ex) 
            {
                throw new Exception($"{nameof(entity)} could not be deleted: {ex.Message}");
            }
        }

        public async Task SaveChangeAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new Exception("Transaction failed!");
            }
        }
    }
}
