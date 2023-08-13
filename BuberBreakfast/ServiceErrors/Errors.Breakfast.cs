using ErrorOr;
using BuberBreakfast.Models;

namespace BuberBreakfast.ServiceErrors
{
    public static class Errors
    {
        public static class Breakfast
        {
            public static Error NotFound => Error.NotFound(
                code: "Breakfast.NotFound",
                description: "Breakfast not found."
            );

            public static Error InvalidName => Error.Validation(
                code: "Breakfast.InvalidName",
                description: $"Name must be between {Models.Breakfast.MinNameLength} and {Models.Breakfast.MaxNameLength} characters long."
            );

            public static Error InvalidDescription => Error.Validation(
                code: "Breakfast.InvalidDescription",
                description: $"Description must be between {Models.Breakfast.MinDescriptionLength} and {Models.Breakfast.MaxDescriptionLength} characters long."
            );

            public static Error InvalidId => Error.Validation(
                code: "Breakfast.InvalidId",
                description: "Invalid id. Breakfast Id must be a Guid"
            );
        }
    }
}