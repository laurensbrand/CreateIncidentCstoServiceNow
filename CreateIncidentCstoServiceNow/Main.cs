using System;
using System.Net.Http;
using System.Text;

namespace CreateIncidentCstoServiceNow
{
	class CreateIncident
    {
        private const int ARGS_LENGTH = 5;

		static void Main(string[] args)
		{
			string URL = "https://" + args[0] + ".service-now.com/api/now/v1/table/incident";
			string USERNAME = args[1];
			string PASSWORD = args[2];
            string SHORT_DESCRIPTION = args[3];
            string COMMENTS = args[4];
					
            CreateIncidentTicket(URL,USERNAME,PASSWORD,SHORT_DESCRIPTION,COMMENTS);
		}

		private static void CreateIncidentTicket(string URL, string USERNAME, string PASSWORD, string SHORT_DESCRIPTION, string COMMENTS)
		{
            /*
            string DATA = @"{
            ""short_description"": ""{0}"",
            ""comments"": ""{1}""
            }";
            */
			string DATA = @"{
            ""short_description"": ""{0}"",
            ""comments"": ""{1}""
            }";

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
        /*
        public static void Main(string[] args)
        {
            private const string URL = args[0];
        private const string DATA = @"{
                    ""name"": ""Component 2"",
                    ""description"": ""This is a JIRA component"",
                    ""leadUserName"": ""xx"",
                    ""assigneeType"": ""PROJECT_LEAD"",
                    ""isAssigneeTypeValid"": false,
                    ""project"": ""TP""}";
        string USERNAME = args[1];
        string PASSWORD = args[2];
        string SHORT_DESCRIPTION = args[3];
        string DESCRIPTION = args[4];
        int ARGS_LENGTH = 5;

        Console.WriteLine("Number of command line parameters = {0}",args.Length);
            if (args.Length >= ARGS_LENGTH) {
                for (int i = 0; i<args.Length; i++) {
					Console.WriteLine("Arg[{0}] = [{1}]", i, args[i]);
                }

    System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
    client.BaseAddress = new System.Uri(URL);
			byte[] cred = UTF8Encoding.UTF8.GetBytes(USERNAME + ":" + PASSWORD);
    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
			client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

			System.Net.Http.HttpContent content = new StringContent(DATA, UTF8Encoding.UTF8, "application/json");
    HttpResponseMessage messge = client.PostAsync(URL, content).Result;
    string description = string.Empty;
			if (messge.IsSuccessStatusCode) {
			    string result = messge.Content.ReadAsStringAsync().Result;
    Console.WriteLine(result);
                }
            }
        }
    }
}

    
                /*
			} else {
                Console.WriteLine("Only {0} parameters are supplied while {1} are expected.",args.Length,args_length);
				Console.WriteLine("Press any key to stop...");
				Console.ReadKey();
            }
        }
    }
}
*/