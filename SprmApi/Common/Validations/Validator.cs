namespace SprmApi.Common.Validations
{
    internal class Validator
    {
        public Func<string, bool> Validate { get; set; } = null!;

        public string Message { get; set; } = string.Empty;
    }
}
