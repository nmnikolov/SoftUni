namespace Twitter.Web.Hubs
{
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;

    [HubName("notifications")]
    public class NotificationsHub : Hub
    {
        public override Task OnConnected()
        {
            string id = this.Context.User.Identity.GetUserId();
            this.Groups.Add(this.Context.ConnectionId, id);

            return base.OnConnected();
        }

        public void SendNotification(string userId)
        {
            this.Clients.Group(userId).receiveNotification();
        }
    }
}