using Sift;
using System.Collections.ObjectModel;
using Xunit;

namespace Test.EventsAPI
{
    public class Contents
    {
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
    }
}
