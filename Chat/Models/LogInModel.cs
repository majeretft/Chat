using System.ComponentModel.DataAnnotations;

namespace Chat.Models
{
	public class LogInModel
	{
		[Required]
		public string Login { get; set; }

		[Required]
		public string Password { get; set; }

		public string ReturnUrl { get; set; }
	}
}