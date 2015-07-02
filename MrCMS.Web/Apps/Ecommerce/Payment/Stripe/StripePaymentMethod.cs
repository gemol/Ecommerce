using MrCMS.Web.Apps.Ecommerce.Models;

namespace MrCMS.Web.Apps.Ecommerce.Payment.Stripe
{
    public class StripePaymentMethod : BasePaymentMethod
    {
        private readonly StripeSettings _StripeSettings;

        public StripePaymentMethod(StripeSettings StripeSettings)
        {
            _StripeSettings = StripeSettings;
        }

        public override string Name
        {
            get { return "Stripe"; }
        }

        public override string SystemName
        {
            get { return "Stripe"; }
        }

        public override string ControllerName
        {
            get { return "Stripe"; }
        }

        public override string ActionName
        {
            get { return "Form"; }
        }

        public override PaymentType PaymentType
        {
            get { return PaymentType.Redirection; }
        }

        public override bool Enabled
        {
            get { return _StripeSettings.Enabled; }
        }

        protected override bool StandardCanUseLogic(CartModel cart)
        {
            return !cart.IsPayPalTransaction;
        }
    }
}