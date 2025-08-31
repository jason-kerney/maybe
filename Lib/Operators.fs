
/// <summary>
/// Common operators and combinators for working with maybe types.
/// </summary>
[<AutoOpen>]
module Utils.Maybe.Operators

/// <summary>
/// Returns <paramref name="value"/> if <paramref name="check"/> is Ok (), otherwise returns the error from <paramref name="check"/>.
/// </summary>
let andM (value: _ maybe) (check: unit maybe) =
    match check with
    | Ok () -> value
    | Error e -> Error e
    
/// <summary>
/// Infix operator for <see cref="andM"/>.
/// </summary>
let inline (&!) a b = a |> andM b
/// <summary>
/// Applies a maybe-wrapped function to a maybe-wrapped value (forward pipe).
/// </summary>
let (/->) a f = a |> apply f
/// <summary>
/// Applies a maybe-wrapped function to a maybe-wrapped value (backward pipe).
/// </summary>
let (<-/) f a = a /-> f

/// <summary>
/// Applies a maybe-wrapped function to a maybe value, propagating errors.
/// </summary>
let (|->) a (f: Maybe<_ maybe -> _ maybe>) =
    match f with
    | Ok fn -> fn a
    | Error e -> Error e
    
/// <summary>
/// Reverse application of <see cref="|->"/>.
/// </summary>
let (<-|) f a = a |-> f