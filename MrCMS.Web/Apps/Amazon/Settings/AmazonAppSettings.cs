﻿using System.ComponentModel;
using MrCMS.Settings;

namespace MrCMS.Web.Apps.Amazon.Settings
{
    public class AmazonAppSettings : SiteSettingsBase
    {
        [DisplayName("Application Name")]
        public string AppName { get; set; }

        [DisplayName("Application Version")]
        public string AppVersion { get; set; }

        [DisplayName("Application Language")]
        public string AppLanguage { get; set; }

        [DisplayName("Application Path")]
        public string AppPath { get; set; }

        [DisplayName("Signature Version")]
        public string SignatureVersion { get; set; }

        [DisplayName("Signature Method")]
        public string SignatureMethod { get; set; }

        [DisplayName("Api Endpoint")]
        public string ApiEndpoint { get; set; }

        [DisplayName("Orders Api Version")]
        public string OrdersApiVersion { get; set; }

        [DisplayName("Feeds Api Version")]
        public string FeedsApiVersion { get; set; }
     
        [DisplayName("Developer Account ID")]
        public string DeveloperAccountId { get; set; }

        [DisplayName("AWS Access Key ID")]
        public string AWSAccessKeyId { get; set; }

        [DisplayName("Secret Key")]
        public string SecretKey { get; set; }

        [DisplayName("Amazon Order Details Url")]
        public string AmazonOrderDetailsUrl { get; set; }

        public string GetOrdersApiEndpoint
        {
            get { return ApiEndpoint + "Orders/" + OrdersApiVersion; }
        }

        public override bool RenderInSettings
        {
            get { return false; }
        }
    }
}