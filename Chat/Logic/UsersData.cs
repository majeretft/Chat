using System.Collections.Generic;

namespace Chat.Logic
{
	public class UsersData
	{
		private static UsersData _instance;
		public List<User> Users { get; set; }
		public static UsersData Instance => _instance ?? (_instance = new UsersData());

		private UsersData()
		{
			Users = new List<User>();
		}
	}
}