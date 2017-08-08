using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CreateIncidentCstoServiceNow
{
	class CreateIncident
    {
        private const int ARGS_LENGTH = 5;

		static void Main(string[] args)
		{
			Console.WriteLine("Number of command line parameters = {0}", args.Length);
            if (args.Length >= ARGS_LENGTH)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    Console.WriteLine("Arg[{0}] = [{1}]", i, args[i]);
                }
            }
			string URL = "https://" + args[0] + ".service-now.com/api/now/v1/table/incident";
			string USERNAME = args[1];
			string PASSWORD = args[2];
            string SHORT_DESCRIPTION = args[3];
            string COMMENTS = args[4];
					
            CreateIncidentTicket(URL,USERNAME,PASSWORD,SHORT_DESCRIPTION,COMMENTS);
		}

		private static void CreateIncidentTicket(string URL, string USERNAME, string PASSWORD, string SHORT_DESCRIPTION, string COMMENTS)
		{
            string DATA = string.Format(@"{{
            ""short_description"":""{0}"",
            ""comments"":""{1}""}}"
                                        , 
                                        SHORT_DESCRIPTION,
                                        COMMENTS);


			System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
			client.BaseAddress = new System.Uri(URL);
			byte[] cred = UTF8Encoding.UTF8.GetBytes("admin:YYtYYt01");
			client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
			client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

			System.Net.Http.HttpContent content = new StringContent(DATA, UTF8Encoding.UTF8, "application/json");
			HttpResponseMessage messge = client.PostAsync(URL, content).Result;
			string description = string.Empty;
            Console.WriteLine("Result code is {0} with message {1}",messge.IsSuccessStatusCode, messge.StatusCode);
			if (messge.IsSuccessStatusCode)
			{
				string result = messge.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);
			}
		}
	}
}