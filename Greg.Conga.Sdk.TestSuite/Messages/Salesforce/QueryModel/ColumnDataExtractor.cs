using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;

namespace Greg.Conga.Sdk.Messages.Salesforce.QueryModel
{
	[TestClass]
	public class ColumnDataExtractorTest
	{
		[TestMethod]
		public void TestExtractFromJObject_WithEmptyPartsArray_ThrowsException()
		{
			// Arrange
			var columnDataExtractor = new ColumnDataExtractor(string.Empty);

			// Act
			// Assert
			Assert.ThrowsException<NotImplementedException>(() => columnDataExtractor.ExtractFrom(new JObject()));
		}

		[TestMethod]
		public void TestExtractFromJObject_WithOnePart_ValueIsReturnedCorrectly()
		{
			// Arrange
			var columnDataExtractor = new ColumnDataExtractor("test1");

			var jObjectData = new JObject
			{
				["test1"] = "test value"
			};

			// Act
			var result = columnDataExtractor.ExtractFrom(jObjectData);

			// Assert
			Assert.AreEqual("test value", result);
		}

		[TestMethod]
		public void TestExtractFromJObject_WithMultipleParts_ValueIsReturnedCorrectly()
		{
			// Arrange
			var columnDataExtractor = new ColumnDataExtractor("foobar.test1.field1");

			var jObjectData = new JObject
			{
				["foobar"] = new JObject
				{
					["test1"] = new JObject
					{
						["field1"] = "test value"
					}
				}
			};

			// Act
			var result = columnDataExtractor.ExtractFrom(jObjectData);

			// Assert
			Assert.AreEqual("test value", result);
		}

		[TestMethod]
		public void TestExtractFromJObject_WithMultipleParts_NullValueIsReturned()
		{
			// Arrange
			var columnDataExtractor = new ColumnDataExtractor("foobar.test1.field1");

			var jObjectData = new JObject
			{
				["foobar"] = new JObject
				{
					["test1"] = null
				}
			};

			// Act
			var result = columnDataExtractor.ExtractFrom(jObjectData);

			// Assert
			Assert.IsNull(result);
		}

		[TestMethod]
		public void TestParse_WithNullOrEmptyColumnName_ReturnsEmptyArray()
		{
			// Arrange

			// Act
			var result1 = ColumnDataExtractor.Parse(null);
			var result2 = ColumnDataExtractor.Parse(string.Empty);

			// Assert
			Assert.AreEqual(0, result1.Length);
			Assert.AreEqual(0, result2.Length);
		}

		[TestMethod]
		public void TestParse_WithSimpleColumnName_ReturnsCorrectParts()
		{
			// Arrange

			// Act
			var result = ColumnDataExtractor.Parse("foobar");

			// Assert
			Assert.AreEqual(1, result.Length);
			Assert.AreEqual("foobar", result[0]);
		}

		[TestMethod]
		public void TestParse_WithComplexColumnName_ReturnsCorrectParts()
		{
			// Arrange

			// Act
			var result = ColumnDataExtractor.Parse("foobar.test1.field1");

			// Assert
			Assert.AreEqual(3, result.Length);
			Assert.AreEqual("foobar", result[0]);
			Assert.AreEqual("test1", result[1]);
			Assert.AreEqual("field1", result[2]);
		}

		[TestMethod]
		public void TestParse_WithColumnNameWithParenthesis_ReturnsEmptyArray()
		{
			// Arrange

			// Act
			var result = ColumnDataExtractor.Parse("foobar(test1)");

			// Assert
			Assert.AreEqual(0, result.Length);
		}
	}
}
