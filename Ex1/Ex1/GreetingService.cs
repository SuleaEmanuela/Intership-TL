using System.Linq;

namespace Ex1
{
    public class GreetingService
    {
#nullable enable
        public string Greet(string? name)
        {

            bool isShouting = (name?.All(ch => char.IsUpper(ch))) is not null and true;
            var replacement = (name is null) ? "my friend" : name;
            var greetString = $"Hello, {replacement} .";
            if (isShouting)
            {
                greetString = greetString.ToUpper();
            }
            return greetString;
        }
#nullable disable
    }
}
