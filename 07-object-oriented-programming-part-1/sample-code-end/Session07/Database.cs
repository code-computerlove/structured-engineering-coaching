using System;
using System.Security.Cryptography;
using FakeItEasy;
using Xunit;

namespace Session07
{
	public enum PasswordHashType
	{
		Pbkdf2,
		BCrypt
	}

	public class UserDto
	{
		public string PasswordHash { get; set; }
		public string PasswordSalt { get; set; }
		public int PasswordIterationCount { get; set; }
		public PasswordHashType PasswordHashType { get; set; }
	}

	public abstract class PasswordHash
	{
		public abstract bool Verify(string plainText);
	}

	public class BCrypt : PasswordHash
	{
		public BCrypt(string passwordHash, string passwordSalt, int passwordIterationCount)
		{
			
		}
		public override bool Verify(string plainText)
		{
			return true;
		}
	}

	public class Pbkdf2Hash : PasswordHash
	{
		private readonly string _passwordHash;
		private readonly string _passwordSalt;
		private readonly int _passwordIterationCount;

		public Pbkdf2Hash(string passwordHash, string passwordSalt, int passwordIterationCount)
		{
			_passwordHash = passwordHash;
			_passwordSalt = passwordSalt;
			_passwordIterationCount = passwordIterationCount;
		}

		public override bool Verify(string plainText)
		{
			var testHash = Hash(plainText);
			return testHash == _passwordHash;
		}

		private string Hash(string plainText)
		{
			var saltBytes = Convert.FromBase64String(_passwordSalt);
			var pbkdf2 = new Rfc2898DeriveBytes(plainText, saltBytes, _passwordIterationCount);
			var bytes = pbkdf2.GetBytes(20);
			return Convert.ToBase64String(bytes);
		}
	}

	public class User
	{
		private readonly PasswordHash _passwordHash;

		public User(PasswordHash passwordHash)
		{
			_passwordHash = passwordHash;
		}

		public bool VerifyPassword(string plainText)
		{
			return _passwordHash.Verify(plainText);
		}
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
			var dto = _database.Load<UserDto>(id);
			PasswordHash passwordHash = null;

			if (dto.PasswordHashType == PasswordHashType.Pbkdf2)
			{
				passwordHash= new Pbkdf2Hash(dto.PasswordHash, dto.PasswordSalt, dto.PasswordIterationCount);
			} else if (dto.PasswordHashType == PasswordHashType.BCrypt)
			{
				passwordHash = new BCrypt(dto.PasswordHash, dto.PasswordSalt, dto.PasswordIterationCount);
			}

			var user = new User(passwordHash);
			return user;
		}
	}

	public class Doh
	{
		[Fact]
		public void Nuts()
		{
			var userId = 5678;
			var database = FakeItEasy.A.Fake<IDatabase>();
			FakeItEasy.A.CallTo(() => database.Load<UserDto>(userId)).Returns(new UserDto
			{
				PasswordHash = "m02X6GeWpeqgWRx/3zNKanxSJJY=", // Password1234
				PasswordIterationCount = 500,
				PasswordSalt = "eH6wDUJHL57/dxJzbnpGVm5jTiQ=",
				PasswordHashType = PasswordHashType.Pbkdf2
			});

			var userRepository = new UserRepository(database);

			var user = userRepository.Get(userId);

			Assert.True(user.VerifyPassword("Password1234"));
		}
	}
}
