using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Timers;
using FetchCovid19Data.Models;

namespace FetchCovid19Data
{
    class Program
    {
        static void Main(string[] args)
        {
            FetchData fetchData = new FetchData();
            pushDataInDB(fetchData.getData());
            //1 hour  = 3.6e+6 millisecond
            //Timer timer = new Timer(3.6e+6);
            //timer.Elapsed += (s, e) =>
            //{
            //    pushDataInDB(fetchData.getData());
            //};
            //timer.Start();

        }

        static void pushDataInDB(string Result)
        {
            if (Result != "")
            {
                List<string> content = new List<string>();
                var rec = Result.Split("div id=\"cases\"")[1]
                                .Split("table")[5]
                                .Split("tbody")[1]
                                .Split("td");
                for (int i = 1; i < rec.Length; i += 2)
                {
                    content.Add(rec[i].Split(">")[1].TrimEnd(new Char[] { '<', '/' }));
                }

                List<InfectionMaster> Infections = new List<InfectionMaster>();
                COVID19Context context = new COVID19Context();
                var states = context.StateMaster.Where(x => x.CountryMasterAutoId == 101).ToList();

                for (int i = 0; i < content.Count - 5; i += 6)
                {
                    InfectionMaster InfectionMaster = new InfectionMaster();

                    InfectionMaster.AreaType = "state";
                    InfectionMaster.StateMasterAutoId = states.Where(s => s.StateName == content[i + 1]).FirstOrDefault().StateMasterAutoId;
                    InfectionMaster.TotalConfirmedCasesNational = int.Parse(content[i + 2]);
                    InfectionMaster.TotalConfirmedCasesForeignNational = int.Parse(content[i + 3]);
                    InfectionMaster.Cured = int.Parse(content[i + 4]);
                    InfectionMaster.Death = int.Parse(content[i + 5]);
                    Infections.Add(InfectionMaster);
                }
                context.UpdateRange(Infections);
                context.SaveChanges();
            }
        }
    }
}
