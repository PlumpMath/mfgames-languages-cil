// Copyright 2012-2013 Moonfire Games
// Released under the MIT license
// http://mfgames.com/author-intrusion/license

namespace MfGames.Languages
{
	public interface IWordTokenizer
	{
		#region Methods

		/// <summary>
		/// Gets the next word boundary from the given string and character index.
		/// </summary>
		/// <param name="text">The text.</param>
		/// <param name="characterIndex">Index of the character.</param>
		/// <returns>The character index of the next word or Int32.MaxValue if one
		/// cannot be found.</returns>
		int GetNextWordBoundary(
			string text,
			int characterIndex);

		/// <summary>
		/// Gets the previous word boundary from the given string and character index.
		/// </summary>
		/// <param name="text">The text.</param>
		/// <param name="characterIndex">Index of the character.</param>
		/// <returns></returns>
		int GetPreviousWordBoundary(
			string text,
			int characterIndex);

		/// <summary>
		/// Determines if the given character would be a continuation of an
		/// existing word.
		/// </summary>
		/// <param name="existingText">The text already established and the basis for the logic.</param>
		/// <param name="newCharacter">The new character being introduced.</param>
		/// <returns></returns>
		bool IsWordContinuation(
			string existingText,
			char newCharacter);

		#endregion
	}
}
