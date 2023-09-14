using Sift;
using System;
using Xunit;

namespace Test.Integration.Net7.CustomEvents
{
    public class MerchantRequests
    {
        [Fact]
        public void IntegrationTest_GetMerchantRequest()
        {
            var sift = new Client("ccd68efbe25809bc:");
            GetMerchantsRequest getMerchantRequest = new GetMerchantsRequest
            {
                AccountId = "cf51f0ec-6078-46e9-a796-700af25e668c",
                ApiKey = "ccd68efbe25809bc",
                BatchSize = 10,
                BatchToken = null                               
            };
            GetMerchantsResponse getMerchantResponse = sift.SendAsync(getMerchantRequest).Result;
            Assert.Equal("OK", getMerchantResponse.ErrorMessage);
        }

        [Fact]
        public void IntegrationTest_UpdateMerchantRequest()
        {
            var sift = new Client("ccd68efbe25809bc:");
            UpdateMerchantRequest updateMerchantRequest = new UpdateMerchantRequest
            {
                AccountId = "cf51f0ec-6078-46e9-a796-700af25e668c",
                MerchantId = "cf51f0ec-6078-46e9-a796-700af25e668c",
                Name = "Watson and Holmes",
                ApiKey = "ccd68efbe25809bc",
                Description = "An example of a PSP Merchant. Illustrative.",
                Address = new MerchantAddress()
                {
                    Name = "Dr Watson",
                    Address1 = "221B, Baker street",
                    Address2 = "apt., 1",
                    City = "London",
                    Region = "London",
                    Country = "GB",
                    ZipCode = "000001",
                    Phone = "0122334455"
                },
                Category = "1002",
                ServiceLevel = "Platinum",
                Status = "active",
                RiskProfile = new MerchantRiskProfile()
                {
                    Level = "low",
                    Score = 10
                }
            };
            UpdateMerchantResponse updateMerchantResponse = sift.SendAsync(updateMerchantRequest).Result;
            Assert.Equal("OK", updateMerchantResponse.ErrorMessage);
        }

        [Fact]
        public void IntegrationTest_CreateMerchantRequest()
        {
            var sift = new Client("ccd68efbe25809bc:");
            CreateMerchantRequest createMerchantRequest = new CreateMerchantRequest
            {
                AccountId = "cf51f0ec-6078-46e9-a796-700af25e668c",
                Name = "Watson and Holmes",
                ApiKey = "ccd68efbe25809bc",
                Description = "An example of a PSP Merchant. Illustrative.",
                Address = new MerchantAddress()
                {
                    Name = "Dr Watson",
                    Address1 = "221B, Baker street",
                    Address2 = "apt., 1",
                    City = "London",
                    Region = "London",
                    Country = "GB",
                    ZipCode = "000001",
                    Phone = "0122334455"
                },
                Category = "1002",
                ServiceLevel = "Platinum",
                Status = "active",
                RiskProfile = new MerchantRiskProfile()
                {
                    Level = "low",
                    Score = 10
                }
            };
            CreateMerchantResponse createMerchantResponse = sift.SendAsync(createMerchantRequest).Result;
            Assert.Equal("OK", createMerchantResponse.ErrorMessage);
        }

    }
}