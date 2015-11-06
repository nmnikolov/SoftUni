namespace Twitter.Web.Hubs
{
    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;

    [HubName("tweets")]
    public class TweetsHub : Hub
    {
        public void SendTweet(int tweetId)
        {
            this.Clients.Others.receiveTweet(tweetId);
        }
    }
}