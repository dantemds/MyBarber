using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Mybarber.Helpers
{
    public static class Extensions
    {

        public static void AddPagination (this HttpResponse response,
            int currentPage,int itemsPage, int totalItems, int totalPages)
        {

            var camelCaseFormatter = new JsonSerializerSettings();
            camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();


            var paginationHeader = new PaginationHeader(currentPage, itemsPage, totalItems, totalPages);
            response.Headers.Add("Pagination", JsonConvert.SerializeObject(paginationHeader,camelCaseFormatter));
            response.Headers.Add("Acces-Control-Expose-Header", "Pagination");


        }

     
    }
}
