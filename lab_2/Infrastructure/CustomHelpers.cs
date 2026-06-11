using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using TP_WebApp2.Models;

namespace TP_WebApp2.Infrastructure
{
    public static class CustomHelpers
    {
        public static MvcHtmlString PrintOrders(this HtmlHelper html, List<OrderViewModel> orders)
        {
            string result = "";
            for (int i = 0; i < orders.Count(); i++)
            {
                TagBuilder innerTag = new TagBuilder("tr");
                innerTag.InnerHtml += $"<td>{orders[i].Id}</td>";
                innerTag.InnerHtml += $"<td>{orders[i].EventType}</td>";
                innerTag.InnerHtml += $"<td>{orders[i].EventDate}</td>";
                innerTag.InnerHtml += $"<td>{orders[i].EventDuration}</td>";
                innerTag.InnerHtml += $"<td>{orders[i].Price}</td>";
                innerTag.InnerHtml += $"<td>{orders[i].Status}</td>";
                innerTag.InnerHtml += $"<td>{orders[i].ChildrenCount}</td>";
                innerTag.InnerHtml += $"<td>{orders[i].CustomerEmail}</td>";

                innerTag.InnerHtml += "<td>";
                innerTag.InnerHtml += html.ActionLink(
                    "View",
                    "Details",
                    new { id = orders[i].Id },
                    new { @class = "btn btn-primary" }
                ).ToHtmlString();
                innerTag.InnerHtml += "</td>";

                innerTag.InnerHtml += "<td>";
                innerTag.InnerHtml += html.ActionLink(
                    "Edit",
                    "Edit",
                    new { id = orders[i].Id },
                    new { @class = "btn btn-success" }
                ).ToHtmlString();
                innerTag.InnerHtml += "</td>";

                innerTag.InnerHtml += $@"
                    <td>
                        <button class='btn btn-danger'
                                name='btnDelete'
                                value='{orders[i].Id}'
                                type='submit'>
                            Delete
                        </button>
                    </td>";

                result += innerTag.ToString();
            }
            return new MvcHtmlString(result);
        }
    }
}
