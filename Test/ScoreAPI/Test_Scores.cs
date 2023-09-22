using Sift;
using Xunit;

namespace Test.ScoreAPI
{
    public class Test
    {
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
