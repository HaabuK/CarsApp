using System;
using Microsoft.AspNetCore.Identity;

namespace CarsApp.Domain
{
	public class ApplicationUser : IdentityUser
	{
		public string City { get; set; }
	}
}

