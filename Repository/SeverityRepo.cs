using AuditSeverityModule.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace AuditSeverityModule.Repository
{
    public class SeverityRepo: ISeverityRepo
    {
        HttpClient client;
        //IConfiguration config;

        public SeverityRepo()//IConfiguration configuration
        {
            //config = configuration;
            //baseAddress = new Uri(config["Links:Benchmark"]);
            client = new HttpClient();
        }

        public List<AuditBenchmark> Response()
        {
            try
            {

                List<AuditBenchmark> listFromAuditBenchmark = new List<AuditBenchmark>();

                HttpResponseMessage response = client.GetAsync("https://localhost:44347/api" + "/AuditBenchmark").Result; //client.BaseAddress
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    listFromAuditBenchmark = JsonConvert.DeserializeObject<List<AuditBenchmark>>(data);
                }
                return listFromAuditBenchmark;

            }
            catch (Exception e)
            {
                return null;
            }

        }

        public static List<AuditResponse> ActionToTakeAndStatus = new List<AuditResponse>()
        {
            new AuditResponse
            {
                RemedialActionDuration="No Action Needed",
                ProjectExexutionStatus="GREEN"
            },
            new AuditResponse
            {
                RemedialActionDuration="Action to be taken in 2 weeks",
                ProjectExexutionStatus="RED"
            },
            new AuditResponse
            {
                RemedialActionDuration = "Action to be taken in 1 week",
                 ProjectExexutionStatus="RED"
            }
        };

    }
}

