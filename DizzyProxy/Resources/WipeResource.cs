using System.Threading.Tasks;

namespace DizzyProxy.Resources
{
    public class WipeResource : Resource
    {
        public bool CreateWipe()
            => CreateWipeAsync().Result;

        public async Task<bool> CreateWipeAsync()
        {
            Request request = new Request(Method.POST, "wipes");
            return await ExecuteAsync(request);
        }
    }
}