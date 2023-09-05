﻿using Microsoft.Win32;
using Sift;
using System.Collections.ObjectModel;
using Xunit;

namespace TestProjectX.ReservedEvents
{
    public class Verifications
    {
        [Fact]
        public void IntegrationTest_Verification()
        {
            var sift = new Client("ccd68efbe25809bc");
            var sessionId = "sessionId";
            var verification = new Verification
            {
                user_id = "billy_jones_301",
                session_id = "gigtleqddo84l8cm15qe4il",
                status = "$pending",
                browser = new Browser
                {
                    user_agent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36",
                    accept_language = "en-US",
                    content_language = "en-GB"
                },
                verified_event = "$login",
                verified_entity_id = sessionId,
                verification_type = "$sms",
                verified_value = "14155551212",
                reason = "$user_setting",
                brand_name = "sift",
                site_domain = "sift.com",
                site_country = "US"
            };
            EventRequest eventRequest = new EventRequest()
            {
                Event = verification
            };
            EventResponse res = sift.SendAsync(eventRequest).Result;
            Assert.Equal("OK", res.ErrorMessage);
            Assert.Equal("0", res.Status.ToString());
        }
    }
}