namespace Utils.Maybe

/// <summary>
/// Represents the possible failure cases for a process.
/// </summary>
type ProcessFailure =
    /// <summary>Failure due to an exception.</summary>
    | ExceptionFailure of exn
    /// <summary>Failure with a general error message.</summary>
    | GeneralFailure of string
    /// <summary>Failure due to a combination of multiple failures.</summary>
    | CombinationError of ProcessFailure list

/// <summary>
/// Alias for a result type with <typeparamref name='Value'/> or <see cref='ProcessFailure'/>.
/// </summary>
type maybe<'Value> = Result<'Value, ProcessFailure>

/// <summary>
/// Synonym for <c>maybe&lt;'Value&gt;</c> for convenience.
/// </summary>
type Maybe<'Value> = maybe<'Value>

/// <summary>
/// A maybe-wrapped list of values.
/// </summary>
type mlist<'Value> = maybe<'Value list>

/// <summary>
/// A maybe-wrapped sequence of values.
/// </summary>
type mseq<'Value> = maybe<'Value seq>

[<AutoOpen>]
module BaseHelpers =
    /// <summary>
    /// Wraps a string as a <see cref='GeneralFailure'/> in a <c>maybe</c> error.
    /// </summary>
    let asGeneralFailure failure: _ maybe = failure |> GeneralFailure |> Error

    /// <summary>
    /// Wraps an exception as an <see cref='ExceptionFailure'/> in a <c>maybe</c> error.
    /// </summary>
    let asExceptionFailure failure: _ maybe = failure |> ExceptionFailure |> Error

    /// <summary>
    /// Wraps a list of failures as a <see cref='CombinationError'/> in a <c>maybe</c> error.
    /// </summary>
    let asCombinationFailure failures: _ maybe =
        failures |> CombinationError |> Error

    /// <summary>
    /// Combines two <see cref='ProcessFailure'/> values into a single <see cref='CombinationError'/>.
    /// </summary>
    let combineWith failure1 failure2 =
        match failure1, failure2 with
        | CombinationError f1, CombinationError f2 ->
            [f1; f2] 
            |> List.concat 
            |> asCombinationFailure
        | CombinationError failures, failure
        | failure, CombinationError failures ->
            failure::failures |> asCombinationFailure
        | f1, f2 ->
            [f1; f2] |> asCombinationFailure

    /// <summary>
    /// Synonym for <c>combineWith</c>.
    /// </summary>
    let asFailureCombinedWith = combineWith
            
    /// <summary>
    /// Applies a maybe-wrapped function to a maybe-wrapped value.
    /// </summary>
    let apply (maybeF: _ maybe) (maybeX: _ maybe) : _ maybe = 
        match maybeF,maybeX with
        | Ok f, Ok x -> Ok (f x)
        | Error failure, Ok _ -> Error failure
        | Ok _, Error failure -> Error failure
        | Error failure1, Error failure2 ->
            failure1
            |> combineWith failure2