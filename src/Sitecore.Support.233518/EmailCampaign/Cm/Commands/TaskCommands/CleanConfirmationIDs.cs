namespace Sitecore.Support.EmailCampaign.Cm.Commands.TaskCommands
{
    using Sitecore.Data.Items;
    using Sitecore.Tasks;
    public class CleanConfirmationIDs
    {
        public void Execute(Item[] itemArray, CommandItem commandItem, ScheduleItem scheduledItem)
        {
            lock (typeof(CleanConfirmationIDs))
            {
                var manager = Sitecore.Configuration.Factory.CreateObject("exm/subscriptionManager", true) as Sitecore.Support.EmailCampaign.Cm.SubscriptionManager;
                manager.RemoveObsoleteMappings();
            }
        }
    }
}