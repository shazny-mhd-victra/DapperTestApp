namespace DAL.DataAccess
{
    public interface IDataAccess<T> where T : class
    {
        Task<IEnumerable<T>> LoadData<S,U>(string storedProcedure, U parameters);
        Task SaveData<U>(string storedProcedure, U parameters);
    }
}
