using Sift;
using Sift.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;
using Xunit;

namespace Test
{
    public class Test
    {
               

        [Fact]
        public void TestCustomEventRequest()
        {
            // Construct custom events with required fields
            var makeCall = new CustomEvent
            {
                type = "make_call",
                user_id = "gary"
            };

            // Augment with custom fields
            makeCall.AddFields(new Dictionary<string, object>
            {
                ["foo"] = "bar",
                ["payment_status"] = "$success"
            });

            Assert.Equal("{\"$type\":\"make_call\",\"$user_id\":\"gary\",\"foo\":" +
                              "\"bar\",\"payment_status\":\"$success\"}",
                              makeCall.ToJson());
        }

        




        

        

        

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


        [Fact]
        public void TestWebHookValidation()
        {
            //Please provide the valid secret key in place of 'key'
            String secretKey = "key";
            String requestBody = "{" +
                "\"entity\": {" +
                "\"type\": \"user\"," +
                "\"id\": \"USER123\"" +
                "}," +
                "\"decision\": {" +
                "\"id\": \"block_user_payment_abuse\"" +
                "}," +
                "\"time\": 1461963439151" +
                "}";
            byte[] key = Encoding.ASCII.GetBytes(secretKey);
            HMACSHA1 myhmacsha1 = new HMACSHA1(key);
            byte[] byteArray = Encoding.ASCII.GetBytes(requestBody);
            MemoryStream stream = new MemoryStream(byteArray);
            string signatureCore = myhmacsha1.ComputeHash(stream).Aggregate("", (s, e) => s + String.Format("{0:x2}", e), s => s);
            String signature = "sha1=" + signatureCore;
            WebhookValidator webhook = new WebhookValidator();
            Assert.True(webhook.IsValidWebhook(requestBody, secretKey, signature));

        }

        [Fact]
        public void TestWebHookValidationForInvalidSecretKey()
        {
            //Please provide the secret api key in place of 'key'
            String secretKey = "key";
            String requestBody = "{" +
                "\"entity\": {" +
                "\"type\": \"user\"," +
                "\"id\": \"USER123\"" +
                "}," +
                "\"decision\": {" +
                "\"id\": \"block_user_payment_abuse\"" +
                "}," +
                "\"time\": 1461963439151" +
                "}";

            WebhookValidator webhook = new WebhookValidator();
            Assert.False(webhook.IsValidWebhook(requestBody, secretKey, "InValid Key"));


        }           
    }
}
