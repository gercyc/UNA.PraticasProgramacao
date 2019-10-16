using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UNA.PraticasProgramacao.Core.Entidades;
using UNA.PraticasProgramacao.Web.BaseApis;

namespace UNA.PraticasProgramacao.Web.Pages.Shared
{
    public class ApiUtil
    {
        public async static Task<List<ItsMenu>> GetMenusList(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<ItsMenu>>(apiResponse);
                }
            }
        }
        public async static Task<List<T>> GetChartData<T>(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<T>>(apiResponse);
                }
            }
        }
    }
}
