using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;

namespace nest.core.infrastructura.utils.DataLoader
{
    public static class DataSourceLoaderLw
    {
        public static LoadResult Load<T>(
            IQueryable<T> query,
            DataSourceLoadOptionsBase loadOptions)
        {
            loadOptions.StringToLower = true;

            return DataSourceLoader.Load(query, loadOptions);
        }

        public static async Task<LoadResult> LoadAsync<T>(
            IQueryable<T> query,
            DataSourceLoadOptionsBase loadOptions,
            CancellationToken ct = default)
        {
            loadOptions.StringToLower = true;

            return await DataSourceLoader.LoadAsync(query, loadOptions, ct);
        }
    }
}
