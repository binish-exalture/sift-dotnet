using Sift;
using System.Text;
using Xunit;

namespace Test.VerificationAPI
{
    public class Test
    {
        [Fact]
        public void TestVerificationCheckRequest()
        {
            //Please provide the valid api key in place of 'key'
            var apiKey = "key";
            var verificationCheckRequest = new VerificationCheckRequest
            {

                ApiKey = apiKey,
                Code = 655543,
                UserId = "haneeshv@exalture.com",
                VerifiedEntityId = "SOME_SESSION_ID",
                VerifiedEvent = "$login"
            };

            verificationCheckRequest.ApiKey = apiKey;

            Assert.Equal(Convert.ToBase64String(Encoding.Default.GetBytes(apiKey)),
                verificationCheckRequest.Request.Headers.Authorization!.Parameter);

            Assert.Equal("https://api.sift.com/v1/verification/check",
                         verificationCheckRequest.Request.RequestUri!.ToString());
        }

        [Fact]
        public void TestVerificationSendRequest()
        {
            //Please provide the valid api key in place of 'key'
            var apiKey = "key";
            //Please provide the valid session id in place of 'sessionId'
            var sessionId = "sessionId";
            var verificationSendRequest = new VerificationSendRequest
            {
                UserId = "haneeshv@exalture.com",
                ApiKey = apiKey,
                BrandName = "all",
                VerificationType = "$email",
                SendTo = "haneeshv@exalture.com",
                Language = "en",
                SiteCountry = "IN",
                Event = new VerificationSendEvent()
                {
                    Browser = new Browser()
                    {
                        user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                        content_language = "en-US",
                        accept_language = "en-GB",
                    },
                    IP = "192.168.1.1",
                    Reason = "$automated_rule",
                    SessionId = sessionId,
                    VerifiedEvent = "$login",
                    VerifiedEntityId = "SOME_SESSION_ID"
                }
            };

            verificationSendRequest.ApiKey = apiKey;

            Assert.Equal(Convert.ToBase64String(Encoding.Default.GetBytes(apiKey)),
                verificationSendRequest.Request.Headers.Authorization!.Parameter);

            Assert.Equal("https://api.sift.com/v1/verification/send",
                         verificationSendRequest.Request.RequestUri!.ToString());
        }

        [Fact]
        public void TestVerificationReSendRequest()
        {
            //Please provide the valid api key in place of 'key'
            var apiKey = "key";
            var verificationResendRequest = new VerificationReSendRequest
            {
                UserId = "haneeshv@exalture.com",
                ApiKey = apiKey,
                VerifiedEntityId = "SOME_SESSION_ID",
                VerifiedEvent = "$login"
            };
            verificationResendRequest.ApiKey = apiKey;

            Assert.Equal(Convert.ToBase64String(Encoding.Default.GetBytes(apiKey)),
                verificationResendRequest.Request.Headers.Authorization!.Parameter);

            Assert.Equal("https://api.sift.com/v1/verification/resend",
                         verificationResendRequest.Request.RequestUri!.ToString());
        }
    }
}
