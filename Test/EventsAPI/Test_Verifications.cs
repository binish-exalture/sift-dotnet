using Sift;
using Xunit;

namespace Test.EventsAPI
{
    public class Test_Verifications
    {
        [Fact]
        public void TestVerificationEvent()
        {
            var sessionId = "sessionId";
            var verification = new Verification
            {
                user_id = "billy_jones_301",
                session_id = sessionId,
                status = "$pending",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-GB",
                    content_language = "en-US"
                },
                verified_event = "$login",
                verified_entity_id = "123",
                verification_type = "$sms",
                verified_value = "14155551212",
                reason = "$user_setting",
                brand_name = "xyz",
                site_country = "AU",
                site_domain = "somehost.example.com"
            };

            Assert.Equal("{\"$type\":\"$verification\",\"$user_id\":\"billy_jones_301\",\"$session_id\":\"sessionId\",\"$status\":\"$pending\",\"$browser\":{\"$user_agent\":\"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36\",\"$accept_language\":\"en-GB\",\"$content_language\":\"en-US\"},\"$verified_event\":\"$login\",\"$verified_entity_id\":\"123\",\"$verification_type\":\"$sms\",\"$verified_value\":\"14155551212\",\"$reason\":\"$user_setting\",\"$brand_name\":\"xyz\",\"$site_country\":\"AU\",\"$site_domain\":\"somehost.example.com\"}",
                                 verification.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = verification
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = verification,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }
    }
}
