namespace LibaryManagementWeb.Contract
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int? id);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(List<T> entities);
        Task<bool> Exists(int id);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int T);

    }
}
