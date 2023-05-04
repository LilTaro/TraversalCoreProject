using Microsoft.AspNetCore.Identity;

namespace TraversalCoreProject.Models
{
	public class customIdentityValidator:IdentityErrorDescriber
	{
		public override IdentityError PasswordRequiresDigit()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresDigit",
				Description = "Parolada en az 1 Sayı Olmalı"
			};
		}
		public override IdentityError PasswordTooShort(int length)
		{
			return new IdentityError()
			{
				Code = "PasswordTooShort",
				Description = $"Parola minimum {length} Karakter Olmalıdır"
			};
		}
		public override IdentityError PasswordRequiresLower()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresLower",
				Description = "Parolada en az 1 Küçük Harf Olmalı"
			};
		}
		public override IdentityError PasswordRequiresUpper() 
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresUpper",
				Description = "Parolada en az 1 Büyük Harf Olmalı"
			};
		}
		public override IdentityError PasswordRequiresNonAlphanumeric()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresNonAlphanumeric",
				Description = "Parolada en az 1 Sembol Olmalı"
			};
		}
	}
}
