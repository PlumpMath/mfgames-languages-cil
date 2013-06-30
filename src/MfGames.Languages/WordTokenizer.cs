// Copyright 2012-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/author-intrusion/license

using System;

namespace MfGames.Languages
{
	/// <summary>
	/// Encapsulates logic for breaking apart a string into simplistic,
	/// language-aware token, and identifing the end of one word and the beginning of
	/// another. This is intended for quick process instead of accurate.
	/// </summary>
	public class WordTokenizer: IWordTokenizer
	{
		#region Methods

		/// <summary>
		/// Gets the next word boundary from the given string and character index.
		/// </summary>
		/// <param name="text">The text.</param>
		/// <param name="characterIndex">Index of the character.</param>
		/// <returns></returns>
		public int GetNextWordBoundary(
			string text,
			int characterIndex)
		{
			// If we are at the end of the string, there is no boundary.
			if (characterIndex >= text.Length)
			{
				return Int32.MaxValue;
			}

			// Check the starting character. If it is puncutation, then our
			// next word is the next character.
			char startingChar = text[characterIndex];
			bool returnAfterWhitespace = char.IsPunctuation(startingChar)
				|| char.IsWhiteSpace(startingChar);

			// Go through the character string until we find a boundary.
			for (int index = characterIndex + 1;
				index < text.Length;
				index++)
			{
				// If we go to punctuation, then we are done looking.
				if (char.IsPunctuation(text[index]))
				{
					return index;
				}

				if (char.IsWhiteSpace(text[index]))
				{
					returnAfterWhitespace = true;
				}
				else
				{
					// If we are here, we have a non-whitespace or punctuation
					// character.
					if (returnAfterWhitespace)
					{
						return index;
					}
				}
			}

			// If we finished the loop, we couldn't find it so return the end
			// of the string.
			return text.Length;
		}

		/// <summary>
		/// Gets the previous word boundary from the given string and character index.
		/// </summary>
		/// <param name="text">The text.</param>
		/// <param name="characterIndex">Index of the character.</param>
		/// <returns></returns>
		public int GetPreviousWordBoundary(
			string text,
			int characterIndex)
		{
			// If we are at the beginning, there is no boundary.
			if (characterIndex == 0
				|| characterIndex - 1 >= text.Length)
			{
				return -1;
			}

			// Get the starting character's state, which uses slightly different
			// rules.
			char startingChar = text[characterIndex - 1];
			bool hasCharacter = !char.IsWhiteSpace(startingChar);
			bool initialWhitespace = !hasCharacter;

			if (char.IsPunctuation(startingChar))
			{
				return characterIndex - 1;
			}

			// Loop through the the remaining characters.
			for (int index = characterIndex - 1;
				index >= 0;
				index--)
			{
				if (char.IsPunctuation(text[index]))
				{
					return initialWhitespace && !hasCharacter
						? index
						: index + 1;
				}

				if (char.IsWhiteSpace(text[index]))
				{
					if (hasCharacter)
					{
						return index + 1;
					}
				}
				else
				{
					hasCharacter = true;
				}
			}

			// If we finished the loop, we couldn't find it so return the
			// beginning of the string.
			return 0;
		}

		/// <summary>
		/// Determines if the given character would be a continuation of an
		/// existing word.
		/// </summary>
		/// <param name="existingText">The text already established and the basis for the logic.</param>
		/// <param name="newCharacter">The new character being introduced.</param>
		/// <returns></returns>
		public bool IsWordContinuation(
			string existingText,
			char newCharacter)
		{
			// Make sure we have a sane state.
			if (existingText == null)
			{
				throw new ArgumentNullException("existingText");
			}

			// If the character is not a letter, then we will never be a continuation.
			if (!char.IsLetter(newCharacter))
			{
				return false;
			}

			// We are adding a character, so we are only true if the last
			// character in the previous string is a letter.
			if (existingText.Length == 0)
			{
				// Blank strings will never have a final character.
				return false;
			}

			char lastLetter = existingText[existingText.Length - 1];
			bool isLetter = char.IsLetter(lastLetter);
			return isLetter;
		}

		#endregion
	}
}
