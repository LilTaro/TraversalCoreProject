using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Destination
	{
		[Key]
		public int DestinationID { get; set; }
        public string DestinationCity { get; set; }
        public string DestinationTime { get; set; }
        public double DestinationPrice { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; }
    }
}
