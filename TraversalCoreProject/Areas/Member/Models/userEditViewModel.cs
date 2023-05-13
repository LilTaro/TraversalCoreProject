using Microsoft.AspNetCore.Http;

namespace TraversalCoreProject.Areas.Member.Models
{
	public class userEditViewModel
	{
        public string Name { get; set; }
		public string Surname { get; set; }
        public string Password { get; set; }
        public string confirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile Image { get; set; }
    }
}
