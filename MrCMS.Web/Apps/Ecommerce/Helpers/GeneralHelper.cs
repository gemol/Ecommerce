﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace MrCMS.Web.Apps.Ecommerce.Helpers
{
    public static class GeneralHelper
    {
        public static string GetDescriptionFromEnum(Enum value)
        {
            var attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .SingleOrDefault() as DescriptionAttribute;
            return attribute == null ? value.ToString() : attribute.Description;
        }
        public static bool HasValue(this string value)
        {
            return !String.IsNullOrWhiteSpace(value);
        }
        public static bool IsValidInput<T>(this string value) where T : struct
        {
             try
             {
                 if (value.HasValue())
                 {
                     var convertedValue=Convert.ChangeType(value, typeof(T));
                 }
                 return true;
             }
             catch (Exception)
             {
                 return false;
             }
        }
        public static bool IsValidDateTime(this string value)
        {
            try
            {
                DateTime result;
                DateTime.TryParse(value, out result);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static IEnumerable<SelectListItem> SelectDefaultValue(this IEnumerable<SelectListItem> list, string value)
        {
            var newList = list;
            if (newList != null && newList.Any() && !String.IsNullOrWhiteSpace(value))
            {
                foreach (var selectListItem in newList)
                    selectListItem.Selected = false;
                if (newList.SingleOrDefault(x => x.Value == value) != null)
                    newList.SingleOrDefault(x => x.Value == value).Selected = true;
            }
            return newList;
        }
    }
}