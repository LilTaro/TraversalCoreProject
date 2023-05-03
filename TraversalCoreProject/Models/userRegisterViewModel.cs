using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProject.Models
{
	public class userRegisterViewModel
	{
        [Required(ErrorMessage = "Lütfen İsim Giriniz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Soyadınızı Giriniz")]
        public string Surname { get; set; }

		[Required(ErrorMessage = "Lütfen Kullanıcı Adı Giriniz")]
        public string Username { get; set; }

		[Required(ErrorMessage = "Lütfen Mail Giriniz")]
		public string Mail { get; set; }

		[Required(ErrorMessage = "Lütfen Şifre Giriniz")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Lütfen Şifreyi Tekrar Giriniz")]
		[Compare("Password",ErrorMessage = "Şifreler Uyuşmuyor")]
		public string confirmPassword { get; set; }
	}
}
