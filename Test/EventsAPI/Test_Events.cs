using Sift;
using System.Collections.ObjectModel;
using Xunit;

namespace Test.EventsAPI
{
    public class Test
    {
        [Fact]
        public void TestEventRequest()
        {
            //Please provide the valid session id in place of 'sessionId'
            var sessionId = "sessionId";
            var createOrder = new CreateOrder
            {
                user_id = "test_dotnet_booking_with_all_fields",
                order_id = "oid",
                amount = 1000000000000L,
                currency_code = "USD",
                session_id = sessionId,
                user_email = "bill@gmail.com",
                bookings = new ObservableCollection<Booking>()
                {
                    new Booking()
                    {
                        booking_type = "$flight",
                        title = "SFO - LAS, 2 Adults",
                        start_time= 2038412903,
                        end_time= 2038412903,
                        price = 49900000,
                        currency_code = "USD",
                        quantity = 1,
                        venue_id = "venue-123",
                        event_id = "event-123",
                        room_type = "deluxe",
                        category = "pop",
                        guests = new ObservableCollection<Guest>()
                        {
                            new Guest()
                            {
                                name = "John Doe",
                                birth_date = "1985-01-19",
                                loyalty_program = "skymiles",
                                loyalty_program_id = "PSOV34DF",
                                phone = "1-415-555-6040",
                                email = "jdoe@domain.com"
                            },
                            new Guest()
                            {
                                name = "John Doe"
                            }
                        },
                        segments = new ObservableCollection<Segment>()
                        {
                            new Segment()
                            {
                                departure_address = new Address
                                {
                                    name = "Bill Jones",
                                    phone =  "1-415-555-6040",
                                    address_1 = "2100 Main Street",
                                    address_2 = "Apt 3B",
                                    city = "New London",
                                    region = "New Hampshire",
                                    country = "US",
                                    zipcode = "03257"
                                },
                                arrival_address = new Address
                                {
                                    name = "Bill Jones",
                                    phone =  "1-415-555-6040",
                                    address_1 = "2100 Main Street",
                                    address_2 = "Apt 3B",
                                    city = "New London",
                                    region = "New Hampshire",
                                    country = "US",
                                    zipcode = "03257"
                                },
                                start_time = 203841290300L,
                                end_time = 2038412903,
                                vessel_number = "LH454",
                                fare_class = "Premium Economy",
                                departure_airport_code = "SFO",
                                arrival_airport_code = "LAS"
                            }
                        },
                        location = new Address
                        {
                            name = "Bill Jones",
                            phone =  "1-415-555-6040",
                            address_1 = "2100 Main Street",
                            address_2 = "Apt 3B",
                            city = "New London",
                            region = "New Hampshire",
                            country = "US",
                            zipcode = "03257"
                        },
                        tags = new ObservableCollection<string>() { "tag-123", "tag-321"}
                    }
                },
                billing_address = new Address
                {
                    name = "gary",
                    city = "san francisco"
                },
                app = new App
                {
                    app_name = "my app",
                    app_version = "1.0",
                    client_language = "en-US"
                },
                ordered_from = new OrderedFrom
                {
                    store_id = "123",
                    store_address = new Address
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
                site_country = "US",
                site_domain = "sift.com",
                brand_name = "sift"
            };

            // Augment with custom fields
            createOrder.AddField("foo", "bar");
            Assert.Equal("{\"$type\":\"$create_order\",\"$user_id\":\"test_dotnet_booking_with_all_fields\"," +
                         "\"$session_id\":\"sessionId\",\"$order_id\":\"oid\",\"$user_email\":\"bill@gmail.com\"," +
                         "\"$amount\":1000000000000,\"$currency_code\":\"USD\",\"$billing_address\":{\"$name\":\"gary\",\"$city\":\"san francisco\"}," +
                         "\"$bookings\":[{\"$booking_type\":\"$flight\",\"$title\":\"SFO - LAS, 2 Adults\",\"$start_time\":2038412903," +
                         "\"$end_time\":2038412903,\"$price\":49900000,\"$currency_code\":\"USD\",\"$quantity\":1,\"$guests\":[{\"$name\":\"John Doe\"," +
                         "\"$email\":\"jdoe@domain.com\",\"$phone\":\"1-415-555-6040\",\"$loyalty_program\":\"skymiles\",\"$loyalty_program_id\":\"PSOV34DF\"," +
                         "\"$birth_date\":\"1985-01-19\"},{\"$name\":\"John Doe\"}],\"$segments\":[{\"$start_time\":203841290300,\"$end_time\":2038412903," +
                         "\"$vessel_number\":\"LH454\",\"$departure_airport_code\":\"SFO\",\"$arrival_airport_code\":\"LAS\",\"$fare_class\":\"Premium Economy\"," +
                         "\"$departure_address\":{\"$name\":\"Bill Jones\",\"$address_1\":\"2100 Main Street\",\"$address_2\":\"Apt 3B\",\"$city\":\"New London\"," +
                         "\"$region\":\"New Hampshire\",\"$country\":\"US\",\"$zipcode\":\"03257\",\"$phone\":\"1-415-555-6040\"}," +
                         "\"$arrival_address\":{\"$name\":\"Bill Jones\",\"$address_1\":\"2100 Main Street\",\"$address_2\":\"Apt 3B\",\"$city\":\"New London\"," +
                         "\"$region\":\"New Hampshire\",\"$country\":\"US\",\"$zipcode\":\"03257\",\"$phone\":\"1-415-555-6040\"}}],\"$room_type\":\"deluxe\"," +
                         "\"$event_id\":\"event-123\",\"$venue_id\":\"venue-123\",\"$location\":{\"$name\":\"Bill Jones\",\"$address_1\":\"2100 Main Street\"," +
                         "\"$address_2\":\"Apt 3B\",\"$city\":\"New London\",\"$region\":\"New Hampshire\",\"$country\":\"US\",\"$zipcode\":\"03257\"," +
                         "\"$phone\":\"1-415-555-6040\"},\"$category\":\"pop\",\"$tags\":[\"tag-123\",\"tag-321\"]}],\"$app\":{\"$app_name\":\"my app\"," +
                         "\"$app_version\":\"1.0\",\"$client_language\":\"en-US\"},\"$brand_name\":\"sift\",\"$site_country\":\"US\",\"$site_domain\":\"sift.com\"," +
                         "\"$ordered_from\":{\"$store_id\":\"123\",\"$store_address\":{\"$name\":\"Bill Jones\",\"$address_1\":\"2100 Main Street\"," +
                         "\"$address_2\":\"Apt 3B\",\"$city\":\"New London\",\"$region\":\"New Hampshire\",\"$country\":\"US\",\"$zipcode\":\"03257\"," +
                         "\"$phone\":\"1-415-555-6040\"}},\"foo\":\"bar\"}",
                         createOrder.ToJson());


            EventRequest eventRequest = new EventRequest
            {
                Event = createOrder
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = createOrder,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true,
                ReturnRouteInfo = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true&return_route_info=true",
                         Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        [Fact]
        public void TestEventWithBrowser()
        {
            //Please provide the valid session id in place of 'sessionId'
            var sessionId = "sessionId";
            var createOrder = new CreateOrder
            {
                user_id = "test_dotnet_browser_field",
                order_id = "oid",
                amount = 1000000000000L,
                currency_code = "USD",
                session_id = sessionId,
                user_email = "bill@gmail.com",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                }
            };

            // Augment with custom fields
            createOrder.AddField("foo", "bar");
            Assert.Equal("{\"$type\":\"$create_order\",\"$user_id\":\"test_dotnet_browser_field\",\"$session_id\":\"sessionId\"," +
                         "\"$order_id\":\"oid\",\"$user_email\":\"bill@gmail.com\",\"$amount\":1000000000000,\"$currency_code\":\"USD\"," +
                         "\"$browser\":{\"$user_agent\":\"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36\"," +
                         "\"$accept_language\":\"en-US\",\"$content_language\":\"en-GB\"},\"foo\":\"bar\"}",
                         createOrder.ToJson());


            EventRequest eventRequest = new EventRequest
            {
                Event = createOrder
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = createOrder,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                         Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

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
        public void TestCreateOrderEventWithSepaPaymentMethodFields()
        {
            //Please provide the valid session id in place of 'sessionId'
            var sessionId = "sessionId";
            var createOrder = new CreateOrder
            {
                user_id = "test_dotnet_sepa_payment_method_fields",
                session_id = sessionId,
                order_id = "12345",
                payment_methods = new ObservableCollection<PaymentMethod>()
                {
                    new PaymentMethod
                    {
                        payment_type = "$sepa_instant_credit",
                        shortened_iban_first6 = "FR7630",
                        shortened_iban_last4 = "1234",
                        sepa_direct_debit_mandate = true
                    }
                }
            };

            // Augment with custom fields
            createOrder.AddField("foo", "bar");
            Assert.Equal("{\"$type\":\"$create_order\",\"$user_id\":\"test_dotnet_sepa_payment_method_fields\",\"$session_id\":\"sessionId\"," +
                                 "\"$order_id\":\"12345\",\"$payment_methods\":[{\"$payment_type\":\"$sepa_instant_credit\",\"$shortened_iban_first6\":\"FR7630\"," +
                                 "\"$shortened_iban_last4\":\"1234\",\"$sepa_direct_debit_mandate\":true}],\"foo\":\"bar\"}",
                                 createOrder.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = createOrder
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = createOrder,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        [Fact]
        public void TestCreateOrderEventWithMerchantProfileField()
        {
            //Please provide the valid session id in place of 'sessionId'
            var sessionId = "sessionId";
            var createOrder = new CreateOrder
            {
                user_id = "test_dotnet_merchant_profile_field",
                session_id = sessionId,
                order_id = "12345",
                payment_methods = new ObservableCollection<PaymentMethod>()
                {
                    new PaymentMethod
                    {
                        payment_type = "$sepa_instant_credit",
                        shortened_iban_first6 = "FR7630",
                        shortened_iban_last4 = "1234",
                        sepa_direct_debit_mandate = true
                    }
                },
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
                }
            };

            // Augment with custom fields
            createOrder.AddField("foo", "bar");
            Assert.Equal("{\"$type\":\"$create_order\",\"$user_id\":\"test_dotnet_merchant_profile_field\",\"$session_id\":\"sessionId\"," +
                                 "\"$order_id\":\"12345\",\"$payment_methods\":[{\"$payment_type\":\"$sepa_instant_credit\",\"$shortened_iban_first6\":\"FR7630\"," +
                                 "\"$shortened_iban_last4\":\"1234\",\"$sepa_direct_debit_mandate\":true}],\"$merchant_profile\":{\"$merchant_id\":\"123\"," +
                                 "\"$merchant_category_code\":\"9876\",\"$merchant_name\":\"ABC Merchant\",\"$merchant_address\":{\"$name\":\"Bill Jones\"," +
                                 "\"$address_1\":\"2100 Main Street\",\"$address_2\":\"Apt 3B\",\"$city\":\"New London\",\"$region\":\"New Hampshire\"," +
                                 "\"$country\":\"US\",\"$zipcode\":\"03257\",\"$phone\":\"1-415-555-6040\"}},\"foo\":\"bar\"}",
                                 createOrder.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = createOrder
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = createOrder,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        [Fact]
        public void TestCreateOrderEventWithCryptoFields()
        {
            //Please provide the valid session id in place of 'sessionId'
            var sessionId = "sessionId";
            var createOrder = new CreateOrder
            {
                user_id = "test_dotnet_merchant_profile_field",
                session_id = sessionId,
                order_id = "12345",
                payment_methods = new ObservableCollection<PaymentMethod>()
                {
                    new PaymentMethod
                    {
                        wallet_address = "ZplYVmchAoywfMvC8jCiKlBLfKSBiFtHU6",
                        wallet_type = "$crypto"
                    }
                },
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

            };

            // Augment with custom fields
            createOrder.AddField("foo", "bar");
            Assert.Equal("{\"$type\":\"$create_order\",\"$user_id\":\"test_dotnet_merchant_profile_field\",\"$session_id\":\"sessionId\"," +
            "\"$order_id\":\"12345\"," +
            "\"$payment_methods\":[" +
            "{" +
            "\"$wallet_address\":\"ZplYVmchAoywfMvC8jCiKlBLfKSBiFtHU6\"," +
            "\"$wallet_type\":\"$crypto\"" +
            "}" +
            "]," +
            "\"$digital_orders\":[" +
            "{" +
            "\"$digital_asset\":\"BTC\"," +
            "\"$pair\":\"BTC_USD\"," +
            "\"$asset_type\":\"$crypto\"," +
            "\"$order_type\":\"$market\"," +
            "\"$volume\":\"6.0\"" +
            "}" +
            "]," +
            "\"foo\":\"bar\"}",
            createOrder.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = createOrder
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = createOrder,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        [Fact]
        public void TestUpdateOrderEventWithCryptoFields()
        {
            //Please provide the valid session id in place of 'sessionId'
            var sessionId = "sessionId";
            var updateOrder = new UpdateOrder
            {
                user_id = "test_dotnet_merchant_profile_field",
                session_id = sessionId,
                order_id = "12345",
                payment_methods = new ObservableCollection<PaymentMethod>()
                {
                    new PaymentMethod
                    {
                        wallet_address = "ZplYVmchAoywfMvC8jCiKlBLfKSBiFtHU6",
                        wallet_type = "$crypto"
                    }
                },
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

            };

            // Augment with custom fields
            updateOrder.AddField("foo", "bar");
            Assert.Equal("{\"$type\":\"$update_order\",\"$user_id\":\"test_dotnet_merchant_profile_field\",\"$session_id\":\"sessionId\"," +
            "\"$order_id\":\"12345\"," +
            "\"$payment_methods\":[" +
            "{" +
            "\"$wallet_address\":\"ZplYVmchAoywfMvC8jCiKlBLfKSBiFtHU6\"," +
            "\"$wallet_type\":\"$crypto\"" +
            "}" +
            "]," +
            "\"$digital_orders\":[" +
            "{" +
            "\"$digital_asset\":\"BTC\"," +
            "\"$pair\":\"BTC_USD\"," +
            "\"$asset_type\":\"$crypto\"," +
            "\"$order_type\":\"$market\"," +
            "\"$volume\":\"6.0\"" +
            "}" +
            "]," +
            "\"foo\":\"bar\"}",
            updateOrder.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = updateOrder
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = updateOrder,
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
        public void TestCreateOrderEventWithWirePaymentMethod()
        {
            //Please provide the valid session id in place of 'sessionId'
            var sessionId = "sessionId";
            var createOrder = new CreateOrder
            {
                user_id = "test_dotnet_wire_payment_methods",
                session_id = sessionId,
                order_id = "12345",
                payment_methods = new ObservableCollection<PaymentMethod>()
            {
                new PaymentMethod
                {
                    payment_type = "$wire_credit",
                    routing_number = "CHASUS33XX",
                    account_number_last5 = "12345",
                    account_holder_name = "John Doe",
                    bank_name = "Chase",
                    bank_country = "US"
                }
            }
            };

            // Augment with custom fields
            createOrder.AddField("foo", "bar");
            Assert.Equal("{\"$type\":\"$create_order\",\"$user_id\":\"test_dotnet_wire_payment_methods\",\"$session_id\":\"sessionId\"," +
                                 "\"$order_id\":\"12345\",\"$payment_methods\":[{\"$payment_type\":\"$wire_credit\",\"$routing_number\":\"CHASUS33XX\"," +
                                 "\"$account_number_last5\":\"12345\",\"$account_holder_name\":\"John Doe\",\"$bank_name\":\"Chase\",\"$bank_country\":\"US\"}],\"foo\":\"bar\"}",
                                 createOrder.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = createOrder
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = createOrder,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        [Fact]
        public void TestChargebackEvent()
        {
            //Please provide the valid session id in place of 'sessionId'
            var sessionId = "sessionId";
            var chargeback = new Chargeback
            {
                user_id = "test_dotnet_chargeback_event",
                session_id = sessionId,
                transaction_id = "719637215",
                order_id = "ORDER-123124124",
                chargeback_state = "$lost",
                chargeback_reason = "$duplicate",

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
                ach_return_code = "B02"
            };

            // Augment with custom fields
            chargeback.AddField("foo", "bar");
            Assert.Equal("{\"$type\":\"$chargeback\",\"$user_id\":\"test_dotnet_chargeback_event\",\"$session_id\":\"sessionId\"," +
                                 "\"$order_id\":\"ORDER-123124124\",\"$transaction_id\":\"719637215\",\"$chargeback_state\":\"$lost\",\"$chargeback_reason\":\"$duplicate\"," +
                                 "\"$merchant_profile\":{\"$merchant_id\":\"123\",\"$merchant_category_code\":\"9876\",\"$merchant_name\":\"ABC Merchant\",\"$merchant_address\":" +
                                 "{\"$name\":\"Bill Jones\",\"$address_1\":\"2100 Main Street\",\"$address_2\":\"Apt 3B\",\"$city\":\"New London\",\"$region\":\"New Hampshire\"," +
                                 "\"$country\":\"US\",\"$zipcode\":\"03257\",\"$phone\":\"1-415-555-6040\"}}," +
                                 "\"$ach_return_code\":\"B02\",\"foo\":\"bar\"}",
                                 chargeback.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = chargeback
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = chargeback,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

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

        [Fact]
        public void TestUpdateAccountEvent()
        {
            //Please provide the valid session id in place of 'sessionId'
            var sessionId = "sessionId";
            var updateAccount = new UpdateAccount
            {
                user_id = "test_dotnet_update_account_event",
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
            updateAccount.AddField("foo", "bar");

            Assert.Equal("{\"$type\":\"$update_account\",\"$user_id\":\"test_dotnet_update_account_event\",\"$session_id\":\"sessionId\"," +
                                 "\"$user_email\":\"bill@gmail.com\",\"$name\":\"Bill Jones\",\"$referrer_user_id\":\"janejane101\",\"$social_sign_on_type\":" +
                                 "\"$twitter\",\"$merchant_profile\":{\"$merchant_id\":\"123\",\"$merchant_category_code\":\"9876\",\"$merchant_name\":\"ABC Merchant\"," +
                                 "\"$merchant_address\":{\"$name\":\"Bill Jones\",\"$address_1\":\"2100 Main Street\",\"$address_2\":\"Apt 3B\",\"$city\":" +
                                 "\"New London\",\"$region\":\"New Hampshire\",\"$country\":\"US\",\"$zipcode\":\"03257\",\"$phone\":\"1-415-555-6040\"}}," +
                                 "\"$account_types\":[\"merchant\",\"premium\"],\"foo\":\"bar\"}",
                                 updateAccount.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = updateAccount
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = updateAccount,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        [Fact]
        public void TestLoginEvent()
        {
            //Please provide the valid session id in place of 'sessionId'
            var sessionId = "sessionId";
            var login = new Login
            {
                user_id = "test_dotnet_login_event",
                session_id = sessionId,
                user_email = "bill@gmail.com",
                login_status = "$success",
                ip = "128.148.1.135",
                failure_reason = "$account_unknown",
                social_sign_on_type = "$facebook",
                username = "test_user_name",
                site_country = "US",
                site_domain = "sift.com",
                brand_name = "sift",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                account_types = new ObservableCollection<string>() { "merchant", "premium" }
            };

            Assert.Equal("{\"$type\":\"$login\",\"$user_id\":\"test_dotnet_login_event\",\"$session_id\":\"sessionId\"," +
                                 "\"$user_email\":\"bill@gmail.com\",\"$login_status\":\"$success\",\"$failure_reason\":\"$account_unknown\"," +
                                 "\"$social_sign_on_type\":\"$facebook\",\"$username\":\"test_user_name\",\"$ip\":\"128.148.1.135\",\"$browser\":" +
                                 "{\"$user_agent\":\"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) " +
                                 "Chrome/56.0.2924.87 Safari/537.36\",\"$accept_language\":\"en-US\",\"$content_language\":\"en-GB\"},\"$brand_name\":" +
                                 "\"sift\",\"$site_country\":\"US\",\"$site_domain\":\"sift.com\",\"$account_types\":[\"merchant\",\"premium\"]}",
                                 login.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = login
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = login,
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

        //UpdateContentComment
        [Fact]
        public void TestUpdateContentComment()
        {
            var updateContent = new UpdateContent
            {
                user_id = "fyw3989sjpqr71",
                content_id = "comment-23412",
                session_id = "a234ksjfgn435sfg",
                status = "$active",
                ip = "255.255.255.0",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
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
                brand_name = "sift",
                site_country = "US",
                site_domain = "sift.com",
            };

            string updateCommentBody = "{\"$type\":\"$update_content\",\"$user_id\":\"fyw3989sjpqr71\",\"$content_id\":\"comment-23412\",\"$session_id\":\"a234ksjfgn435sfg\",\"$status\":\"$active\",\"$ip\":\"255.255.255.0\",\"$comment\":{\"$body\":\"Congrats on the new role!\",\"$contact_email\":\"alex_301@domain.com\",\"$parent_comment_id\":\"comment-23407\",\"$root_content_id\":\"listing-12923213\",\"$images\":[{\"$md5_hash\":\"0cc175b9c0f1b6a831c399e269772661\",\"$link\":\"https://www.domain.com/file.png\",\"$description\":\"An old picture\"},{\"$md5_hash\":\"0cc175b9c0f1b6a831c399e269772661\"}]},\"$browser\":{\"$user_agent\":\"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36\",\"$accept_language\":\"en-US\",\"$content_language\":\"en-GB\"},\"$brand_name\":\"sift\",\"$site_country\":\"US\",\"$site_domain\":\"sift.com\"}";

            Assert.Equal(updateCommentBody, updateContent.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = updateContent
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = updateContent,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        //UpdateContentListing
        [Fact]
        public void TestUpdateContentListing()
        {
            var updateContent = new UpdateContent
            {
                user_id = "fyw3989sjpqr71",
                content_id = "listing-23412",
                session_id = "a234ksjfgn435sfg",
                status = "$active",
                ip = "255.255.255.0",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                listing = new Listing()
                {
                    subject = "2 Bedroom Apartment for Rent",
                    body = "Capitol Hill Seattle brand new condo. 2 bedrooms and 1 full bath.",
                    contact_email = "alex_301@domain.com",
                    contact_address = new Address()
                    {
                        name = "Bill Jones",
                        address_1 = "abc",
                        address_2 = "xyz",
                        city = "New London",
                        region = "New Hampshire",
                        country = "US",
                        zipcode = "03257",
                        phone = "1-415-555-6041"


                    },
                    locations = new ObservableCollection<Address>()
                    {
                        new Address()
                        {
                            name = "Bill Jones",
                            address_1 = "abc",
                            address_2 = "xyz",
                            city = "Seattle",
                            region = "Washington",
                            country = "US",
                            zipcode = "98112",
                            phone = "1-415-555-6041"
                        },
                        new Address()
                        {
                            name = "Bill Jones"
                        }

                    },
                    listed_items = new ObservableCollection<Item>()
                    {
                        new Item()
                        {
                            item_id = "0cc175b9c0f1b6a831c399e269772661",
                            product_title = "https://www.domain.com/file.png",
                            price = 2950000000,
                            currency_code = "USD",
                            quantity = 1,
                            upc = "6786211451001",
                            sku = "abc",
                            isbn = "0446576220",
                            brand = "abc",
                            manufacturer = "abc",
                            category = "abc",
                            tags = new ObservableCollection<string>() { "heat","washer/dryer" },
                            color = "ab",
                            size = "ab"
                        }
                    },
                    images = new ObservableCollection<Image>()
                    {
                        new Image()
                        {
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661",
                            link = "https://www.domain.com/file.png",
                            description =   "Billy's picture"
                        },
                        new Image()
                        {
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661"
                        }
                    },
                    expiration_time = 1549063157000
                },
                brand_name = "sift",
                site_country = "US",
                site_domain = "sift.com",
            };

            string updateListingBody = "{\"$type\":\"$update_content\",\"$user_id\":\"fyw3989sjpqr71\",\"$content_id\":\"listing-23412\",\"$session_id\":\"a234ksjfgn435sfg\",\"$status\":\"$active\",\"$ip\":\"255.255.255.0\",\"$listing\":{\"$subject\":\"2 Bedroom Apartment for Rent\",\"$body\":\"Capitol Hill Seattle brand new condo. 2 bedrooms and 1 full bath.\",\"$contact_email\":\"alex_301@domain.com\",\"$contact_address\":{\"$name\":\"Bill Jones\",\"$address_1\":\"abc\",\"$address_2\":\"xyz\",\"$city\":\"New London\",\"$region\":\"New Hampshire\",\"$country\":\"US\",\"$zipcode\":\"03257\",\"$phone\":\"1-415-555-6041\"},\"$locations\":[{\"$name\":\"Bill Jones\",\"$address_1\":\"abc\",\"$address_2\":\"xyz\",\"$city\":\"Seattle\",\"$region\":\"Washington\",\"$country\":\"US\",\"$zipcode\":\"98112\",\"$phone\":\"1-415-555-6041\"},{\"$name\":\"Bill Jones\"}],\"$listed_items\":[{\"$item_id\":\"0cc175b9c0f1b6a831c399e269772661\",\"$product_title\":\"https://www.domain.com/file.png\",\"$price\":2950000000,\"$currency_code\":\"USD\",\"$quantity\":1,\"$upc\":\"6786211451001\",\"$sku\":\"abc\",\"$isbn\":\"0446576220\",\"$brand\":\"abc\",\"$manufacturer\":\"abc\",\"$category\":\"abc\",\"$tags\":[\"heat\",\"washer/dryer\"],\"$color\":\"ab\",\"$size\":\"ab\"}],\"$images\":[{\"$md5_hash\":\"0cc175b9c0f1b6a831c399e269772661\",\"$link\":\"https://www.domain.com/file.png\",\"$description\":\"Billy's picture\"},{\"$md5_hash\":\"0cc175b9c0f1b6a831c399e269772661\"}],\"$expiration_time\":1549063157000},\"$browser\":{\"$user_agent\":\"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36\",\"$accept_language\":\"en-US\",\"$content_language\":\"en-GB\"},\"$brand_name\":\"sift\",\"$site_country\":\"US\",\"$site_domain\":\"sift.com\"}";

            Assert.Equal(updateListingBody, updateContent.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = updateContent
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = updateContent,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        //UpdateContentMessage
        [Fact]
        public void TestUpdateContentMessage()
        {
            var updateContent = new UpdateContent
            {
                user_id = "fyw3989sjpqr71",
                content_id = "message-23412",
                session_id = "a234ksjfgn435sfg",
                status = "$active",
                ip = "255.255.255.0",
                message = new Message()
                {
                    body = "Lets meet at 5pm",
                    contact_email = "alex_301@domain.com",
                    root_content_id = "listing-123",
                    recipient_user_ids = new ObservableCollection<string>() { "fy9h989sjphh71" },
                    images = new ObservableCollection<Image>()
                    {
                        new Image()
                        {
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661",
                            link = "https://www.domain.com/file.png",
                            description =   "My hike today!"
                        },
                        new Image()
                        {
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661"
                        }
                    },
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
            };

            string updateMessageBody = "{\"$type\":\"$update_content\",\"$user_id\":\"fyw3989sjpqr71\",\"$content_id\":\"message-23412\",\"$session_id\":\"a234ksjfgn435sfg\",\"$status\":\"$active\",\"$ip\":\"255.255.255.0\",\"$message\":{\"$body\":\"Lets meet at 5pm\",\"$contact_email\":\"alex_301@domain.com\",\"$root_content_id\":\"listing-123\",\"$recipient_user_ids\":[\"fy9h989sjphh71\"],\"$images\":[{\"$md5_hash\":\"0cc175b9c0f1b6a831c399e269772661\",\"$link\":\"https://www.domain.com/file.png\",\"$description\":\"My hike today!\"},{\"$md5_hash\":\"0cc175b9c0f1b6a831c399e269772661\"}]},\"$browser\":{\"$user_agent\":\"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36\",\"$accept_language\":\"en-US\",\"$content_language\":\"en-GB\"},\"$brand_name\":\"sift\",\"$site_country\":\"US\",\"$site_domain\":\"sift.com\"}";

            Assert.Equal(updateMessageBody, updateContent.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = updateContent
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = updateContent,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        //UpdateContentPost
        [Fact]
        public void TestUpdateContentPost()
        {
            var updateContent = new UpdateContent
            {
                user_id = "fyw3989sjpqr71",
                content_id = "post-23412",
                session_id = "a234ksjfgn435sfg",
                status = "$active",
                ip = "255.255.255.0",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                post = new Post()
                {
                    subject = "My new apartment!",
                    body = "Moved into my new apartment yesterday.",
                    contact_email = "alex_301@domain.com",
                    contact_address = new Address()
                    {
                        name = "Bill Jones",
                        address_1 = "abc",
                        address_2 = "xyz",
                        city = "New London",
                        region = "New Hampshire",
                        country = "US",
                        zipcode = "03257",
                        phone = "1-415-555-6041"
                    },
                    locations = new ObservableCollection<Address>()
                    {
                        new Address()
                        {
                            name = "Bill Jones",
                            address_1 = "abc",
                            address_2 = "xyz",
                            city = "Seattle",
                            region = "Washington",
                            country = "US",
                            zipcode = "98112",
                            phone = "1-415-555-6041"
                        },
                        new Address()
                        {
                            name = "Bill Jones"
                        }

                    },
                    categories = new ObservableCollection<string>() { "Personal" },
                    images = new ObservableCollection<Image>()
                    {
                        new Image()
                        {
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661",
                            link = "https://www.domain.com/file.png",
                            description =   "View from the window!"
                        },
                        new Image()
                        {
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661"
                        }
                    },
                    expiration_time = 1549063157000
                },
                brand_name = "sift",
                site_country = "US",
                site_domain = "sift.com",
            };

            string updatePostBody = "{\"$type\":\"$update_content\",\"$user_id\":\"fyw3989sjpqr71\",\"$content_id\":\"post-23412\",\"$session_id\":\"a234ksjfgn435sfg\",\"$status\":\"$active\",\"$ip\":\"255.255.255.0\",\"$post\":{\"$subject\":\"My new apartment!\",\"$body\":\"Moved into my new apartment yesterday.\",\"$contact_email\":\"alex_301@domain.com\",\"$contact_address\":{\"$name\":\"Bill Jones\",\"$address_1\":\"abc\",\"$address_2\":\"xyz\",\"$city\":\"New London\",\"$region\":\"New Hampshire\",\"$country\":\"US\",\"$zipcode\":\"03257\",\"$phone\":\"1-415-555-6041\"},\"$locations\":[{\"$name\":\"Bill Jones\",\"$address_1\":\"abc\",\"$address_2\":\"xyz\",\"$city\":\"Seattle\",\"$region\":\"Washington\",\"$country\":\"US\",\"$zipcode\":\"98112\",\"$phone\":\"1-415-555-6041\"},{\"$name\":\"Bill Jones\"}],\"$categories\":[\"Personal\"],\"$images\":[{\"$md5_hash\":\"0cc175b9c0f1b6a831c399e269772661\",\"$link\":\"https://www.domain.com/file.png\",\"$description\":\"View from the window!\"},{\"$md5_hash\":\"0cc175b9c0f1b6a831c399e269772661\"}],\"$expiration_time\":1549063157000},\"$browser\":{\"$user_agent\":\"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36\",\"$accept_language\":\"en-US\",\"$content_language\":\"en-GB\"},\"$brand_name\":\"sift\",\"$site_country\":\"US\",\"$site_domain\":\"sift.com\"}";

            Assert.Equal(updatePostBody, updateContent.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = updateContent
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = updateContent,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        //UpdateContentProfile
        [Fact]
        public void TestUpdateContentProfile()
        {
            var updateContent = new UpdateContent
            {
                user_id = "fyw3989sjpqr71",
                content_id = "listing-23412",
                session_id = "a234ksjfgn435sfg",
                status = "$active",
                ip = "255.255.255.0",
                profile = new Profile()
                {
                    body = "Hi! My name is Alex and I just moved to New London!",
                    contact_email = "alex_301@domain.com",
                    contact_address = new Address()
                    {
                        name = "Alex Smith",
                        address_1 = "abc",
                        address_2 = "xyz",
                        city = "New London",
                        region = "New Hampshire",
                        country = "US",
                        zipcode = "03257",
                        phone = "1-415-555-6041"
                    },
                    images = new ObservableCollection<Image>()
                    {
                        new Image()
                        {
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661",
                            link = "https://www.domain.com/file.png",
                            description = "Alexs picture"
                        },
                        new Image()
                        {
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661"
                        }
                    },
                    categories = new ObservableCollection<string>() { "Friends", "Long-term dating" }
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
            };

            string updateProfileBody = "{\"$type\":\"$update_content\",\"$user_id\":\"fyw3989sjpqr71\",\"$content_id\":\"listing-23412\",\"$session_id\":\"a234ksjfgn435sfg\",\"$status\":\"$active\",\"$ip\":\"255.255.255.0\",\"$profile\":{\"$body\":\"Hi! My name is Alex and I just moved to New London!\",\"$contact_email\":\"alex_301@domain.com\",\"$contact_address\":{\"$name\":\"Alex Smith\",\"$address_1\":\"abc\",\"$address_2\":\"xyz\",\"$city\":\"New London\",\"$region\":\"New Hampshire\",\"$country\":\"US\",\"$zipcode\":\"03257\",\"$phone\":\"1-415-555-6041\"},\"$images\":[{\"$md5_hash\":\"0cc175b9c0f1b6a831c399e269772661\",\"$link\":\"https://www.domain.com/file.png\",\"$description\":\"Alexs picture\"},{\"$md5_hash\":\"0cc175b9c0f1b6a831c399e269772661\"}],\"$categories\":[\"Friends\",\"Long-term dating\"]},\"$browser\":{\"$user_agent\":\"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36\",\"$accept_language\":\"en-US\",\"$content_language\":\"en-GB\"},\"$brand_name\":\"sift\",\"$site_country\":\"US\",\"$site_domain\":\"sift.com\"}";

            Assert.Equal(updateProfileBody, updateContent.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = updateContent
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = updateContent,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

        //UpdateContent.Review
        [Fact]
        public void TestUpdateContentReview()
        {
            var updateContent = new UpdateContent
            {
                user_id = "fyw3989sjpqr71",
                content_id = "review-23412",
                session_id = "a234ksjfgn435sfg",
                status = "$active",
                ip = "255.255.255.0",
                review = new Review()
                {
                    subject = "Amazing Tacos!",
                    body = "I ate the tacos.",
                    contact_email = "alex_301@domain.com",
                    locations = new ObservableCollection<Address>()
                    {
                        new Address()
                        {
                            name = "Bill Jones",
                            address_1 = "abc",
                            address_2 = "xyz",
                            city = "Seattle",
                            region = "Washington",
                            country = "US",
                            zipcode = "98112",
                            phone = "1-415-555-6041"
                        },
                        new Address()
                        {
                            name = "Bill Jones"
                        }

                    },
                    item_reviewed = new Item()
                    {
                        item_id = "B004834GQO",
                        product_title = "The Slanket Blanket-Texas Tea",
                        price = 39990000,
                        currency_code = "USD",
                        upc = "6786211451001",
                        sku = "004834GQ",
                        isbn = "0446576220",
                        brand = "Slanket",
                        manufacturer = "Slanket",
                        category = "Blankets & Throws",
                        tags = new ObservableCollection<string>() { "Awesome", "Wintertime specials" },
                        color = "Texas Tea",
                        size = "6",
                    },

                    reviewed_content_id = "listing-234234",
                    rating = 4.5,
                    images = new ObservableCollection<Image>()
                    {
                        new Image()
                        {
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661",
                            link = "https://www.domain.com/file.png",
                            description = "Calamari tacos."
                        },
                        new Image()
                        {
                            md5_hash = "0cc175b9c0f1b6a831c399e269772661"
                        }
                    },
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
            };

            string updateReviewBody = "{\"$type\":\"$update_content\",\"$user_id\":\"fyw3989sjpqr71\",\"$content_id\":\"review-23412\",\"$session_id\":\"a234ksjfgn435sfg\",\"$status\":\"$active\",\"$ip\":\"255.255.255.0\",\"$review\":{\"$subject\":\"Amazing Tacos!\",\"$body\":\"I ate the tacos.\",\"$contact_email\":\"alex_301@domain.com\",\"$locations\":[{\"$name\":\"Bill Jones\",\"$address_1\":\"abc\",\"$address_2\":\"xyz\",\"$city\":\"Seattle\",\"$region\":\"Washington\",\"$country\":\"US\",\"$zipcode\":\"98112\",\"$phone\":\"1-415-555-6041\"},{\"$name\":\"Bill Jones\"}],\"$item_reviewed\":{\"$item_id\":\"B004834GQO\",\"$product_title\":\"The Slanket Blanket-Texas Tea\",\"$price\":39990000,\"$currency_code\":\"USD\",\"$upc\":\"6786211451001\",\"$sku\":\"004834GQ\",\"$isbn\":\"0446576220\",\"$brand\":\"Slanket\",\"$manufacturer\":\"Slanket\",\"$category\":\"Blankets & Throws\",\"$tags\":[\"Awesome\",\"Wintertime specials\"],\"$color\":\"Texas Tea\",\"$size\":\"6\"},\"$reviewed_content_id\":\"listing-234234\",\"$rating\":4.5,\"$images\":[{\"$md5_hash\":\"0cc175b9c0f1b6a831c399e269772661\",\"$link\":\"https://www.domain.com/file.png\",\"$description\":\"Calamari tacos.\"},{\"$md5_hash\":\"0cc175b9c0f1b6a831c399e269772661\"}]},\"$browser\":{\"$user_agent\":\"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36\",\"$accept_language\":\"en-US\",\"$content_language\":\"en-GB\"},\"$brand_name\":\"sift\",\"$site_country\":\"US\",\"$site_domain\":\"sift.com\"}";

            Assert.Equal(updateReviewBody, updateContent.ToJson());

            EventRequest eventRequest = new EventRequest
            {
                Event = updateContent
            };

            Assert.Equal("https://api.sift.com/v205/events", eventRequest.Request.RequestUri!.ToString());

            eventRequest = new EventRequest
            {
                Event = updateContent,
                AbuseTypes = { "legacy", "payment_abuse" },
                ReturnScore = true
            };

            Assert.Equal("https://api.sift.com/v205/events?abuse_types=legacy,payment_abuse&return_score=true",
                          Uri.UnescapeDataString(eventRequest.Request.RequestUri!.ToString()));
        }

    }
}
