using Sift;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.EventsAPI
{
    public class Test_Accounts
    {
        [Fact]
        public void TestCreateAccountEvent()
        {
            //Please provide the valid session id in place of 'sessionId'
            var sessionId = "sessionId";
            var createAccount = new CreateAccount
            {
                user_id = "test_dotnet_create_account_event",
                session_id = sessionId,
                user_email = "bill@gmail.com",
                name = "Bill Jones",
                referrer_user_id = "janejane101",
                social_sign_on_type = "$twitter",
                merchant_profile = new MerchantProfile
                {
                    merchant_id = "123",
                    merchant_category_code = "9876",
                    merchant_name = "ABC Merchant",
                    merchant_address = new Address
                    {
                        name = "Bill Jones",
                        phone = "1-415-555-6040",
                        address_1 = "2100 Main Street",
                        address_2 = "Apt 3B",
                        city = "New London",
                        region = "New Hampshire",
                        country = "US",
                        zipcode = "03257"
                    }
                },
                account_types = new ObservableCollection<string>() { "merchant", "premium" }
            };

            // Augment with custom fields
            createAccount.AddField("foo", "bar");

            Assert.Equal("{\"$type\":\"$create_account\",\"$user_id\":\"test_dotnet_create_account_event\",\"$session_id\":\"sessionId\"," +
                                 "\"$user_email\":\"bill@gmail.com\",\"$name\":\"Bill Jones\",\"$referrer_user_id\":\"janejane101\",\"$social_sign_on_type\":" +
                                 "\"$twitter\",\"$merchant_profile\":{\"$merchant_id\":\"123\",\"$merchant_category_code\":\"9876\",\"$merchant_name\":\"ABC Merchant\"," +
                                 "\"$merchant_address\":{\"$name\":\"Bill Jones\",\"$address_1\":\"2100 Main Street\",\"$address_2\":\"Apt 3B\",\"$city\":\"New London\"," +
                                 "\"$region\":\"New Hampshire\",\"$country\":\"US\",\"$zipcode\":\"03257\",\"$phone\":\"1-415-555-6040\"}},\"$account_types\":" +
                                 "[\"merchant\",\"premium\"],\"foo\":\"bar\"}",
                                 createAccount.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = createAccount
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = createAccount,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }
    }
}
