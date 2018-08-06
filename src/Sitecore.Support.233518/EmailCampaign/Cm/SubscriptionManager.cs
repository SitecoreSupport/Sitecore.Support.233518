namespace Sitecore.Support.EmailCampaign.Cm
{
    using System;
    using System.Text.RegularExpressions;
    using Sitecore.Data;
    using Sitecore.EmailCampaign.Cm.Factories;
    using Sitecore.Modules.EmailCampaign;
    using Sitecore.Modules.EmailCampaign.Core;
    using Sitecore.Modules.EmailCampaign.Core.Contacts;
    using Sitecore.Modules.EmailCampaign.Factories;
    using Sitecore.Modules.EmailCampaign.ListManager;
    using Sitecore.Modules.EmailCampaign.Services;
    using Sitecore.Data.Items;
    using Sitecore.Data.Properties;
    using Sitecore.Tasks;
    using Sitecore.EmailCampaign.Model.Web.Settings;
    using System.Xml;
    using Sitecore.Configuration;

    public class SubscriptionManager : Sitecore.EmailCampaign.Cm.SubscriptionManager
    {
        public SubscriptionManager(IContactService contactService, Sitecore.ExM.Framework.Diagnostics.ILogger logger, ListManagerWrapper listManagerWrapper, IExmCampaignService exmCampaignService, PipelineHelper pipelineHelper, ISendingManagerFactory sendingManagerFactory, IManagerRootService managerRootService, IRecipientManagerFactory recipientManagerFactory) : base(contactService, logger, listManagerWrapper, exmCampaignService, pipelineHelper, sendingManagerFactory, managerRootService, recipientManagerFactory)
        {

        }

        /// <summary>
        /// Removes old nodes from the dbo.Properties table
        /// </summary>
        public virtual void RemoveObsoleteMappings()
        {
            Database contentDb = Util.GetContentDb();
            XmlNode confirmationPeriod = Factory.GetConfigNode("cleanSubsciptionIDsConfirmationPeriod");
            DateTime value = DateTime.UtcNow.AddDays((double)(-System.Convert.ToDouble(confirmationPeriod.Attributes.Item(0).Value)));
            foreach (string current in contentDb.DataManager.GetPropertyKeys("EmailCampaign"))
            {
                string[] array = contentDb.Properties[current].Split(new char[]
                {
            '|'
                });
                if (array.Length >= 3)
                {
                    string s = array[1];
                    DateTime dateTime;
                    if (DateTime.TryParse(s, out dateTime) && dateTime.CompareTo(value) < 0)
                    {
                        var x = Regex.Replace(current, $"{contentDb.PropertyStore.Prefix}_", string.Empty, RegexOptions.IgnoreCase);
                        contentDb.Properties.Remove(x);
                    }
                }
            }
        }
    }
}