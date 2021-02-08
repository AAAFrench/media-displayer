using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Name: Aaron Audet
 * Student Number: 000367464
 * File Date: October 23, 2020
 * Program purpose: The purpose of this program is to store the book information
 * Statement of Authorship: I, Aaron Audet, 000367464 certify that this material is my original work.  No other person's work has been used without due acknowledgement.
 */

namespace Lab3A
{
	/// <summary>
	/// Stores book information
	/// </summary>
	public class Book : Media, IEncryptable
    {
        public string Author { get; private set; }
        public string Summary { get; private set; }

        /// <summary>
		/// Stores book information
		/// </summary>
		/// <param name="title">Title of book</param>
		/// <param name="year">Year it was released</param>
		/// <param name="author">Name of Author</param>
		/// <param name="summary">Summary of book</param>
		public Book(string title, int year, string author, string summary) : base(title, year)
        {
            Author = author;
            Summary = summary;
        }

		/// <summary>
		/// Formats string to neatly display the song information
		/// </summary>
		/// <returns>Formated string</returns>
		public override string ToString() => $"Book Title: {Title} ({Year})\nAuthor: {Author}";

        /// <summary>
		/// Encrypts summary
		/// </summary>
		/// <returns>Rot13 encrypted string</returns>
		public string Encrypt()
        {
			char[] array = Summary.ToCharArray();
			for (int i = 0; i < array.Length; i++)
			{
				int number = (int)array[i];

				if (number >= 'a' && number <= 'z')
				{
					if (number > 'm')
					{
						number -= 13;
					}
					else
					{
						number += 13;
					}
				}
				else if (number >= 'A' && number <= 'Z')
				{
					if (number > 'M')
					{
						number -= 13;
					}
					else
					{
						number += 13;
					}
				}
				array[i] = (char)number;
			}
			return new string(array);
		}

		/// <summary>
		/// Decrypts summary
		/// </summary>
		/// <returns>Decrypted string</returns>
		public string Decrypt()
        {
			char[] array = Summary.ToCharArray();
			for (int i = 0; i < array.Length; i++)
			{
				int number = (int)array[i];

				if (number >= 'a' && number <= 'z')
				{
					if (number > 'm')
					{
						number -= 13;
					}
					else
					{
						number += 13;
					}
				}
				else if (number >= 'A' && number <= 'Z')
				{
					if (number > 'M')
					{
						number -= 13;
					}
					else
					{
						number += 13;
					}
				}
				array[i] = (char)number;
			}
			return new string(array);
		}
    }
}
