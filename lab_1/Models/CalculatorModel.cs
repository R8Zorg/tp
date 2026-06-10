using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TP_WebApp.Models
{
	public class CalculatorModel
	{
		[Required(ErrorMessage = "Please, input first number")]
		public ulong? FirstNumber { get; set; }
		[Range(-5, 99999, ErrorMessage = "Value must be between -5 and 99999")]
		public float SecondNumber { get; set; }
		public string Sign { get; set; }
		public float Result { get; set; }
	}
}