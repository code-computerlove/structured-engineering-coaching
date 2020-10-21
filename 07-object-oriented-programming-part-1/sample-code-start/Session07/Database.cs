using System;
using System.Security.Cryptography;
using FakeItEasy;
using Xunit;

namespace Session07
{
	public class User
	{
		public string PasswordHash { get; set; }
		public string PasswordSalt { get; set; }
		public int PasswordIterationCount { get; set; }
	}

	public interface IDatabase
	{
		T Load<T>(int id);
	}

	public class UserRepository
	{
		private readonly IDatabase _database;

		public UserRepository(IDatabase database)
		{
			_database = database;
		}

		public User Get(int id)
		{
			return _database.Load<User>(id);
		}
	}

	public class AuthService
	{
		public static string Hash(string plainText, string salt, int iterations)
		{
			var saltBytes = Convert.FromBase64String(salt);
			var pbkdf2 = new Rfc2898DeriveBytes(plainText, saltBytes, iterations);
			var bytes = pbkdf2.GetBytes(20);
			return Convert.ToBase64String(bytes);
		}

		public static bool Verify(string plainText, string passwordHash, string salt, int iterations)
		{
			var testHash = Hash(plainText, salt, iterations);
			return testHash == passwordHash;
		}
	}

	public class Doh
	{
		[Fact]
		public void Nuts()
		{
			var userId = 5678;
			var database = A.Fake<IDatabase>();
			A.CallTo(() => database.Load<User>(userId)).Returns(new User
			{
				PasswordHash = "m02X6GeWpeqgWRx/3zNKanxSJJY=", // Password1234
				PasswordIterationCount = 500,
				PasswordSalt = "eH6wDUJHL57/dxJzbnpGVm5jTiQ="
			});

			var userRepository = new UserRepository(database);

			var user = userRepository.Get(userId);

			Assert.True(
				AuthService.Verify(
					"Password1234",
					user.PasswordHash,
					user.PasswordSalt,
					user.PasswordIterationCount));
		}
	}
}
