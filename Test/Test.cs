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
        public void TestApplyDecisionRequest()
        {
            var applyDecisionRequest = new ApplyOrderDecisionRequest
            {
                AccountId = "123",
                UserId = "gary",
                OrderId = "1",
                DecisionId = "abc",
                Source = "AUTOMATED_RULE"
            };

            applyDecisionRequest.ApiKey = "key";

            Assert.Equal("https://api.sift.com/v3/accounts/123/users/gary/orders/1/decisions",
                         applyDecisionRequest.Request.RequestUri!.ToString());

            Assert.Equal(Convert.ToBase64String(Encoding.Default.GetBytes("key")),
                         applyDecisionRequest.Request.Headers.Authorization!.Parameter);

        }        

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

        [Fact]
        public void TestGetMerchantsRequest()
        {
            //Please provide the valid account id in place of dummy number;
            var accountId = "12345678";
            //Please provide the valid api key in place of 'key'
            var apiKey = "key";
            var getMerchantRequest = new GetMerchantsRequest
            {
                AccountId = accountId
            };
            getMerchantRequest.ApiKey = apiKey;

            Assert.Equal("https://api.sift.com/v3/accounts/" + accountId + "/psp_management/merchants",
                         getMerchantRequest.Request.RequestUri!.ToString());

        }

        [Fact]
        public void TestCreateMerchantRequest()
        {
            //Please provide the valid account id in place of dummy number;
            var accountId = "12345678";
            //Please provide the valid api key in place of 'key'
            var apiKey = "key";
            var createMerchantRequest = new CreateMerchantRequest
            {
                AccountId = accountId,
                ApiKey = apiKey,
                Id = "test-vineeth-5",
                Name = "Wonderful Payments Inc",
                Description = "Wonderful Payments payment provider",
                Address = new MerchantAddress
                {
                    Name = "Alany",
                    Address1 = "Big Payment blvd, 22",
                    Address2 = "apt, 8",
                    City = "New Orleans",
                    Country = "US",
                    Phone = "0394888320",
                    Region = "NA",
                    ZipCode = "76830"

                },
                Category = "1002",
                ServiceLevel = "Platinum",
                Status = "active",
                RiskProfile = new MerchantRiskProfile
                {
                    Level = "low",
                    Score = 10
                }
            };

            createMerchantRequest.ApiKey = apiKey;

            Assert.Equal(Convert.ToBase64String(Encoding.Default.GetBytes(apiKey)),
                createMerchantRequest.Request.Headers.Authorization!.Parameter);


            Assert.Equal("https://api.sift.com/v3/accounts/" + accountId + "/psp_management/merchants",
                         createMerchantRequest.Request.RequestUri!.ToString());
        }

        [Fact]
        public void TestUpdateMerchantRequest()
        {
            //Please provide the valid account id in place of dummy number;
            var accountId = "12345678";
            //Please provide the valid api key in place of 'key'
            var apiKey = "key";
            var updateMerchantRequest = new UpdateMerchantRequest
            {
                AccountId = accountId,
                MerchantId = "test2",
                ApiKey = apiKey,
                Id = "test-vineeth-5",
                Name = "Wonderful Payments Inc",
                Description = "Wonderful Payments payment provider",
                Address = new MerchantAddress
                {
                    Name = "Alany",
                    Address1 = "Big Payment blvd, 22",
                    Address2 = "apt, 8",
                    City = "New Orleans",
                    Country = "US",
                    Phone = "0394888320",
                    Region = "NA",
                    ZipCode = "76830"

                },
                Category = "1002",
                ServiceLevel = "Platinum",
                Status = "active",
                RiskProfile = new MerchantRiskProfile
                {
                    Level = "low",
                    Score = 10
                }
            };
            updateMerchantRequest.ApiKey = apiKey;

            Assert.Equal(Convert.ToBase64String(Encoding.Default.GetBytes(apiKey)),
                updateMerchantRequest.Request.Headers.Authorization!.Parameter);

            Assert.Equal("https://api.sift.com/v3/accounts/" + accountId + "/psp_management/merchants/test2",
                         updateMerchantRequest.Request.RequestUri!.ToString());


            Assert.Equal("{\"id\":\"test-vineeth-5\"," +
                "\"name\":\"Wonderful Payments Inc\"," +
                "\"description\":\"Wonderful Payments payment provider\"," +
                "\"address\":{\"name\":\"Alany\"," +
                    "\"address_1\":\"Big Payment blvd, 22\"," +
                    "\"address_2\":\"apt, 8\"," +
                    "\"city\":\"New Orleans\"," +
                    "\"region\":\"NA\"," +
                    "\"country\":\"US\"," +
                    "\"zipcode\":\"76830\"," +
                    "\"phone\":\"0394888320\"}," +
                "\"category\":\"1002\"," +
                "\"service_level\":\"Platinum\"," +
                "\"status\":\"active\"," +
                "\"risk_profile\":{\"level\":\"low\",\"score\":10}}",
                               Newtonsoft.Json.JsonConvert.SerializeObject(updateMerchantRequest));

        }

        [Fact]
        public void TestGetMerchantDetailsRequest()
        {
            //Please provide the valid account id in place of dummy number;
            var accountId = "12345678";
            //Please provide the valid api key in place of 'key'
            var apiKey = "key";
            var getMerchantDetailRequest = new GetMerchantDetailsRequest
            {
                AccountId = accountId,
                MerchantId = "test-merchat-id",
            };
            getMerchantDetailRequest.ApiKey = apiKey;

            Assert.Equal(Convert.ToBase64String(Encoding.Default.GetBytes(apiKey)),
                getMerchantDetailRequest.Request.Headers.Authorization!.Parameter);

            Assert.Equal("https://api.sift.com/v3/accounts/" + accountId + "/psp_management/merchants/test-merchat-id",
             getMerchantDetailRequest.Request.RequestUri!.ToString());
        }

        

        

        

        

        

        

        

        

        

        

        


        

        

        

        

        

        

        


        [Fact]
        public void TestCreateContentCommentEvent()
        {
            var createContent = new CreateContent
            {
                user_id = "fyw3989sjpqr71",
                content_id = "comment-23412",
                session_id = "a234ksjfgn435sfg",
                status = "$active",
                ip = "255.255.255.0",
                comment = new Comment()
                {
                    body = "Congrats on the new role!",
                    contact_email = "alex_301@domain.com",
                    parent_comment_id = "comment-23407",
                    root_content_id = "listing-12923213",
                    images = new ObservableCollection<Image>()
                    {
                        new Image()
                        {
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661",
                            link = "https://www.domain.com/file.png",
                            description =   "An old picture"
                        },
                        new Image()
                        {
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661"
                        }
                    }
                },
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
            };

            string createcontentbody = "{\"$type\":\"$create_content\",\"$user_id\":\"fyw3989sjpqr71\",\"$content_id\":\"comment-23412\",\"$session_id\":\"a234ksjfgn435sfg\",\"$status\":\"$active\",\"$ip\":\"255.255.255.0\",\"$comment\":{\"$body\":\"Congrats on the new role!\",\"$contact_email\":\"alex_301@domain.com\",\"$parent_comment_id\":\"comment-23407\",\"$root_content_id\":\"listing-12923213\",\"$images\":[{\"$md5_hash\":\"0cc175b9c0f1b6a831c399e269772661\",\"$link\":\"https://www.domain.com/file.png\",\"$description\":\"An old picture\"},{\"$md5_hash\":\"0cc175b9c0f1b6a831c399e269772661\"}]},\"$browser\":{\"$user_agent\":\"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36\",\"$accept_language\":\"en-US\",\"$content_language\":\"en-GB\"}}";

            Assert.Equal(createcontentbody, createContent.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = createContent
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = createContent,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

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

        [Fact]
        public void TestUpdatePasswordEvent()
        {
            var updatePassword = new UpdatePassword
            {
                user_id = "billy_jones_301",
                reason = "$forced_reset",
                status = "$success",
                session_id = "gigtleqddo84l8cm15qe4il",
                ip = "128.148.1.135",
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

            string updatePasswordBody = "{\"$type\":\"$update_password\",\"$user_id\":\"billy_jones_301\",\"$session_id\":\"gigtleqddo84l8cm15qe4il\",\"$reason\":\"$forced_reset\",\"$status\":\"$success\",\"$ip\":\"128.148.1.135\",\"$browser\":{\"$user_agent\":\"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36\",\"$accept_language\":\"en-US\",\"$content_language\":\"en-GB\"},\"$brand_name\":\"sift\",\"$site_country\":\"US\",\"$site_domain\":\"sift.com\",\"$user_email\":\"billjones1@example.com\",\"$verification_phone_number\":\"+123456789012\"}";

            Assert.Equal(updatePasswordBody, updatePassword.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = updatePassword
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = updatePassword,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        [Fact]
        public void TestGetScoreRequest()
        {
            ScoreRequest scoreRequest = new ScoreRequest
            {
                UserId = "123",
                ApiKey = "345",
                AbuseTypes = new List<string>() { "payment_abuse", "promotion_abuse" }
            };

            var url = scoreRequest.Request.RequestUri!.ToString();

            Assert.Equal("https://api.sift.com/v205/users/123/score?api_key=345&abuse_types=payment_abuse,promotion_abuse",
                        Uri.UnescapeDataString(scoreRequest.Request.RequestUri!.ToString()));
        }
    }

}
