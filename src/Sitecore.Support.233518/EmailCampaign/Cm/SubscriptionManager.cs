namespace Sitecore.Support.EmailCampaign.Cm
{
    using Sitecore.EmailCampaign.Cm.Factories;
    using Sitecore.Modules.EmailCampaign.Core;
    using Sitecore.Modules.EmailCampaign.Core.Contacts;
    using Sitecore.Modules.EmailCampaign.Factories;
    using Sitecore.Modules.EmailCampaign.ListManager;
    using Sitecore.Modules.EmailCampaign.Services;

    public class SubscriptionManager : Sitecore.EmailCampaign.Cm.SubscriptionManager
    {
        public SubscriptionManager(IContactService contactService, Sitecore.ExM.Framework.Diagnostics.ILogger logger, ListManagerWrapper listManagerWrapper, IExmCampaignService exmCampaignService, PipelineHelper pipelineHelper, ISendingManagerFactory sendingManagerFactory, IManagerRootService managerRootService, IRecipientManagerFactory recipientManagerFactory) : base(contactService, logger, listManagerWrapper, exmCampaignService, pipelineHelper, sendingManagerFactory, managerRootService, recipientManagerFactory)
        {

        }
    }
}