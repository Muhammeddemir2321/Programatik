namespace Core.CrossCuttingConcerns.Exceptions;
public class BusinessException : Exception
{
    public string? TranslateKey { get; set; }
    public IDictionary<string, string> Params { get; private set; } = new Dictionary<string, string>();

    public BusinessException(string message, string? translateKey = null) : base(message)
    {
        TranslateKey = translateKey;
    }

    public BusinessException(string message, Exception innerException, string? translateKey = null)
        : base(message, innerException)
    {
        TranslateKey = translateKey;
    }
    public BusinessException WithParam(string key, string value)
    {
        Params[key] = value;
        return this;
    }
}