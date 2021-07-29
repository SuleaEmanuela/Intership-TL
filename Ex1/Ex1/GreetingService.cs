namespace Ex1
{
    public class GreetingService
    {
#nullable enable
        public string Greet(string? name)
        {
            var replacement = (name is null) ? "my friend" : name;
            return $"Hello, {replacement} .";
        }
#nullable disable
    }
}
