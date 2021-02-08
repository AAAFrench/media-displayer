using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Name: Aaron Audet
 * Student Number: 000367464
 * File Date: October 23, 2020
 * Program purpose: The purpose of this program is to store the song information
 * Statement of Authorship: I, Aaron Audet, 000367464 certify that this material is my original work.  No other person's work has been used without due acknowledgement.
 */

namespace Lab3A
{
    /// <summary>
    /// Stores song information
    /// </summary>
    class Song : Media
    {
        public string Album { get; private set; }
        public string Artist { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title">Title of the song</param>
        /// <param name="year">Year it was released</param>
        /// <param name="album">Album name</param>
        /// <param name="artist">Name of Artist</param>
        public Song(string title, int year, string album, string artist) : base(title, year)
        {
            Album = album;
            Artist = artist;
        }

        /// <summary>
        /// Formats string to neatly display the song information
        /// </summary>
        /// <returns>Formated string</returns>
        public override string ToString() => $"Song Title: {Title} ({Year})\nAlbum: {Album}  Artist: {Artist}";
    }
}
