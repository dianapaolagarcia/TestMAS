using System;

using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using EmployeeApp.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
namespace DataRepository
{
    public class EmployeeContext
    {

        static HttpClient client = new HttpClient();


        public  async Task<List<Employee>> GetEmployeeAsync(string path)
        {
            
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                //employee = await response.Content.ReadAsAsync<Employee>();
                //employee = await response.Content.ReadAsAsync<Employee>();
                var data = await response.Content.ReadAsStringAsync();
                //var data = await response.Content.ReadAsAsync<List<Employee>>();

                //return data.to;
                return JsonConvert.DeserializeObject<List<Employee>>(data);
            }
            else
            {
                return null;
            }
            
        }

        public async Task<T> GetAsync<T>(Uri requestUrl)
        {

            var response = await client.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }

        static async Task RunAsync()
        {
            // Update port # in the following line.
            //client.BaseAddress = new Uri("http://masglobaltestapi.azurewebsites.net");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));


            

            var stringTask = client.GetStringAsync("http://masglobaltestapi.azurewebsites.net/api/Employees");

            var msg = await stringTask;
            Console.Write(msg);

            //try
            //{
            //    // Create a new employee
            //    Employee employee = null;

            //    // Get the employee
            //    employee = await GetEmployeeAsync(url.PathAndQuery);

            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            //Console.ReadLine();
        }
    }
}
