using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using static Sio.Cms.Lib.SioEnums;

namespace Sio.Cms.Lib
{
    public class SioCmsHelper
    {
        public static List<ViewModels.SioPages.ReadListItemViewModel> GetCategory(IUrlHelper Url, string culture, SioEnums.CatePosition position, string activePath = "")
        {
            var getTopCates = ViewModels.SioPages.ReadListItemViewModel.Repository.GetModelListBy
            (c => c.Specificulture == culture && c.SioPagePosition.Any(
              p => p.PositionId == (int)position)
            );
            var cates = getTopCates.Data ?? new List<ViewModels.SioPages.ReadListItemViewModel>();
            activePath = activePath.ToLower();
            foreach (var cate in cates)
            {
                switch (cate.Type)
                {
                    case SioPageType.Blank:
                        foreach (var child in cate.Childs)
                        {
                            child.DetailsUrl = Url.RouteUrl("Page", new { culture, seoName = child.SeoName });
                        }
                        break;

                    case SioPageType.StaticUrl:
                        cate.DetailsUrl = cate.StaticUrl;
                        break;

                    case SioPageType.Home:
                    case SioPageType.ListArticle:
                    case SioPageType.Article:
                    case SioPageType.Modules:
                    default:
                        cate.DetailsUrl = Url.RouteUrl("Page", new { culture, seoName = cate.SeoName });
                        break;
                }
                cate.IsActived = (cate.DetailsUrl == activePath
                    || (cate.Type == SioPageType.Home && activePath == string.Format("/{0}/home", culture)));
                cate.Childs.ForEach((Action<ViewModels.SioPages.ReadListItemViewModel>)(c =>
                {
                    c.IsActived = (
                    c.DetailsUrl == activePath);
                    cate.IsActived = cate.IsActived || c.IsActived;
                }));
            }
            return cates;
        }

        public static List<ViewModels.SioPages.ReadListItemViewModel> GetCategory(IUrlHelper Url, string culture, SioPageType cateType, string activePath = "")
        {
            var getTopCates = ViewModels.SioPages.ReadListItemViewModel.Repository.GetModelListBy
            (c => c.Specificulture == culture && c.Type == (int)cateType
            );
            var cates = getTopCates.Data ?? new List<ViewModels.SioPages.ReadListItemViewModel>();
            activePath = activePath.ToLower();
            foreach (var cate in cates)
            {
                switch (cate.Type)
                {
                    case SioPageType.Blank:
                        foreach (var child in cate.Childs)
                        {
                            child.DetailsUrl = Url.RouteUrl("Page", new { culture, pageName = child.SeoName });
                        }
                        break;

                    case SioPageType.StaticUrl:
                        cate.DetailsUrl = cate.StaticUrl;
                        break;

                    case SioPageType.Home:
                    case SioPageType.ListArticle:
                    case SioPageType.Article:
                    case SioPageType.Modules:
                    default:
                        cate.DetailsUrl = Url.RouteUrl("Page", new { culture, pageName = cate.SeoName });
                        break;
                }

                cate.IsActived = (
                    cate.DetailsUrl == activePath || (cate.Type == SioPageType.Home && activePath == string.Format("/{0}/home", culture))
                    );

                cate.Childs.ForEach((Action<ViewModels.SioPages.ReadListItemViewModel>)(c =>
                {
                    c.IsActived = (
                    c.DetailsUrl == activePath);
                    cate.IsActived = cate.IsActived || c.IsActived;
                }));
            }
            return cates;
        }


        public static string GetRouterUrl(string routerName, object routeValues, HttpRequest request, IUrlHelper Url)
        {
            return string.Format("{0}://{1}{2}", request.Scheme, request.Host,
                        Url.RouteUrl(routerName, routeValues)
                        );
        }


        public static string FormatPrice(double? price, string oldPrice = "0")
        {
            string strPrice = price?.ToString();
            if (string.IsNullOrEmpty(strPrice))
            {
                return "0";
            }
            string s1 = strPrice.Replace(",", string.Empty);
            if (CheckIsPrice(s1))
            {
                Regex rgx = new Regex("(\\d+)(\\d{3})");
                while (rgx.IsMatch(s1))
                {
                    s1 = rgx.Replace(s1, "$1" + "," + "$2");
                }
                return s1;
            }
            return oldPrice;
        }
        public static bool CheckIsPrice(string number)
        {
            if (number == null)
            {
                return false;
            }
            number = number.Replace(",", "");

            return double.TryParse(number, out double t);
        }

        public static double ReversePrice(string formatedPrice)
        {
            try
            {
                if (string.IsNullOrEmpty(formatedPrice))
                {
                    return 0;
                }
                return double.Parse(formatedPrice.Replace(",", string.Empty));
            }
            catch
            {
                return 0;
            }
        }
    }
}
