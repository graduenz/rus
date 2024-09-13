namespace Rus.Base.Api;

public class ValidationErrorsResult : ErrorResult
{
    public Dictionary<string, List<string>>? Errors { get; set; }
}