using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MrCMS.Web.Apps.Ecommerce.Payment.Stripe.Models
{
    public class StripePostInfo
    {
        public string ApiUrl { get; set; }
        public string Key { get; set; }
        public string name { get; set; }
        public string currency { get; set; }
        public string email { get; set; }
        public string amount { get; set; }
        public string description { get; set; }

    }
}