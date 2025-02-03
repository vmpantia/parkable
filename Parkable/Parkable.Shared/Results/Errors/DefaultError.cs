using Parkable.Shared.Enums;

namespace Parkable.Shared.Results.Errors
{
    public class DefaultError
    {
        public static Error Unexpected(Exception ex) => new(ErrorType.Exception, $"Unexpected error occurred while processing the request, {ex.Message}", ex.ToString());
        public static Error Validation(IDictionary<string, string[]> errors) => new(ErrorType.Validation, "Data validations got an error(s) during processing of request.", errors);
    }
}
