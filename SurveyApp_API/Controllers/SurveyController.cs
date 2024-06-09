using SurveyApp_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SurveyApp_API.Controllers
{
    public class SurveyController : ApiController
    {
        string trueResponse = "true";
        string falseResponse = "false";

        DataClasses1DataContext db = new DataClasses1DataContext();


        // GET api/<controller>/5
        [HttpGet]
        public string Get()
        {
            dynamic users = (from u in db.SurveyDBs
                             select u);

            List<string> allUsers = new List<string>();

            string AllDataCombined= "";
           

            foreach (SurveyDB u in users)
            {
                AllDataCombined += u.Id.ToString() + "$" + u.FullNames.ToString() + "$" + u.Email.ToString() + "$"
                           + u.Age.ToString() + "$" + u.ContactNumber.ToString() + "$" + u.FOOD.ToString() + "$" +
                           u.MovieInterest.ToString() + "$" + u.RadioInterest.ToString() + "$" + u.EatOutInterest + "$" +
                           u.TvInterest.ToString() + "&";
              
            }
            
          
            return AllDataCombined;
        }

        // POST api/<controller>
        [HttpPost]
        public string Post([FromBody] surveyUser user)
        {
            if (!(user.Equals(null))){

                var newInfo = new SurveyDB { 
                 FullNames = user.name,
                 Email =  user.email,
                 Age =  user.age,
                 ContactNumber = user.contact,
                 FOOD =  user.food,
                 MovieInterest = user.movieInt,
                 RadioInterest =  user.radioInt,
                 EatOutInterest = user.eatInt,
                 TvInterest = user.tvInt,
                 };
                try
                {
                    db.SurveyDBs.InsertOnSubmit(newInfo);
                   
                   db.SubmitChanges();
                    return trueResponse;
                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                    return falseResponse;
                }
            }
            {
                return falseResponse;
            }
        }

       
    }
}