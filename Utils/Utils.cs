using Microsoft.AspNetCore.Mvc;

namespace asp_net_mvc_core_link_generation
{
    public class Utils {
        public static string GetControllerName<T>() where T : Controller {
            return typeof(T).Name.Replace(nameof(Controller), string.Empty);
        }
    }
}