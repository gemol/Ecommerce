using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Web;
using System.Web.Mvc;
using MrCMS.Entities.Multisite;
using MrCMS.Web.Apps.Ecommerce.Entities;
using MrCMS.Web.Apps.Ecommerce.Entities.Orders;
using MrCMS.Web.Apps.Ecommerce.Helpers;
using MrCMS.Web.Apps.Ecommerce.Models;
using MrCMS.Web.Apps.Ecommerce.Payment.Stripe.Models;
using MrCMS.Web.Apps.Ecommerce.Services.Cart;
using MrCMS.Web.Apps.Ecommerce.Services.Orders;
using MrCMS.Web.Apps.Ecommerce.Settings;
using MrCMS.Website;
using Newtonsoft.Json;
using NHibernate;

namespace MrCMS.Web.Apps.Ecommerce.Payment.Stripe.Services
{
    public class StripePaymentService : IStripePaymentService
    {
        private readonly CartModel _cart;
        private readonly ICartBuilder _cartBuilder;
        private readonly EcommerceSettings _ecommerceSettings;
        private readonly IOrderPlacementService _orderPlacementService;
        private readonly ISession _session;
        private readonly Site _site;
        private readonly StripeSettings _stripeSettings;

        public StripePaymentService(StripeSettings stripeSettings, CartModel cart,
            EcommerceSettings ecommerceSettings, ICartBuilder cartBuilder,
            ISession session, IOrderPlacementService orderPlacementService, Site site)
        {
            _stripeSettings = stripeSettings;
            _cart = cart;
            _ecommerceSettings = ecommerceSettings;
            _cartBuilder = cartBuilder;
            _session = session;
            _orderPlacementService = orderPlacementService;
            _site = site;
        }

        public StripePostInfo GetInfo()
        {
            var postInfo = new StripePostInfo();
            postInfo.ApiUrl = _stripeSettings.GetApiUrl();
            postInfo.Key = _stripeSettings.Key;
            postInfo.name = _site.Name;
            postInfo.currency = _ecommerceSettings.CurrencyCode();
            postInfo.email = _cart.OrderEmail;
            postInfo.amount = _cart.TotalToPay.ToString(new CultureInfo("en-US", false).NumberFormat);
            postInfo.description = _cart.ItemQuantity.ToString();

            return postInfo;
        }
    }


}