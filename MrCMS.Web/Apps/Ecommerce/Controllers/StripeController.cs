using System.Web.Mvc;
using MrCMS.Web.Apps.Ecommerce.Pages;
using MrCMS.Web.Apps.Ecommerce.Payment.Stripe.Services;
using MrCMS.Website.Controllers;

namespace MrCMS.Web.Apps.Ecommerce.Controllers
{
    public class StripeController : MrCMSAppUIController<EcommerceApp>
    {
        private readonly IStripePaymentService _StripePaymentService;

        public StripeController(IStripePaymentService StripePaymentService)
        {
            _StripePaymentService = StripePaymentService;
        }

        [HttpGet]
        public PartialViewResult Form()
        {
            var info = _StripePaymentService.GetInfo();
            return PartialView(info);
        }
    }
}