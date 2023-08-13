namespace BuberBreakfast.Services.Breakfasts;

public record struct UpsertedBreakfast(bool IsNewlyCreated);
// {
//     public static implicit operator bool(UpsertedBreakfast upsertedBreakfast) => upsertedBreakfast.IsNewlyCreated;

//     public static implicit operator UpsertedBreakfast(bool isNewlyCreated) => new(isNewlyCreated);
// }

/*
    In C#, the struct keyword is used to define a value type. Value types are stored directly in memory where they are declared, rather than on the heap as objects are. This can lead to better performance in some scenarios, especially when dealing with small data structures.
*/
