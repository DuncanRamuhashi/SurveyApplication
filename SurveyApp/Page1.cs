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
    public partial class Page1 : UserControl
    {
        surveyUser user = new surveyUser();
        Uri baseUri = new Uri("https://localhost:44315/api");
        private HttpClient httpClient;

        string foodCombo = "";
        public Page1()
        {
            //https://localhost:44315/
            InitializeComponent();
            httpClient = new HttpClient();
            httpClient.BaseAddress = baseUri;
         


           


        }
       
         private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ___________________Click(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) &&
              !string.IsNullOrEmpty(txtNumber.Text) &&
                  !string.IsNullOrEmpty(txtEmail.Text) &&
                txtDatePicker.Value != null)
            {
                user.name = txtName.Text;
                user.email = txtEmail.Text;
                user.age = calcAge(txtDatePicker.Value);

                user.contact = txtNumber.Text;

                foodPicker();
                user.food = foodCombo;
                radiobuttonSetter();
                if (ageLimiter(user.age).Equals(true)){
                    string userData = JsonConvert.SerializeObject(user);
                    StringContent content = new StringContent(userData, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = httpClient.PostAsync(httpClient.BaseAddress + "/Survey/Post", content).Result;

                    string apiResponse = response.Content.ReadAsStringAsync().Result;


                    string validUser = JsonConvert.DeserializeObject<string>(apiResponse);
                    if (validUser.Equals("true"))
                    {
                        MessageBox.Show("Submitted+");
                    }
                    else
                    {
                        MessageBox.Show("Not Submitted-");
                    }
                } else
                {
                    MessageBox.Show("Age Retricted( Must be between 5 and 120!!");
                }

            
            }
            else {
                MessageBox.Show("Some details missing!!");
            }
        }

        private void check11_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void radiobuttonSetter() {
            //moviess
            if (m11.Checked == (true))
            {
                user.movieInt = 1;
            }
            if (m21.Checked == (true))
            {
                user.movieInt = 2;
            }
            if (m31.Checked == (true))
            {
                user.movieInt = 3;
            }
            if (m41.Checked == (true))
            {
                user.movieInt = 4;
            }
            if (m51.Checked == (true))
            {
                user.movieInt = 5;
            }

            // radio
            if (r12.Checked == (true))
            {
                user.radioInt = 1;
            }
            if (r22.Checked == (true))
            {
                user.radioInt = 2;
            }
            if (r32.Checked == (true))
            {
                user.radioInt = 3;
            }
            if (r42.Checked == (true))
            {
                user.radioInt = 4;
            }
            if (r52.Checked == (true))
            {
                user.radioInt = 5;
            }

            //Eat out
            if (e13.Checked == (true))
            {
                user.eatInt = 1;
            }
            if (e23.Checked == (true))
            {
                user.eatInt = 2;
            }
            if (e33.Checked == (true))
            {
                user.eatInt = 3;
            }
            if (e43.Checked == (true))
            {
                user.eatInt = 4;
            }
            if (e53.Checked == (true))
            {
                user.eatInt = 5;
            }

            // TV
            if (t14.Checked == (true))
            {
                user.tvInt = 1;
            }
            if (t24.Checked == (true))
            {
                user.tvInt = 2;
            }
            if (t34.Checked == (true))
            {
                user.tvInt = 3;
            }
            if (t44.Checked == (true))
            {
                user.tvInt = 4;
            }
            if (t54.Checked == (true))
            {
                user.tvInt = 5;
            }

        }

        //Age Checker
        private int calcAge(DateTime date){
            
            int Born_year = date.Year;
            DateTime dateTime = DateTime.Now;
            int Current_year = dateTime.Year;

            return Current_year - Born_year;
        }
        // food picker
        private void foodPicker() {
            foodCombo = "";
            if (txtpizza.Checked == true) {
                foodCombo += "Pizza" +" ";
            }
            if (txtpasta.Checked == true) {
                foodCombo += "Pasta" + " ";
            }
            if (txtPnW.Checked == true)
            {
                foodCombo += "Pap and Wors" + " ";
            }
            if (txtOther.Checked == true)
            {
                foodCombo += "Other" + " ";
            }
        }
        // Age limiter
        private bool ageLimiter(int age) {
            if (age < 5 || age > 120)
            {
                return false;
            }
            else {
                return true;
            }

        }
    }
}
