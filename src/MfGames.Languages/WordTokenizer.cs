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
	public class WordTokenizer
	{
		#region Methods

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
