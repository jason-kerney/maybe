
/// <summary>
/// Core Maybe utilities for working with the 'maybe' type.
/// </summary>
module Utils.Maybe.Maybe

/// <summary>
/// Wraps a value in a <c>maybe</c> (Ok) type.
/// </summary>
let wrap : _ -> _ maybe = Ok
    
/// <summary>
/// Returns the first successful (Ok) value from two <c>maybe</c> values, or the second if both are errors.
/// </summary>
let orMaybe (a: _ maybe) (b: _ maybe) : _ maybe =
    match b, a with
    | Ok v, _
    | _, Ok v -> Ok v
    | _ -> b
    
/// <summary>
/// Returns <paramref name="a"/> if it is Ok, otherwise <paramref name="b"/>.
/// </summary>
let isPreferredOver (a: _ maybe) (b: _ maybe) : _ maybe =
    b |> orMaybe a
    
/// <summary>
/// Returns <paramref name="b"/> if it is Ok, otherwise <paramref name="a"/>.
/// </summary>
let butPrefer (a: _ maybe) (b: _ maybe) : _ maybe =
    a |> orMaybe b

/// <summary>
/// Flattens a nested <c>maybe</c> value (i.e., <c>maybe maybe</c>) into a single <c>maybe</c>.
/// </summary>
let simplify (value: _ maybe maybe) =
    maybe {
        let! value = value
        return! value
    }

/// <summary>
/// Converts a <c>bool maybe</c> to a <c>bool</c>, returning false if Error.
/// </summary>
let toBool (value: bool maybe) =
    match value with
    | Ok v -> v
    | Error _ -> false
    
/// <summary>
/// Returns true if the <c>maybe</c> value is Ok.
/// </summary>
let hasValue (possible: _ maybe) =
    match possible with
    | Ok _ -> true
    | _ -> false
    
/// <summary>
/// Returns true if the <c>maybe</c> value is Error.
/// </summary>
let isError (value: _ maybe) =
    match value with
    | Ok _ -> false
    | _ -> true
    
/// <summary>
/// Returns the value if Ok, otherwise returns the provided default value.
/// </summary>
let orDefault defaultValue (value: _ maybe) =
    match value with
    | Ok v -> v
    | _ -> defaultValue
    
/// <summary>
/// Lifts a function to operate on a <c>maybe</c> value.
/// </summary>
let lift f : _ maybe -> _ maybe = Result.map f

/// <summary>
/// Lifts a function returning <c>maybe</c> to operate on a <c>maybe</c> value (monadic bind).
/// </summary>
let mlift (f: _ -> _ maybe) : _ maybe -> _ maybe = Result.bind f

/// <summary>
/// Applies a lifted function to a <c>maybe</c> value.
/// </summary>
let llift value f = (lift f) value

/// <summary>
/// Applies a monadic lifted function to a <c>maybe</c> value.
/// </summary>
let mllift value f = (mlift f) value

/// <summary>
/// Partially lifts a function returning <c>maybe</c> to operate on a <c>maybe</c> value.
/// </summary>
let partialLift (f: _ -> _ maybe) : _ maybe -> _ maybe = Result.bind f

/// <summary>
/// Maps a function over a <c>maybe</c> value using computation expressions.
/// </summary>
let map f (item: _ maybe) =
    maybe {
        let! item = item
        
        return
            f item
    }
    
/// <summary>
/// Checks a predicate on a <c>maybe</c> value, returning a bool.
/// </summary>
let check f item =
    item
    |> map f
    |> toBool
    
/// <summary>
/// Converts an option to a <c>maybe</c>, using the provided error message if None.
/// </summary>
let fromOption errorMsg : _ option -> _ maybe = function
    | Some v -> Ok v
    | _ -> errorMsg |> asGeneralFailure
    
/// <summary>
/// Converts a <c>maybe</c> value to a string representation.
/// </summary>
let callToString : _ maybe -> string = function
    | Ok v -> v.ToString ()
    | Error e -> e |> Error |> sprintf "%A"