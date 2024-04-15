

namespace AdoDotNetEFProject.DAL
{
    /// <summary>
    /// Overall interface which handle our data table
    /// NOTE:ICurrentCrud-mean Interface, Create, Read, Update and Delete
    /// </summary>
    /// <typeparam name="T">Generics collection</typeparam>
    public interface ICurrentCrud<T>      
    {
        #region Public interface Method
        /// <summary>
        /// Get all info on our table data
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Get by specific using primary key (GoodId)
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Task<T> GetByIdAsync(int Id);
     
        /// <summary>
        /// Insert interface method
        /// </summary>
        /// <param name="obj">value</param>
        public Task InsertAsync(T obj);
        /// <summary>
        /// Update interface method
        /// NOTE: When working with database it possible to change and update data excludng 'GoodId'
        /// </summary>
        /// <param name="obj">value</param>
        public Task UpdateAsync(T obj); 
        #endregion


    }
}
