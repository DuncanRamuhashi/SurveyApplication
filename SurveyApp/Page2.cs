using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurveyApp
{
    public partial class Page2 : UserControl
    {
        surveyUser user = new surveyUser();
        List<surveyUser> users = new List<surveyUser>();
        Uri baseUri = new Uri("https://localhost:44315/api");
        private HttpClient httpClient;
        public Page2()
        {
            InitializeComponent();
            
            httpClient = new HttpClient();
            httpClient.BaseAddress = baseUri;
            
            HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress + "/Survey/Get").Result;

            string apiResponse = response.Content.ReadAsStringAsync().Result;


            string validUser = JsonConvert.DeserializeObject<string>(apiResponse);

            
            List<string> allUsersDetailsMerged = new List<string>();
            String[] words = validUser.Split('&');
            foreach (string s in words)
            {
                allUsersDetailsMerged.Add(s.Trim());

            }
            allUsersDetailsMerged.Remove(allUsersDetailsMerged.Last());

            foreach (string u in allUsersDetailsMerged)
            {
                string format = u.Trim().ToString();
                string[] user = format.Split('$');
                surveyUser subUser = new surveyUser();
                subUser.id = int.Parse(user[0].ToString());
                subUser.name = user[1].ToString();
                subUser.email = user[2].ToString();
                subUser.age = int.Parse(user[3].ToString());
                subUser.contact = user[4].ToString();
                subUser.food = user[5].ToString();
                subUser.movieInt = int.Parse(user[6].ToString());
                subUser.radioInt = int.Parse(user[7].ToString());
                subUser.eatInt = int.Parse(user[8].ToString());
                subUser.tvInt = int.Parse(user[9].ToString());

                users.Add(subUser);
            }


            // calculation
            calcTotalSurveys();
            calcAverage();
            calcOldAge();
            calcYoungAge();
            calcPercentagePizza();
            calcPercentagePasta();
            calcPercentagePapnWors();
            calcRatings();
        }
        private void calcRatings(){
          
            int TotalRatings = 0;
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].movieInt>0)
                {
                    TotalRatings += users[i].movieInt;
                }
                if (users[i].radioInt > 0)
                {
                    TotalRatings += users[i].radioInt;
                }
                if (users[i].eatInt > 0)
                {
                    TotalRatings += users[i].eatInt;
                }
                if (users[i].tvInt > 0)
                {
                    TotalRatings += users[i].tvInt;
                }


            }
            //movie
            int movies = 0;
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].movieInt > 0)
                {
                    movies += users[i].movieInt;
                }

            }
            int dividedRate = (int) movies/ TotalRatings;
            txtPeopleMovies.Text = dividedRate.ToString();
            //radio
            int radio = 0;
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].radioInt > 0)
                {
                    radio += users[i].radioInt;
                }

            }
            int dividedRadioRate = (int)radio/TotalRatings;
            txtPeopleRadio.Text = dividedRadioRate.ToString();
            //eat
            int eat = 0;
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].eatInt > 0)
                {
                    eat += users[i].eatInt;
                }

            }
            int dividedEatRate = (int) eat/ TotalRatings;
            txtPeopleEat.Text = dividedEatRate.ToString();
            //tv
            int tv = 0;
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].radioInt > 0)
                {
                    tv += users[i].radioInt;
                }

            }
            int dividedTVRate = (int)tv / TotalRatings;
            txtPeopleRadio.Text = dividedTVRate.ToString();

        }
        private void calcPercentagePapnWors()
        {
            int pInt = 0;
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].food.Contains("Pap"))
                {
                    pInt += 1;
                }
            }

            double percentage = (double)pInt / users.Count * 100;


            txtPercPapWors.Text = Math.Round(percentage, 1).ToString() + " %";
        }
        private void calcPercentagePasta()
        {
            int pastaInt = 0;
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].food.Contains("Pasta"))
                {
                    pastaInt += 1;
                }
            }

            double percentage = (double)pastaInt / users.Count * 100;


            txtPercPasta.Text = Math.Round(percentage, 1).ToString() + " %";
        }
        private void calcPercentagePizza() {
            int pizzaInt = 0;
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].food.Contains("Pizza")) {
                    pizzaInt += 1;
                }
            }

            double percentage = (double) pizzaInt / users.Count * 100;

            
            txtPercPizza.Text = Math.Round(percentage, 1).ToString() + " %";
        }

        private void calcYoungAge()
        {
            List<int> Ages = new List<int>();
            for (int i = 0; i < users.Count; i++)
            {
              Ages.Add(users[i].age);
            }
            
            txtYoungAge.Text = Ages.Min().ToString() + " Years";

        }
        private void calcOldAge()
        {
            List<int> Ages = new List<int>();
         
            
            for (int i = 0; i < users.Count; i++) {
                Ages.Add(users[i].age);
            }
            txtOldAge.Text = Ages.Max().ToString() + " Years";

        }
        private void calcAverage()
        {
           
           txtAverageAge.Text = Math.Round(users.Average(p => p.age), 1).ToString() ;

        }
        private void calcTotalSurveys() {
            txtSurveyNumber.Text =  users.Count.ToString();

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            httpClient = new HttpClient();
            httpClient.BaseAddress = baseUri;

            HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress + "/Survey/Get").Result;

            string apiResponse = response.Content.ReadAsStringAsync().Result;


            string validUser = JsonConvert.DeserializeObject<string>(apiResponse);


            List<string> allUsersDetailsMerged = new List<string>();
            String[] words = validUser.Split('&');
            foreach (string s in words)
            {
                allUsersDetailsMerged.Add(s.Trim());

            }
            allUsersDetailsMerged.Remove(allUsersDetailsMerged.Last());
            users.Clear();
            foreach (string u in allUsersDetailsMerged)
            {
                string format = u.Trim().ToString();
                string[] user = format.Split('$');
                surveyUser subUser = new surveyUser();
                subUser.id = int.Parse(user[0].ToString());
                subUser.name = user[1].ToString();
                subUser.email = user[2].ToString();
                subUser.age = int.Parse(user[3].ToString());
                subUser.contact = user[4].ToString();
                subUser.food = user[5].ToString();
                subUser.movieInt = int.Parse(user[6].ToString());
                subUser.radioInt = int.Parse(user[7].ToString());
                subUser.eatInt = int.Parse(user[8].ToString());
                subUser.tvInt = int.Parse(user[9].ToString());

                users.Add(subUser);
            }


            // calculation
            calcTotalSurveys();
            calcAverage();
            calcOldAge();
            calcYoungAge();
            calcPercentagePizza();
            calcPercentagePasta();
            calcPercentagePapnWors();
            calcRatings();
            Page2 os = new Page2();
            os.Show();
        }
    }
}
