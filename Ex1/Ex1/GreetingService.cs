using System.Collections.Generic;
using System.Linq;

namespace Ex1
{
    public class GreetingService
    {
#nullable enable
        private string ParseName(string? name, out bool isShouting)
        {
            isShouting = (name?.All(ch => char.IsUpper(ch))) is not null and true;
            var replacement = (name is null) ? "my friend" : name;

            return replacement;
        }

        public string Greet(params string[] names)
        {
            var resultString = "Hello";
            var endOfString = " .";

            for(int index = 0; index < names.Length - 1; index++)
            {
                resultString += ", " + ParseName(names[index], out bool _);
            }

            var lastSeparator = (names.Length == 1) ? ", " : " and ";
            resultString += lastSeparator + ParseName(names[^1], out bool isShouting) + endOfString;

            if (isShouting) resultString = resultString.ToUpper();

            return resultString;
        }
#nullable disable
    }
}
