using System;
using System.Net.Http;

namespace FetchCovid19Data
{
    public class FetchData
    {
        private HttpClient client;
        public FetchData()
        {
            client = new HttpClient();
            //client.BaseAddress = new Uri("https://www.mohfw.gov.in/");
        }

        public string getData(){
            string Result="";
            try{
            var response  = client.GetStringAsync("https://www.mohfw.gov.in/");
            response.Wait();
            Result =  response.Result;
            }catch(Exception ex){

            }           
            return Result;
        }


    }
}