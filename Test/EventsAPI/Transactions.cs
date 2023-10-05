using Sift;
using System.Collections.ObjectModel;
using Xunit;

namespace Test.EventsAPI
{
    public class Transactions
    {
        [Fact]
        public void TestTransactionEvent()
        {
            //Please provide the valid session id in place of 'sessionId'
            var sessionId = "sessionId";
            var transaction = new Transaction
            {
                user_id = "test_dotnet_transaction_event",
                amount = 1000000000000L,
                currency_code = "USD",
                session_id = sessionId,
                transaction_type = "$sale",
                transaction_status = "$failure",
                decline_category = "$invalid"
            };

            // Augment with custom fields
            transaction.AddField("foo", "bar");
            Assert.Equal("{\"$type\":\"$transaction\",\"$user_id\":\"test_dotnet_transaction_event\",\"$session_id\":\"sessionId\"," +
                                 "\"$transaction_type\":\"$sale\",\"$transaction_status\":\"$failure\",\"$amount\":1000000000000,\"$currency_code\":\"USD\"," +
                                 "\"$decline_category\":\"$invalid\",\"foo\":\"bar\"}", transaction.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = transaction
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = transaction,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        [Fact]
        public void TestTransactionEventWithCryptoFields()
        {
            //Please provide the valid session id in place of 'sessionId'
            var sessionId = "sessionId";
            var transaction = new Transaction
            {
                user_id = "test_dotnet_transaction_event",
                amount = 1000000000000L,
                currency_code = "USD",
                session_id = sessionId,
                transaction_type = "$sale",
                transaction_status = "$failure",
                payment_method = new PaymentMethod
                {
                    wallet_address = "ZplYVmchAoywfMvC8jCiKlBLfKSBiFtHU6",
                    wallet_type = "$crypto"
                }
                ,
                digital_orders = new ObservableCollection<DigitalOrder>()
                {
                    new DigitalOrder
                    {
                        digital_asset="BTC",
                        pair="BTC_USD",
                        asset_type="$crypto",
                        order_type="$market",
                        volume="6.0"
                    }
                },
                receiver_wallet_address = "jx17gVqSyo9m4MrhuhuYEUXdCicdof85Bl",
                receiver_external_address = true

            };

            // Augment with custom fields
            transaction.AddField("foo", "bar");
            Assert.Equal("{" +
            "\"$type\":\"$transaction\"," +
            "\"$user_id\":\"test_dotnet_transaction_event\"," +
            "\"$session_id\":\"sessionId\"," +
            "\"$transaction_type\":\"$sale\"," +

            "\"$transaction_status\":\"$failure\"," +
            "\"$amount\":1000000000000," +
            "\"$currency_code\":\"USD\"," +
            "" +
            "\"$payment_method\":{" +
            "\"$wallet_address\":\"ZplYVmchAoywfMvC8jCiKlBLfKSBiFtHU6\"," +
            "\"$wallet_type\":\"$crypto\"" +
            "}," +
            "\"$digital_orders\":[" +
            "{" +
            "\"$digital_asset\":\"BTC\"," +
            "\"$pair\":\"BTC_USD\"," +
            "\"$asset_type\":\"$crypto\"," +
            "\"$order_type\":\"$market\"," +
            "\"$volume\":\"6.0\"" +
            "}" +
            "]," +
            "\"$receiver_wallet_address\":\"jx17gVqSyo9m4MrhuhuYEUXdCicdof85Bl\"," +
            "\"$receiver_external_address\":true," +
            "\"foo\":\"bar\"" +
            "}", transaction.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = transaction
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = transaction,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        [Fact]
        public void TestTransactionEventWithFintechFields()
        {
            //Please provide the valid session id in place of 'sessionId'
            var sessionId = "sessionId";
            var transaction = new Transaction
            {
                user_id = "test_dotnet_transaction_event",
                amount = 1000000000000L,
                currency_code = "USD",
                session_id = sessionId,
                transaction_type = "$sale",
                transaction_status = "$failure",
                decline_category = "$invalid",
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
                sent_address = new Address
                {
                    name = "Bill Jones",
                    phone = "1-415-555-6040",
                    address_1 = "2100 Main Street",
                    address_2 = "Apt 3B",
                    city = "New London",
                    region = "New Hampshire",
                    country = "US",
                    zipcode = "03257"
                },
                received_address = new Address
                {
                    name = "Bill Jones",
                    phone = "1-415-555-6040",
                    address_1 = "2100 Main Street",
                    address_2 = "Apt 3B",
                    city = "New London",
                    region = "New Hampshire",
                    country = "US",
                    zipcode = "03257"
                },
                payment_method = new PaymentMethod
                {
                    payment_type = "$sepa_instant_credit",
                    shortened_iban_first6 = "FR7630",
                    shortened_iban_last4 = "1234",
                    sepa_direct_debit_mandate = true
                },
                status_3ds = "$successful",
                triggered_3ds = "$processor",
                merchant_initiated_transaction = true
            };
            Assert.Equal("{\"$type\":\"$transaction\",\"$user_id\":\"test_dotnet_transaction_event\",\"$session_id\":\"sessionId\"," +
                                 "\"$transaction_type\":\"$sale\",\"$transaction_status\":\"$failure\",\"$amount\":1000000000000,\"$currency_code\":\"USD\"," +
                                 "\"$payment_method\":{\"$payment_type\":\"$sepa_instant_credit\",\"$shortened_iban_first6\":\"FR7630\"," +
                                 "\"$shortened_iban_last4\":\"1234\",\"$sepa_direct_debit_mandate\":true},\"$decline_category\":\"$invalid\"," +
                                 "\"$sent_address\":{\"$name\":\"Bill Jones\",\"$address_1\":\"2100 Main Street\",\"$address_2\":\"Apt 3B\"," +
                                 "\"$city\":\"New London\",\"$region\":\"New Hampshire\",\"$country\":\"US\",\"$zipcode\":\"03257\",\"$phone\":\"1-415-555-6040\"}," +
                                 "\"$received_address\":{\"$name\":\"Bill Jones\",\"$address_1\":\"2100 Main Street\",\"$address_2\":\"Apt 3B\"," +
                                 "\"$city\":\"New London\",\"$region\":\"New Hampshire\",\"$country\":\"US\",\"$zipcode\":\"03257\",\"$phone\":\"1-415-555-6040\"}," +
                                 "\"$status_3ds\":\"$successful\",\"$triggered_3ds\":\"$processor\",\"$merchant_initiated_transaction\":true," +
                                 "\"$merchant_profile\":{\"$merchant_id\":\"123\",\"$merchant_category_code\":\"9876\",\"$merchant_name\":\"ABC Merchant\"," +
                                 "\"$merchant_address\":{\"$name\":\"Bill Jones\",\"$address_1\":\"2100 Main Street\",\"$address_2\":\"Apt 3B\"," +
                                 "\"$city\":\"New London\",\"$region\":\"New Hampshire\",\"$country\":\"US\",\"$zipcode\":\"03257\",\"$phone\":\"1-415-555-6040\"}}}",
                                 transaction.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = transaction
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = transaction,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        [Fact]
        public void TestScorePercentile()
        {
            var sessionId = "sessionId";
            var transaction = new Transaction
            {
                user_id = "vineethk@exalture.com",
                amount = 1000000000000L,
                currency_code = "USD",
                session_id = sessionId,
                transaction_type = "$sale",
                transaction_status = "$failure",
                decline_category = "$invalid"
            };

            EventRequest eventRequest = new EventRequest
            {
                Event = transaction,
                AbuseTypes = { "legacy", "payment_abuse" },
                IncludeScorePercentile = true,
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&fields=SCORE_PERCENTILES&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }
    }
}
