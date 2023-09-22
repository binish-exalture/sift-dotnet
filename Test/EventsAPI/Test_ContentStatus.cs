using Sift;
using Xunit;

namespace Test.EventsAPI
{
    public class Test_ContentStatus
    {
        [Fact]
        public void TestContentStatusEvent()
        {
            var contentStatus = new ContentStatus
            {
                user_id = "billy_jones_301",
                session_id = "gigtleqddo84l8cm15qe4il",
                content_id = "9671500641",
                status = "$paused",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                brand_name = "sift",
                site_country = "US",
                site_domain = "sift.com",
                user_email = "billjones1@example.com",
                verification_phone_number = "+123456789012"
            };

            string contentStatusbody = "{\"$type\":\"$content_status\",\"$user_id\":\"billy_jones_301\",\"$session_id\":\"gigtleqddo84l8cm15qe4il\",\"$content_id\":\"9671500641\",\"$status\":\"$paused\",\"$browser\":{\"$user_agent\":\"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36\",\"$accept_language\":\"en-US\",\"$content_language\":\"en-GB\"},\"$brand_name\":\"sift\",\"$site_country\":\"US\",\"$site_domain\":\"sift.com\",\"$user_email\":\"billjones1@example.com\",\"$verification_phone_number\":\"+123456789012\"}";

            Assert.Equal(contentStatusbody, contentStatus.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = contentStatus
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = contentStatus,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }
    }
}
