using Microsoft.AspNetCore.Mvc;

namespace Willprecht_Week3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Willprecht_Week3 : ControllerBase
    {

        [HttpPost(Name = "GetWeatherForecast")]
        public ActionResult<List<string>> IntList(List<int> inputList)
        {
            LogObject(inputList);
            List<string> rlist = new List<string>();
            List<int> newList = new List<int>();
            int counter = 0;

            if (inputList.Count > 0)
            {
                inputList.Sort();

                foreach (var val in inputList)
                {
                    if (counter > 0)
                    {
                        counter++;

                        newList.Add(val);

                        double avg = newList.Average();

                        double sum = newList.Sum(d => Math.Pow(d - avg, 2));

                        double stdDev = Math.Sqrt((sum) / (newList.Count - 1));

                        rlist.Add("Elements: " + counter + " Current Standard Deviation: " + stdDev);
                    }
                    else
                    {
                        counter++;
                        newList.Add(val);
                        rlist.Add("List is too small");
                    }

                }
            } else
            {
                rlist.Add("Please make sure you are entering numbers into the input.");
            }
            return rlist;
        }

        private void LogObject(List<int> inputList)
        {
            System.Console.WriteLine("Unsorted Values:");
            foreach (var val in inputList)
            {
                System.Console.WriteLine(val);
            }
        }
    }
}