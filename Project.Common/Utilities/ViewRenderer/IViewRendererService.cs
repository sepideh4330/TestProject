using System.Threading.Tasks;

namespace Project.Common.Utilities.ViewRenderer
{
    public interface IViewRendererService
    {
        Task<string> RenderViewToStringAsync(string viewNameOrPath);
        Task<string> RenderViewToStringAsync<TModel>(string viewNameOrPath, TModel model);
    }
}
