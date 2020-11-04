using System;

namespace Session07
{
	public abstract class BankAccount
	{
		protected decimal _currentFunds;

		public BankAccount(decimal startingFunds)
		{
			_currentFunds = startingFunds;
		}

		public decimal CurrentFunds()
		{
			return _currentFunds;
		}

		public abstract void AddInterest();
	}

	public enum AccountType
	{
		Savings,
		Current
	}

	public class BankAccountDto
	{
		public AccountType AccountType { get; set; }
		public decimal CurrentFunds { get; set; }
	}

	public class BankAccountFactory
	{
		public BankAccount BuildFrom(BankAccountDto dto)
		{
			switch (dto.AccountType)
			{
				case AccountType.Current:
					return new CurrentAccount(dto.CurrentFunds);
				case AccountType.Savings:
					return new SavingsAccount(dto.CurrentFunds);
				default:
					throw new Exception("Unreecognised account type");
			}
		}
	}

	public class SavingsAccount : BankAccount
	{
		public SavingsAccount(decimal startingFunds) : base(startingFunds)
		{ }

		public override void AddInterest()
		{
			_currentFunds *= 1.05m;
		}
	}

	public class CurrentAccount : BankAccount
	{
		public CurrentAccount(decimal startingFunds) : base(startingFunds)
		{ }

		public override void AddInterest()
		{
			_currentFunds *= 1.01m;
		}
	}
}
