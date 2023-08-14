namespace SprmCommon.Validations
{
    public class DataValidator
    {
        public Func<string, bool> Validate { get; set; } = null!;

        public string Message { get; set; } = string.Empty;
    }
}
