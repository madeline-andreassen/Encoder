using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ag_Leader_Technology_Technical_Question.Models
{
    public class Index
    {
        /// <summary>
        /// Text displayed at the top of the page.
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Text retrieved from the form.
        /// </summary>
        public string InputText { get; set; }
        /// <summary>
        /// Model that holds values regarding decoding.
        /// </summary>
        public DecodingTable DecodingTable { get; set; }
        /// <summary>
        /// Cyrillic text that is generated after form submission.
        /// </summary>
        public string EncodedText { get; set; }
    }
    /// <summary>
    /// Model that holds the decoding information
    /// </summary>
    public class DecodingTable
    {
        /// <summary>
        /// List of alphanumeric characters. This is used for displaying the table.
        /// </summary>
        public List<char> AlphaNumeric { get; set; }
        /// <summary>
        /// List of cyrillic characters. This is used for displaying the table.
        /// </summary>
        public List<char> Cyrillic { get; set; }
        /// <summary>
        /// The decoding table. This is used for quickly accessing the cyrillic value
        /// of a given alphanumeric character.
        /// </summary>
        public Dictionary<char, char> Decoder { get; set; }

    }
}