using Sift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.PSPMerchantManagementAPI
{
    public class Test
    {
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
    }
}
