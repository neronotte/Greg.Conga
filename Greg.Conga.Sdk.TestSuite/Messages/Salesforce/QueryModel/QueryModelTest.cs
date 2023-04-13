using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Greg.Conga.Sdk.Messages.Salesforce.QueryModel
{
	[TestClass]
	public class QueryModelTest
	{
		[TestMethod]
		public void QueryWithTable()
		{
			var query = new QueryExpression("account");

			Assert.AreEqual("SELECT Id FROM account", query.ToString());
		}




		[TestMethod]
		public void QueryWithTableAndColumns1()
		{
			var query = new QueryExpression("account");
			query.AddColumns("Id", "Name");

			Assert.AreEqual("SELECT Id, Name FROM account", query.ToString());
		}

		[TestMethod]
		public void QueryWithTableAndColumns2()
		{
			var query = new QueryExpression("account");
			query.AddColumns("Id");
			query.AddColumns("Name");

			Assert.AreEqual("SELECT Id, Name FROM account", query.ToString());
		}

		[TestMethod]
		public void QueryWithTableAndColumns3()
		{
			var query = new QueryExpression("account");
			query.Select.AddRange(new[] { "Id", "Name" });

			Assert.AreEqual("SELECT Id, Name FROM account", query.ToString());
		}

		[TestMethod]
		public void QueryWithTableAndColumns4()
		{
			var query = new QueryExpression("account");
			query.Select.Add("Id");
			query.Select.Add("Name");

			Assert.AreEqual("SELECT Id, Name FROM account", query.ToString());
		}








		[TestMethod]
		public void QueryWithTableAndConditions1()
		{
			var query = new QueryExpression("account");
			query.AddCondition("Name", ConditionOperator.Equal, "Riccardo");
			Assert.AreEqual("SELECT Id FROM account WHERE Name = 'Riccardo'", query.ToString());
		}

		[TestMethod]
		public void QueryWithTableAndConditions2()
		{
			var query = new QueryExpression("account");
			query.AddCondition("FirstName", ConditionOperator.Equal, "Riccardo");
			query.AddCondition("LastName", ConditionOperator.Equal, "Gregori");

			Assert.AreEqual("SELECT Id FROM account WHERE FirstName = 'Riccardo' AND LastName = 'Gregori'", query.ToString());
		}

		[TestMethod]
		public void QueryWithTableAndConditions3()
		{
			var query = new QueryExpression("account");
			query.AddCustomCondition("CreatedDate = LAST_FISCAL_QUARTER");

			Assert.AreEqual("SELECT Id FROM account WHERE CreatedDate = LAST_FISCAL_QUARTER", query.ToString());
		}

		[TestMethod]
		public void QueryWithTableAndConditions4()
		{
			var query = new QueryExpression("account");
			query.AddCustomCondition("CreatedDate = LAST_FISCAL_QUARTER");
			query.AddCondition("FirstName", ConditionOperator.Equal, "Riccardo");

			Assert.AreEqual("SELECT Id FROM account WHERE CreatedDate = LAST_FISCAL_QUARTER AND FirstName = 'Riccardo'", query.ToString());
		}















		[TestMethod]
		public void QueryWithTableAndGroup1()
		{
			var query = new QueryExpression("account");
			query.GroupBy("Name");
			Assert.AreEqual("SELECT Id FROM account GROUP BY Name", query.ToString());
		}

		[TestMethod]
		public void QueryWithTableAndGroup2()
		{
			var query = new QueryExpression("account");
			query.GroupBy("Name", "Field1");
			Assert.AreEqual("SELECT Id FROM account GROUP BY Name, Field1", query.ToString());
		}

		[TestMethod]
		public void QueryWithTableAndGroup3()
		{
			var query = new QueryExpression("account");
			query.GroupBy("Name", "Field1");
			query.GroupBy("Field2");
			Assert.AreEqual("SELECT Id FROM account GROUP BY Name, Field1, Field2", query.ToString());
		}

		[TestMethod]
		public void QueryWithTableAndColumnAndGroup1()
		{
			var query = new QueryExpression("account");
			query.AddColumns("Name", "Field2", "MAX(CreatedDate)");
			query.GroupBy("Name", "Field2");

			Assert.AreEqual("SELECT Name, Field2, MAX(CreatedDate) FROM account GROUP BY Name, Field2", query.ToString());
		}









		[TestMethod]
		public void QueryWithTableAndOrder1()
		{
			var query = new QueryExpression("account");
			query.OrderBy("Name");

			Assert.AreEqual("SELECT Id FROM account ORDER BY Name", query.ToString());
		}

		[TestMethod]
		public void QueryWithTableAndOrder2()
		{
			var query = new QueryExpression("account");
			query.OrderBy("Name", "CreatedDate");

			Assert.AreEqual("SELECT Id FROM account ORDER BY Name, CreatedDate", query.ToString());
		}

		[TestMethod]
		public void QueryWithTableAndOrder3()
		{
			var query = new QueryExpression("account");
			query.OrderBy("Name").ThenBy("CreatedDate");

			Assert.AreEqual("SELECT Id FROM account ORDER BY Name, CreatedDate", query.ToString());
		}

		[TestMethod]
		public void QueryWithTableAndOrder4()
		{
			var query = new QueryExpression("account");
			query.OrderBy("Name").ThenBy("CreatedDate", "LastLoginDate");

			Assert.AreEqual("SELECT Id FROM account ORDER BY Name, CreatedDate, LastLoginDate", query.ToString());
		}

		[TestMethod]
		public void QueryWithTableAndOrder5()
		{
			var query = new QueryExpression("account");
			query.OrderBy("Name").ThenBy("CreatedDate").ThenBy("LastLoginDate");

			Assert.AreEqual("SELECT Id FROM account ORDER BY Name, CreatedDate, LastLoginDate", query.ToString());
		}

		[TestMethod]
		public void QueryWithTableAndOrder6()
		{
			var query = new QueryExpression("account");
			query.OrderByDescending("Name").ThenBy("CreatedDate").ThenBy("LastLoginDate");

			Assert.AreEqual("SELECT Id FROM account ORDER BY Name DESC, CreatedDate, LastLoginDate", query.ToString());
		}

		[TestMethod]
		public void QueryWithTableAndOrder7()
		{
			var query = new QueryExpression("account");
			query.OrderByDescending("Name").ThenByDescending("CreatedDate").ThenBy("LastLoginDate");

			Assert.AreEqual("SELECT Id FROM account ORDER BY Name DESC, CreatedDate DESC, LastLoginDate", query.ToString());
		}

		[TestMethod]
		public void QueryWithTableAndOrder8()
		{
			var query = new QueryExpression("account");
			query.OrderBy("Name").ThenBy("CreatedDate").ThenByDescending("LastLoginDate");

			Assert.AreEqual("SELECT Id FROM account ORDER BY Name, CreatedDate, LastLoginDate DESC", query.ToString());
		}




		[TestMethod]
		public void QueryWithTableAndLimit()
		{
			var query = new QueryExpression("account");
			query.Limit = 100;

			Assert.AreEqual("SELECT Id FROM account LIMIT 100", query.ToString());
		}
	}
}
