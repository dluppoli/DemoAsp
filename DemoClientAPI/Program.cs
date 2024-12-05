using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoClientAPI
{
    public class IsEvenResult
    {
        public bool iseven { get; set; }
        public string ad { get; set; }
    }

    internal class Program
    {
        static async Task Main(string[] args)
        {
            /*
            Console.Write("Inserire l'hash della password: ");
            string pwd = Console.ReadLine();
            pwd = "b1b3773a05c0ed0176787a4f1574ff0075f7521e";
            var client = new RestClient($"https://api.pwnedpasswords.com");

            var request = new RestRequest("range/{hash}");
            request.AddParameter("hash", pwd.Substring(0, 5),ParameterType.UrlSegment);
            var response = await client.GetAsync(request);

            var splittedContent = response.Content.Split('\n');
            var myPassword = splittedContent.FirstOrDefault(s=> s.ToUpper().StartsWith(pwd.ToUpper().Substring(5)) );
            if (myPassword != null) 
            {
                string occorrenze = myPassword.Split(':')[1];
                Console.WriteLine($"Password non sicura. Apparsa {occorrenze} volte");
            }
            else
                Console.WriteLine("Complimenti password sicura!");
            */

            /*
            Console.WriteLine("Inserire il numeo");
            string numero = Console.ReadLine();

            var client = new RestClient("https://api.isevenapi.xyz/api");
            var request = new RestRequest("iseven/{number}");
            request.AddParameter("number", numero, ParameterType.UrlSegment);
            
            var response = await client.GetAsync<IsEvenResult>(request);

            Console.WriteLine(response.iseven);*/

            var client = new RestClient("https://webhook.site/c6d5a866-4398-4a33-9f86-6c8d9dc1a36e");
            var request = new RestRequest();

            var dato = new IsEvenResult()
            {
                iseven = true,
                ad = "Hello World"
            };

            request.AddJsonBody(dato);
            var response = await client.PostAsync(request);

            Console.ReadLine();
        }
    }
}
