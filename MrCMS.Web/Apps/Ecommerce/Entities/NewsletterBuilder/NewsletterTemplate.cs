﻿using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MrCMS.Entities;

namespace MrCMS.Web.Apps.Ecommerce.Entities.NewsletterBuilder
{
    public class NewsletterTemplate : SiteEntity
    {
        [Required]
        public virtual string Name { get; set; }
        public virtual string BaseTemplate { get; set; }
        public virtual string Divider { get; set; }
        public virtual string FreeTextTemplate { get; set; }
        public virtual string ImageAndTextTemplate { get; set; }
        public virtual string ProductGridTemplate { get; set; }
        public virtual string ProductRowTemplate { get; set; }
        public virtual string ProductTemplate { get; set; }
        public virtual string BannerTemplate { get; set; }

        public virtual IList<Newsletter> Newsletters { get; set; }
    }
}