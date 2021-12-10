namespace VeiculosAPI.Core.Passwords
{
    public sealed class HashingOptions
    {
        public const string Hashing = "Hashing";
        public int Iterations { get; set; } = 10000;
    }
}
