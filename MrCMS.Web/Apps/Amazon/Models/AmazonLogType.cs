﻿using System.ComponentModel;

namespace MrCMS.Web.Apps.Amazon.Models
{
    public enum AmazonLogType
    {
        [Description("Api")]
        Api,
        [Description("Listings")]
        Listings,
        [Description("Orders")]
        Orders,
        [Description("App Settings")]
        AppSettings,
        [Description("Seller Settings")]
        SellerSettings,
    }
}