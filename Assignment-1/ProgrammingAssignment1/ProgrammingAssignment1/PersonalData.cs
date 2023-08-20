using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ProgrammingAssignment1
{
    /// <summary>
    /// A class holding personal data for a person
    /// </summary>
    public class PersonalData
    {
        #region Fields
        private String city;
        private String country;
        private String firstName;
        private String lastName;
        private String middleName;
        private String phoneNumber;
        private String postalCode;
        private String state;
        private String streetAddress;
        #endregion

        #region Properties
        public String City
        {
            get
            {   return this.city;   }
        }

        public String Country
        {
            get
            {   return this.country; }
        }

        public String FirstName
        {
            get { return this.firstName; }
        }

        public String LastName
        {
            get { return this.lastName; }
        }

        public String MiddleName
        {
            get { return this.middleName; }
        }

        public String PhoneNumber
        {
            get { return this.phoneNumber; }
        }

        public String PostalCode
        {
            get { return this.postalCode; }
        }

        public String State
        {
            get { return this.state; }
        }

        public String StreetAddress
        {
            get { return this.streetAddress; }
        }
        #endregion


        #region Constructor

        /// <summary>
        /// Constructor
        /// Reads personal data from a file. If the file
        /// read fails, the object contains an empty string for all
        /// the personal data
        /// </summary>
        /// <param name="fileName">name of file holding personal data</param>
        public PersonalData(string fileName)
        {
            // your code can assume we know the order in which the
            // values appear in the string; it's the same order as
            // they're listed for the properties above. We could do 
            // something more complicated with the names and values, 
            // but that's not necessary here

            // IMPORTANT: The mono compiler the automated grader uses
            // does NOT support the string Split method. You have to 
            // use the IndexOf method to find comma locations and the
            // Substring method to chop off the front of the string
            // after you extract each value to extract and save the
            // personal data
            // read and save configuration data from file
                StreamReader configFile = null;
                try
                {
                    configFile = File.OpenText(fileName);

                    string line = configFile.ReadLine();

                    String[] values = Split(line, ",");

                    this.firstName = values[0];
                    this.middleName = values[1];
                    this.lastName = values[2];
                    this.streetAddress = values[3];
                    this.city = values[4];
                    this.state = values[5];
                    this.postalCode = values[6];
                    this.country = values[7];
                    this.phoneNumber = values[8];

                }
                catch (Exception e)
                {
                   
                }
                finally
                {
                    if (configFile != null) configFile.Close();
                }
      
        }

        public  String[] Split(String input, String delimiter)
        {
            List<String> parts = new List<String>();
            StringBuilder buff = new StringBuilder();
            if (delimiter.Length == 0)
            {
                throw new InvalidOperationException("Invalid delimiter.");
            }
            else //you are splitting on a character
            {
                char delimChar = delimiter[0];
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == delimChar)
                    {
                        parts.Add(buff.ToString());
                        buff.Clear();
                    }
                    else
                    {
                        buff.Append(input[i]);
                    }
                }
                parts.Add(buff.ToString());
            }
            return parts.ToArray();
        }

        #endregion
    }
}
