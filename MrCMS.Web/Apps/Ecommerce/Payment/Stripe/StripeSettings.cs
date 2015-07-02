using System.ComponentModel;
using MrCMS.Settings;

namespace MrCMS.Web.Apps.Ecommerce.Payment.Stripe
{
    public class StripeSettings : SiteSettingsBase
    {
        public bool Enabled { get; set; }

        [DisplayName("Key")]
        public string Key { get; set; }

        public string GetApiUrl()
        {
            return "https://checkout.stripe.com/checkout.js";
        }
    }
}