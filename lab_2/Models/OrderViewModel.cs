using System.ComponentModel.DataAnnotations;

namespace lab_2.Models
{
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
        public decimal Price { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        [Display(Name = "Children count")]
        public short ChildrenCount { get; set; }

        [Display(Name = "Customer email")]
        [DataType(DataType.EmailAddress)]
        public string CustomerEmail { get; set; }
    }
}
