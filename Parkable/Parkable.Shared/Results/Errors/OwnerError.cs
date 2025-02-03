using Parkable.Shared.Enums;

namespace Parkable.Shared.Results.Errors
{
    public class OwnerError
    {
        public static Error NotFound(Guid id) => new(ErrorType.NotFound, $"Owner with an Id {id} is not found in the database.");
    }
}
