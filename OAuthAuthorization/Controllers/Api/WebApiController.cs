using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace OAuthAuthorization.Controllers.Api
{


    [RoutePrefix("api/WebApi")]

    public class WebApiController : ApiController
    {
        [Route("Get")]
        public IEnumerable<string> Get()
        {
            return new string[] { "Hello REST API", "I am Authorized" };
        }

        // GET api/WebApi/5 
        
        [Authorize]
        [Route("Get/{id}")]


        public string Get(int id)
        {
            return "Hello Authorized API with ID = " + id;
        }
        // POST api/WebApi  
        [Route("Login")]
        [HttpGet]
        public async Task<HttpResponseMessage> Login()
        {

            if (true)
            {

                FormsAuthentication.SetAuthCookie("KuldeepNAgeshwar", false);
                var authTicket = new FormsAuthenticationTicket(1, "KuldeepNageshwar", DateTime.Now, DateTime.Now.AddMinutes(5), false, Convert.ToString("User"));
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                return Request.CreateResponse(HttpStatusCode.OK, authCookie);

            }
        }
        [Route("Logout")]
        [HttpGet]

        public async Task<HttpResponseMessage> Logout()
        {

            if (true)
            {
                FormsAuthentication.SignOut();

                return Request.CreateResponse(HttpStatusCode.OK);

            }
        }





        // DELETE api/WebApi/5  
        public void Delete(int id)
        {
        }
    }
}
