using System.Web;
using System.Web.Mvc;
using MrCMS.Web.Apps.Ecommerce.Controllers;
using MrCMS.Web.Apps.Ecommerce.Payment.Stripe.Models;

namespace MrCMS.Web.Apps.Ecommerce.Payment.Stripe.Services
{
    public interface IStripePaymentService
    {
        StripePostInfo GetInfo();
    }
}