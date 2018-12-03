using Common;
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

            UserLoginTest();

           // Function1();

            Console.ReadKey();
        }


        public static void Function1()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53035");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var id = 3;
                var res = client.GetAsync($"api/Crm/GetClient/{id}").Result;

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

        public static void UserLoginTest()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53035");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var userName = "levi";
                var password = "marantz";
                //var res = client.GetAsync($"api/Crm/GetClient/{id}").Result;
                var id = 3;
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
                    //return Content("Calling to Post failed");
                    Console.WriteLine("eeeeeeeeeeeeeeeeeee");
                }
            }
        }
    }
}

   
