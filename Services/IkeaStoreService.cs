using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class IkeaStoreService
{
    private static readonly Lazy<IkeaStore[]> _lazyStores;

    static IkeaStoreService()
    {
        _lazyStores = new Lazy<IkeaStore[]>(() =>
        {
            var file = Path.Combine(Environment.CurrentDirectory, "Assets", "IkeaStores.json");
            var storesAsJson = System.IO.File.ReadAllText(file);
            return JsonConvert.DeserializeObject<IkeaStore[]>(storesAsJson);
        });
    }

    public async Task<IkeaStore> Get(int id)
    {
        return await Task.Run(() =>
        {
            lock (_lazyStores)
            {
                return _lazyStores.Value.FirstOrDefault(x => x.Id == id);
            }
        });
    }

    public async Task<IEnumerable<IkeaStore>> GetAll()
    {
        return await Task.Run(() =>
        {
            lock (_lazyStores)
            {
                return _lazyStores.Value;
            }
        });
    }
}