using System.Collections.Generic;
using System.Linq;

namespace Ex1
{
    public class GreetingService
    {
#nullable enable
        private bool IsUpper(string? name)
        {
            return (name?.All(ch => char.IsUpper(ch))) is not null and true;
        }
        private string ParseName(string? name)
        {
            var replacement = (name is null) ? "my friend" : name;
            return replacement;
        }

        private string FormatNames(List<string> names)
        {
            string resultString = "";
            for (int index = 0; index < names.Count - 1; index++)
            {

                resultString += ", " + ParseName(names[index]);
            }

            var lastSeparator = (names.Count == 1) ? ", " : " and ";
            resultString += lastSeparator + ParseName(names[^1]);
            return resultString;
        }

        private void SortNames(string[] allNames, out List<string> lowCaseNames, out List<string> upperCaseNames)
        {
            lowCaseNames = new();
            upperCaseNames = new();

            foreach (var nameString in allNames)
            {
                string[] namesInString = ExtraxtNamesFromString(nameString);

                foreach (var name in namesInString)
                {
                    if (IsUpper(name))
                        upperCaseNames.Add(name);
                    else
                        lowCaseNames.Add(name);
                }
            }
        }

        private static string[] ExtraxtNamesFromString(string? nameString)
        {
            string[] namesInString = new string[1] { nameString };
            if( nameString is null)
            {
                return namesInString;
            }

            if (namesInString[0].StartsWith('\"') && namesInString[0].EndsWith('\"'))
            {
                namesInString[0] = nameString.Substring(1, nameString.Length - 2);
                return namesInString;
            }

            if (namesInString[0].Contains(','))
            {
                namesInString = nameString.Split(',', System.StringSplitOptions.RemoveEmptyEntries);
            }

            return namesInString;
        }

        public string Greet(params string[] names)
        {

            SortNames(names, out List<string> lowCaseNames, out List<string> upperCaseNames);

            var lowCaseString = (lowCaseNames.Count > 0) ? "Hello" + FormatNames(lowCaseNames) + " ." : "";
            var upperCaseString = (upperCaseNames.Count > 0) ? "HELLO" + FormatNames(upperCaseNames).ToUpper() + " !" : "";
            var separator = (lowCaseNames.Count > 0 && upperCaseNames.Count > 0) ? "AND " : "";
            return lowCaseString + separator + upperCaseString;
        }
#nullable disable
    }
}
