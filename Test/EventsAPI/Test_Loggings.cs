using Sift;
using System.Collections.ObjectModel;
using Xunit;

namespace Test.EventsAPI
{
    public class Test_Loggings
    {
        [Fact]
        public void TestLoginEvent()
        {
            //Please provide the valid session id in place of 'sessionId'
            var sessionId = "sessionId";
            var login = new Login
            {
                user_id = "test_dotnet_login_event",
                session_id = sessionId,
                user_email = "bill@gmail.com",
                login_status = "$success",
                ip = "128.148.1.135",
                failure_reason = "$account_unknown",
                social_sign_on_type = "$facebook",
                username = "test_user_name",
                site_country = "US",
                site_domain = "sift.com",
                brand_name = "sift",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                account_types = new ObservableCollection<string>() { "merchant", "premium" }
            };

            Assert.Equal("{\"$type\":\"$login\",\"$user_id\":\"test_dotnet_login_event\",\"$session_id\":\"sessionId\"," +
                                 "\"$user_email\":\"bill@gmail.com\",\"$login_status\":\"$success\",\"$failure_reason\":\"$account_unknown\"," +
                                 "\"$social_sign_on_type\":\"$facebook\",\"$username\":\"test_user_name\",\"$ip\":\"128.148.1.135\",\"$browser\":" +
                                 "{\"$user_agent\":\"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) " +
                                 "Chrome/56.0.2924.87 Safari/537.36\",\"$accept_language\":\"en-US\",\"$content_language\":\"en-GB\"},\"$brand_name\":" +
                                 "\"sift\",\"$site_country\":\"US\",\"$site_domain\":\"sift.com\",\"$account_types\":[\"merchant\",\"premium\"]}",
                                 login.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = login
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = login,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }
    }
}
