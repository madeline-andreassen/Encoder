using Ag_Leader_Technology_Technical_Question.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ag_Leader_Technology_Technical_Question.Controllers
{
    /// <summary>
    /// Controls the views in the Views/Home directory
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Initial method for the index webpage.
        /// This generates the form for submitting at sequence of characters.
        /// </summary>
        /// <returns>View(Index Model)</returns>
        public ActionResult Index()
        {
            Index model = new Index();
            model.Text = "Please enter your sequence of alphanumeric characters.";

            return View(model);
        }

        /// <summary>
        /// This method is called after form submission. 
        /// This creates the model for the view and generates the encoded values.
        /// </summary>
        /// <param name="index">Contains the form data from submission</param>
        /// <returns>View for the results page</returns>
        [HttpPost]
        public ActionResult Index(Index index)
        {
            //Initializes the new model
            Index model = new Index();
            model.Text = "Here's your results!";
            model.DecodingTable = GenerateDecodingTable();
            model.EncodedText = "";
            for (int i = 0; i < index.InputText.Length; i++)
            {
                try
                {
                    char value = ' ';
                    //Checks for null values
                    if (index.InputText.ElementAt(i) != '\0' && model.DecodingTable.Decoder.TryGetValue(index.InputText.ElementAt(i), out value))
                    {
                        model.EncodedText += value;
                    }
                    else
                    {
                        model.EncodedText = "Ooops! Something went wrong!";
                        break;
                    }
                }
                catch (KeyNotFoundException e)
                {

                }
            }
            return View(model);
        }
        /// <summary>
        /// This method randomly assigns cyrillic characters to alphanumeric characters.
        /// </summary>
        /// <returns>DecodingTable with generated values</returns>
        public DecodingTable GenerateDecodingTable()
        {
            //Initializes the DecodingTable model
            DecodingTable decodingTable = new DecodingTable();
            decodingTable.Cyrillic = new List<char>();
            decodingTable.AlphaNumeric = new List<char>();
            decodingTable.Decoder = new Dictionary<char, char>();


            List<int> cyrillicNums = new List<int>();
            //Random makes the code more difficult to crack
            Random rand = new Random();

            //Cyrillic characters are from 0456 - 0646
            //Generates a list of all possible cyrillic characters
            for (int i = 456; i <= 646; i++)
            {
                cyrillicNums.Add(i);
            }

            //Latin characters are from 0032 - 0126
            //Assigns each alphanumeric character to a cyrillic character
            for (int i = 32; i <= 126; i++)
            {
                int randIndex = rand.Next(cyrillicNums.Count);

                //Convert the ints to a chars
                char cyr = (char) cyrillicNums.ElementAt(randIndex);
                char alpha = (char) i;

                //Add data to the DecodingTable model
                decodingTable.Cyrillic.Add(cyr);
                decodingTable.AlphaNumeric.Add(alpha);
                decodingTable.Decoder.Add(alpha, cyr);

                //Remove the cyrillic character after it has already been used
                cyrillicNums.RemoveAt(randIndex);
            }
            return decodingTable;
        }
    }
}