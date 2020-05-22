using GorticLib;
using GorticLib.RequestParameter;
using Newtonsoft.Json;
using System;

namespace GorticLibExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var gortic = new GorticLibCrawler();

            var parameters = new GorticLibParameters();
            parameters.Url = "https://pje.trt12.jus.br/pje-consulta-api/api/processos/121212";
            parameters.ContentType = GorticLib.Helpers.RequestHelper.ContentType.Json;


            gortic.GorticClientProperties.SetRequestParameters(parameters);

            SaveAnyImages(200, gortic);
        }

        public static void SaveAnyImages(int qtdImages, GorticLibCrawler gortic)
        {
            for (int i = 0; i < qtdImages; i++)
            {
                var response = gortic.GorticClientProperties.MakeRequest();

                if (response.Item1 != System.Net.HttpStatusCode.OK)
                    continue;

                var json = JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(response.Item2);

                Console.Write($"{Environment.NewLine}{json.Value<string>("imagem")}{Environment.NewLine}");
            }

            Console.ReadLine();
        }
    }
}
