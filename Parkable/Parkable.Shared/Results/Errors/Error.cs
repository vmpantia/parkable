using Parkable.Shared.Enums;

namespace Parkable.Shared.Results.Errors
{
    public record Error(ErrorType Type, string Message, object? Value = null) { }
}
