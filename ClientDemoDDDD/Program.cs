using Common;
using Common.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClientDemoDDDD
{
    class Program
    {
        static void Main(string[] args)
        {

            //UserLoginTest();

            // GetClientTest();

            //GetAllclientLineTest(1);

            IssuingInvoiceTest(4);

            // GetAllClientTest();

            //Employee e1 = new Employee { FirstName = "emp1", LastName = "seler1", IsAdmin = false };
            //Client tmp = new Client { Address = "tt", ClientType = ClientTypeName.regular, FirstName = "llll", LastName = "mmm", WhoSold = e1 };
           // AddClientTest(tmp);

            Console.ReadKey();
        }

        private static void GetAllClientTest()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53035");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var res = client.GetAsync($"/api/Client/GetAllClients").Result;

                if (res.IsSuccessStatusCode)
                {
                    ICollection<Client> clients = res.Content.ReadAsAsync<ICollection<Client>>().Result;

                    Console.WriteLine("ssssssssssssssss");
                    //Console.WriteLine(c.FirstName);
                }
                else
                {
                    Console.WriteLine("eeeeeeeeeeeeeeeeeee");
                }
            }
        }

        private static void AddClientTest(Client tmp)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53035");             
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var res = client.PostAsJsonAsync($"/api/Client/AddClient", tmp).Result;

                if (res.IsSuccessStatusCode)
                {
                    var c = res.Content.ReadAsAsync<Client>().Result;

                    Console.WriteLine("ssssssssssssssss");
                    Console.WriteLine(c.FirstName);
                }
                else
                {
                    Console.WriteLine("eeeeeeeeeeeeeeeeeee");
                }
            }
        }

        private static void IssuingInvoiceTest(int clientId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53035");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var res = client.GetAsync($"/api/Invoice/IssuingInvoice/{clientId}").Result;

                if (res.IsSuccessStatusCode)
                {
                    var json = res.Content.ReadAsStringAsync().Result;
                    IEnumerable<Call> result = JsonConvert.DeserializeObject<IEnumerable<Call>>(json).ToList();

                    Console.WriteLine("ssssssssssssssss");
                    foreach (var item in result)
                    {
                        Console.WriteLine(item.DestinationNumber);
                    }
                }
                else
                {
                    Console.WriteLine("eeeeeeeeeeeeeeeeeee");
                }
            }
        }

        private static void GetAllclientLineTest(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53035");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
              
                var res = client.GetAsync($"/api/Line/GetAllClientLines/{id}").Result;

                if (res.IsSuccessStatusCode)
                {
                    var json = res.Content.ReadAsStringAsync().Result;
                    IEnumerable<Line> result = JsonConvert.DeserializeObject<IEnumerable<Line>>(json).ToList();

                    Console.WriteLine("ssssssssssssssss");
                    foreach (var item in result)
                    {
                       Console.WriteLine(item.LineNumber);
                    }
                }
                else
                {
                    Console.WriteLine("eeeeeeeeeeeeeeeeeee");
                }
            }
        }

        private static void GetClientTest()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53035");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var id = 3;
                var res = client.GetAsync($"api/Client/GetClient/{id}").Result;

                if (res.IsSuccessStatusCode == true)
                {
                    var json = res.Content.ReadAsStringAsync().Result;
                    UserLogin result = JsonConvert.DeserializeObject<UserLogin>(json);

                    Console.WriteLine("sucsses!!!");
                    Console.WriteLine(result.UserName);
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
        }

        private static void UserLoginTest()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53035");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var userName = "levi";
                var password = "marantz";                
                var res = client.GetAsync($"/api/UserLogin/Login/{userName}/{password}").Result;

                if (res.IsSuccessStatusCode == true)
                {
                    var json = res.Content.ReadAsStringAsync().Result;
                    Client result = JsonConvert.DeserializeObject<Client>(json);

                    Console.WriteLine("ssssssssssssssss");
                    Console.WriteLine(result.FirstName);
                }
                else
                {
                    Console.WriteLine("eeeeeeeeeeeeeeeeeee");
                }
            }
        }
    }
}

   
