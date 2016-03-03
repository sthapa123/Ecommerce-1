using System.Collections.Generic;
using MrCMS.ACL;

namespace MrCMS.Web.Apps.Amazon.ACL
{
    public class AmazonAdminMenuACL : ACLRule
    {
        public const string Show = "Show";

        public override string DisplayName
        {
            get { return "Amazon Admin Menu"; }
        }

        protected override List<string> GetOperations()
        {
            return new List<string> { Show };
        }
    }
}