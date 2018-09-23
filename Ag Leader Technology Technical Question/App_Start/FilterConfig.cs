using System.Web;
using System.Web.Mvc;

namespace Ag_Leader_Technology_Technical_Question
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
