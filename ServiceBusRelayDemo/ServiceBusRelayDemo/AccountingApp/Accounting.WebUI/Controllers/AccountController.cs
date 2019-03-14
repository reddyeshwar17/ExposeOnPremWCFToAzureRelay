using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Accounting.WebUI.Models;
using Microsoft.ServiceBus;
using System.ServiceModel;
using Accounting.Service.Contracts;
using Accounting.WebUI.Channels;

namespace Accounting.WebUI.Controllers
{

    public class AccountController : Controller
    {
        [HttpPost]
        public ViewResult GetBalance(long accountNumber)
        {
           // ServiceBusEnvironment.SystemConnectivity.Mode = ConnectivityMode.Tcp;
            var cf = new ChannelFactory<IAccountServiceChannel>("AccountService");
            
            var accountBalance = 0d;
            var serviceId = "0";
            using (var ch = cf.CreateChannel())
            {
                var response = ch.GetAccountBalance(accountNumber);
                accountBalance = response.AccountBalance;
                serviceId = response.ServiceId;
            }
            
            return View("AccountBalance",
                new AccountViewModel()
                {
                    AccountBalance = accountBalance,
                    AccountNumber = accountNumber,
                    ServiceId = serviceId
                });
        }

        [HttpGet]
        public ViewResult Detail()
        {
            return View("AccountBalance", new AccountViewModel());
        }

        //calling service bus exposed services...
        //for azure bus there are no urls, namespase will act as url..we need add http:// to the url
        //https://namespace.servicebus.windows.net like this

        /*  using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;

namespace SCMPortal.Common
{
    public class CreateToken
    {
        public static string createToken(string resourceUri, string keyName, string key)
        {
            TimeSpan sinceEpoch = DateTime.UtcNow - new DateTime(1970, 1, 1);
            var week = 60 * 60 * 24 * 7;
            var expiry = Convert.ToString((int)sinceEpoch.TotalSeconds + week);
            string stringToSign = HttpUtility.UrlEncode(resourceUri) + "\n" + expiry;
            HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key));
            var signature = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(stringToSign)));
            var sasToken = String.Format(CultureInfo.InvariantCulture, "SharedAccessSignature sr={0}&sig={1}&se={2}&skn={3}", HttpUtility.UrlEncode(resourceUri), HttpUtility.UrlEncode(signature), expiry, keyName);
            return sasToken;
        }

        public static HttpWebRequest GetExtServiceInstance(string selectedEnv, string method)
        {
            //CreateToken token = new CreateToken();
            var sasToken = createToken(ConfigurationManager.AppSettings["sbUrl1"], ConfigurationManager.AppSettings["SbSASKeyName1"], ConfigurationManager.AppSettings["SbSASKeyValue1"]);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["sbUrl1"] + selectedEnv +"/"+ method);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers.Add(HttpRequestHeader.Authorization, sasToken);
            return request;
        }

        public static HttpWebRequest GetPOAutomationServiceInstance(string selectedEnv, string method)
        {
            var sasToken = createToken(ConfigurationManager.AppSettings["SbUrl"], ConfigurationManager.AppSettings["SbSASKeyName"], ConfigurationManager.AppSettings["SbSASKeyValue"]);
            var request = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["SbUrl"] + "/" + selectedEnv + "/" + method);
            //request = System.Text.RegularExpressions.Regex.Replace(request.ToString(), "MachinePlaceHolder", environment);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers.Add(HttpRequestHeader.Authorization, sasToken);
            return request;
        }
        // here request is above method request and requestData is our data
        //HttpWebRequest request = CreateToken.GetPOAutomationServiceInstance(selectedEnv, CreateEditPO)

        //var content = CreateToken.Results(request, poCreateRequests);
                var result = JsonConvert.DeserializeObject<List<CreatePOResponse>>(content);

        public static string Results(dynamic request, dynamic requestData)
        {
            string objectToSend = JsonConvert.SerializeObject(requestData, Formatting.None
             , new JsonSerializerSettings()
             {
                 DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
                 DateTimeZoneHandling = DateTimeZoneHandling.Utc
             });
            var byteArray = Encoding.UTF8.GetBytes(objectToSend);
            request.ContentLength = byteArray.Length;
            var dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            HttpWebResponse response = null;
            try
            {
                response = request.GetResponse() as HttpWebResponse;
                //Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Status code not 200 " + response.StatusCode);
            }
            catch (Exception ex)
            {
                throw;
                //return null;
            }
            string content;

            using (var reader = new StreamReader(response.GetResponseStream(), new UTF8Encoding(false)))
            {
                content = reader.ReadToEnd();
            }
            return content;
        }

    }
}*/
    }
}