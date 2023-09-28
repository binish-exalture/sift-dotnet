using Sift;
using System.Collections.ObjectModel;
using Test.Integration.Net7.Uitlities;
using Xunit;

namespace Test.Integration.Net7.EventsAPI
{
    public class Promotions
    {
        private readonly EnvironmentVariable environmentVariable = new();
        [Fact]
        public void IntegrationTest_AddPromotion()
        {
            var sift = new Client(environmentVariable.ApiKey);
            var addPromotion = new AddPromotion
            {
                user_id = environmentVariable.user_id,
                session_id = environmentVariable.session_id,
                promotions = new ObservableCollection<Promotion>()
                {
                    new Promotion()
                    {
                          promotion_id = environmentVariable.promotion_id,
                          status = "$success",
                          failure_reason = "$already_used",
                          description =   "$5 off your first 5 rides",
                          referrer_user_id = environmentVariable.referrer_user_id,
                          discount = new Discount()
                          {
                                  percentage_off = 0.2,
                                  amount = 5000000,
                                  currency_code = "USD",
                                  minimum_purchase_amount = 50000000
                          },
                          credit_point = new CreditPoint()
                          {
                                  amount = 5000,
                                  credit_point_type = "character xp points"
                          }
                    },
                    new Promotion()
                    {
                        promotion_id = environmentVariable.promotion_id
                    }
                },
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                brand_name = "sift",
                site_country = "US",
                site_domain = "sift.com",
                verification_phone_number = "+123456789012"
            };
            EventRequest eventRequest = new EventRequest()
            {
                Event = addPromotion
            };
            EventResponse res = sift.SendAsync(eventRequest).Result;
            Assert.Equal("OK", res.ErrorMessage);
        }
    }
}