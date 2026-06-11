using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TP_WebApp2.Models
{
	[DisplayName("Order")]
	public class OrderViewModel
	{
		[Display(Name = "Order id")]
		public int Id { get; set; }

		[Display(Name = "Event type")]
		public string EventType { get; set; }

		[Display(Name = "Event date")]
		public DateTime EventDate { get; set; }

		[Display(Name = "Event duration")]
		public TimeSpan EventDuration { get; set; }

		[Display(Name = "Price")]
		[Range(0, (double)decimal.MaxValue, ErrorMessage = "Price cannot be less than zero 😑")]
		public decimal Price { get; set; }

		[Display(Name = "Status")]
		public string Status { get; set; }

		[Display(Name = "Children count")]
		[Range(0, short.MaxValue, ErrorMessage = "Children count cannot be less than zero 🤨")]
		public short ChildrenCount { get; set; }

		[Display(Name = "Customer email")]
		[DataType(DataType.EmailAddress)]
		public string CustomerEmail { get; set; }
	}
}