using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Task5._1
{

    public class UserTwo
    {
        public int id { get; set; }
        public string name { get; set; }
        public int year { get; set; }
        public string color { get; set; }
        public string pantone_value { get; set; }
    }
    public class User
    {
        public int id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string avatar { get; set; }
    }

    public class Support
    {
        public string url { get; set; }
        public string text { get; set; }
    }

    public class Page
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public User[] data { get; set; }

        public UserTwo[] dataTwo { get; set; }
        public Support support { get; set; }
    }

    public sealed class PostUser
    {
        public string Name { get; set; }
        public string Job { get; set; }
    }

    public sealed class Register
    {

        public string email { get; set; }

        public string password { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var http = new HttpClient())
            {


                var result = http.GetAsync("https://reqres.in/api/users?page=2").GetAwaiter().GetResult();

                if (result.StatusCode == HttpStatusCode.NotFound)
                {
                    Console.WriteLine("Not Fount");
                }

                Console.WriteLine(result.StatusCode);
                string data = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Page p = JsonConvert.DeserializeObject<Page>(data);

                Console.WriteLine(data);

                var result2 = http.GetAsync("https://reqres.in/api/users/2").GetAwaiter().GetResult();

                Console.WriteLine(result2.StatusCode);
                string data2 = result2.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                User p2 = JsonConvert.DeserializeObject<User>(data2);

                Console.WriteLine(data2);

                var result3 = http.GetAsync("https://reqres.in/api/users/23").GetAwaiter().GetResult();

                Console.WriteLine(result3.StatusCode);
                string data3 = result3.Content.ReadAsStringAsync().GetAwaiter().GetResult();


                Console.WriteLine(data3);

                var result4 = http.GetAsync("https://reqres.in/api/unknown").GetAwaiter().GetResult();

                Console.WriteLine(result4.StatusCode);
                string data4 = result4.Content.ReadAsStringAsync().GetAwaiter().GetResult();


                Console.WriteLine(data4);

                var result5 = http.GetAsync("https://reqres.in/api/unknown/2").GetAwaiter().GetResult();

                Console.WriteLine(result5.StatusCode);
                string data5 = result5.Content.ReadAsStringAsync().GetAwaiter().GetResult();


                Console.WriteLine(data5);

                var result6 = http.GetAsync("https://reqres.in/api/unknown/23").GetAwaiter().GetResult();

                Console.WriteLine(result6.StatusCode);
                string data6 = result6.Content.ReadAsStringAsync().GetAwaiter().GetResult();


                Console.WriteLine(data6);


                Console.WriteLine("Now It's time to make Post Requests: ");

                var postUser = new PostUser()
                {
                    Name = "Vlad",
                    Job = "software engineer"
                };

                string serializedPostUser = JsonConvert.SerializeObject(postUser);

                var postResponse = http.PostAsync(
                    "https://reqres.in/api/users",
                    new StringContent(
                        serializedPostUser,
                        Encoding.UTF8,
                        "application/json"))
                    .GetAwaiter().GetResult();

                Console.WriteLine($"{postResponse.StatusCode}   {postResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult()}");

                var postRegister = new Register()
                { 
                    email = "eve.holt@reqres.in",
                    password = "pistol"
                };

                string serializePostRegister = JsonConvert.SerializeObject(postRegister);

                var postResponse2 = http.PostAsync("https://reqres.in/api/register", new StringContent(serializePostRegister, Encoding.UTF8, "application/json")).GetAwaiter().GetResult();
                Console.WriteLine($"{postResponse2.StatusCode}   {postResponse2.Content.ReadAsStringAsync().GetAwaiter().GetResult()}");

                var postRegister2 = new Register()
                {
                    email = "eve.holt@reqres.in"
                };

                string serializePostRegister2 = JsonConvert.SerializeObject(postRegister2);

                var postResponse3 = http.PostAsync("https://reqres.in/api/register", new StringContent(serializePostRegister2, Encoding.UTF8, "application/json")).GetAwaiter().GetResult();
                Console.WriteLine($"{postResponse3.StatusCode}   {postResponse3.Content.ReadAsStringAsync().GetAwaiter().GetResult()}");

                string serializeLoginRegister = JsonConvert.SerializeObject(postRegister);

                var postResponse4 = http.PostAsync("https://reqres.in/api/login", new StringContent(serializeLoginRegister, Encoding.UTF8, "application/json")).GetAwaiter().GetResult();
                Console.WriteLine($"{postResponse4.StatusCode}   {postResponse4.Content.ReadAsStringAsync().GetAwaiter().GetResult()}");

                string serializeLoginRegister2 = JsonConvert.SerializeObject(postRegister2);

                var postResponse5 = http.PostAsync("https://reqres.in/api/login", new StringContent(serializeLoginRegister2, Encoding.UTF8, "application/json")).GetAwaiter().GetResult();
                Console.WriteLine($"{postResponse5.StatusCode}   {postResponse5.Content.ReadAsStringAsync().GetAwaiter().GetResult()}");

            }

        }
    }
}