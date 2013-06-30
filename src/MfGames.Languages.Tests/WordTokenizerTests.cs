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

		[Test]
		public void NextOneWord()
		{
			// Setup
			var splitter = new WordTokenizer();
			const string text = "word";
			const int index = 1;

			// Test
			int boundary = splitter.GetNextWordBoundary(text, index);

			// Assertion
			Assert.AreEqual(4, boundary);
		}

		[Test]
		public void NextPuncutationWithSpace()
		{
			// Setup
			var splitter = new WordTokenizer();
			const string text = "One. Two.";
			const int index = 3;

			// Test
			int boundary = splitter.GetNextWordBoundary(text, index);

			// Assertion
			Assert.AreEqual("Two.", text.Substring(boundary));
			Assert.AreEqual(5, boundary);
		}

		[Test]
		public void NextPuncutationWithoutSpace()
		{
			// Setup
			var splitter = new WordTokenizer();
			const string text = "One.Two.";
			const int index = 3;

			// Test
			int boundary = splitter.GetNextWordBoundary(text, index);

			// Assertion
			Assert.AreEqual("Two.", text.Substring(boundary));
			Assert.AreEqual(4, boundary);
		}

		[Test]
		public void PreviousAtEndOfLine()
		{
			// Setup
			var splitter = new WordTokenizer();
			const string text = "One. Two.";
			const int index = 9;

			// Test
			int boundary = splitter.GetPreviousWordBoundary(text, index);

			// Assertion
			Assert.AreEqual(".", text.Substring(boundary));
			Assert.AreEqual(8, boundary);
		}

		[Test]
		public void PreviousOneWord()
		{
			// Setup
			var splitter = new WordTokenizer();
			const string text = "word";
			const int index = 1;

			// Test
			int boundary = splitter.GetPreviousWordBoundary(text, index);

			// Assertion
			Assert.AreEqual(0, boundary);
		}

		[Test]
		public void PreviousPuncutationWithSpace()
		{
			// Setup
			var splitter = new WordTokenizer();
			const string text = "One. Two.";
			const int index = 6;

			// Test
			int boundary = splitter.GetPreviousWordBoundary(text, index);

			// Assertion
			Assert.AreEqual("Two.", text.Substring(boundary));
			Assert.AreEqual(5, boundary);
		}

		[Test]
		public void PreviousPuncutationWithoutSpace()
		{
			// Setup
			var splitter = new WordTokenizer();
			const string text = "One.Two.";
			const int index = 5;

			// Test
			int boundary = splitter.GetPreviousWordBoundary(text, index);

			// Assertion
			Assert.AreEqual("Two.", text.Substring(boundary));
			Assert.AreEqual(4, boundary);
		}

		[Test]
		public void PreviousPuncutationWithoutSpaceInMiddleWithEndingSpace()
		{
			// Setup
			var splitter = new WordTokenizer();
			const string text = "One.Two ";
			const int index = 8;

			// Test
			int boundary = splitter.GetPreviousWordBoundary(text, index);

			// Assertion
			Assert.AreEqual("Two ", text.Substring(boundary));
			Assert.AreEqual(4, boundary);
		}

		#endregion
	}
}
