// Copyright 2012-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/author-intrusion/license

using System;
using NUnit.Framework;

namespace MfGames.Languages.Tests
{
	[TestFixture]
	public class WordTokenizerTests
	{
		#region Methods

		[Test]
		public void IsWordContinuationWithBlankAndLetter()
		{
			// Arrange
			var tokenizer = new WordTokenizer();

			// Act
			bool results = tokenizer.IsWordContinuation("", 'a');

			// Assert
			Assert.IsFalse(results);
		}

		[Test]
		public void IsWordContinuationWithBlankAndPeriod()
		{
			// Arrange
			var tokenizer = new WordTokenizer();

			// Act
			bool results = tokenizer.IsWordContinuation("", '.');

			// Assert
			Assert.IsFalse(results);
		}

		[Test]
		public void IsWordContinuationWithNulls()
		{
			// Arrange
			var tokenizer = new WordTokenizer();

			// Act
			Assert.Throws<ArgumentNullException>(
				() => tokenizer.IsWordContinuation(null, 'a'));
		}

		[Test]
		public void IsWordContinuationWithPeriodAndLetter()
		{
			// Arrange
			var tokenizer = new WordTokenizer();

			// Act
			bool results = tokenizer.IsWordContinuation(".", 'a');

			// Assert
			Assert.IsFalse(results);
		}

		[Test]
		public void IsWordContinuationWithPeriodAndPeriod()
		{
			// Arrange
			var tokenizer = new WordTokenizer();

			// Act
			bool results = tokenizer.IsWordContinuation(".", '.');

			// Assert
			Assert.IsFalse(results);
		}

		[Test]
		public void IsWordContinuationWithSpaceAndLetter()
		{
			// Arrange
			var tokenizer = new WordTokenizer();

			// Act
			bool results = tokenizer.IsWordContinuation(" ", 'a');

			// Assert
			Assert.IsFalse(results);
		}

		[Test]
		public void IsWordContinuationWithSpaceAndPeriod()
		{
			// Arrange
			var tokenizer = new WordTokenizer();

			// Act
			bool results = tokenizer.IsWordContinuation(" ", '.');

			// Assert
			Assert.IsFalse(results);
		}

		[Test]
		public void IsWordContinuationWithTextAndLetter()
		{
			// Arrange
			var tokenizer = new WordTokenizer();

			// Act
			bool results = tokenizer.IsWordContinuation("a", 'a');

			// Assert
			Assert.IsTrue(results);
		}

		[Test]
		public void IsWordContinuationWithTextAndPeriod()
		{
			// Arrange
			var tokenizer = new WordTokenizer();

			// Act
			bool results = tokenizer.IsWordContinuation("a", '.');

			// Assert
			Assert.IsFalse(results);
		}

		#endregion
	}
}
