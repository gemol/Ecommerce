using System.Web.Mvc;
using MrCMS.Settings;
using MrCMS.Web.Apps.Ecommerce.ACL;
using MrCMS.Web.Apps.Ecommerce.Areas.Admin.ModelBinders;
using MrCMS.Web.Apps.Ecommerce.Payment.Stripe;
using MrCMS.Web.Areas.Admin.Helpers;
using MrCMS.Website;
using MrCMS.Website.Binders;
using MrCMS.Website.Controllers;

namespace MrCMS.Web.Apps.Ecommerce.Areas.Admin.Controllers
{
    public class StripeSettingsController : MrCMSAppAdminController<EcommerceApp>
    {
        private readonly IConfigurationProvider _configurationProvider;

        public StripeSettingsController(IConfigurationProvider configurationProvider)
        {
            _configurationProvider = configurationProvider;
        }

        [MrCMSACLRule(typeof(StripeSettingsACL), StripeSettingsACL.View)]
        public ViewResult Index()
        {
            return View(_configurationProvider.GetSiteSettings<StripeSettings>());
        }

        [HttpPost]
        [MrCMSACLRule(typeof(StripeSettingsACL), StripeSettingsACL.View)]
        public RedirectToRouteResult Save([IoCModelBinder(typeof(StripeSettingsModelBinder))] StripeSettings settings)
        {
            _configurationProvider.SaveSettings(settings);
            TempData.SuccessMessages().Add("Stripe Settings saved successfully.");
            return RedirectToAction("Index");
        }
    }
}