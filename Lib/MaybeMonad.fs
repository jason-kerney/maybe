
/// <summary>
/// Monad and computation expression support for maybe types.
/// </summary>
[<AutoOpen>]
module Utils.Maybe.MaybeMonad

/// <summary>
/// Wraps a value in a <c>maybe</c> (Ok) type.
/// </summary>
let asMaybe value: _ maybe = value |> Ok

/// <summary>
/// Delays the execution of a function returning a <c>maybe</c> value.
/// </summary>
let private delayMaybe f: _ maybe = f ()

/// <summary>
/// Binds a function to a <c>maybe</c> value, propagating errors and exceptions.
/// </summary>
let bindWith rest (maybe: _ maybe): _ maybe =
    try
        match maybe with
        | Ok value -> value |> rest
        | Error e -> Error e
    with
    | e -> e |> ExceptionFailure |> Error

/// <summary>
/// Combines two <c>maybe</c> values, returning the second if the first is Ok, otherwise propagating the error.
/// </summary>
let combineMaybeWith maybe2 (maybe1: _ maybe): _ maybe =
    try
        match maybe1 with
        | Ok _ -> maybe2
        | Error e -> Error e
    with
    | e -> e |> ExceptionFailure |> Error

/// <summary>
/// A <c>maybe</c> value representing a successful unit result.
/// </summary>
let ready: _ maybe = () |> Ok
    
/// <summary>
/// Computation expression builder for the maybe monad.
/// </summary>
type MaybeBuilder () =
    /// <summary>Wraps a value in a <c>maybe</c> (Ok) type.</summary>
    member __.Return value: _ maybe = value |> asMaybe
    /// <summary>Returns an existing <c>maybe</c> value.</summary>
    member __.ReturnFrom maybe: _ maybe = maybe
    /// <summary>Delays the execution of a function returning a <c>maybe</c> value.</summary>
    member __.Delay f = f |> delayMaybe
    /// <summary>Binds a function to a <c>maybe</c> value, propagating errors and exceptions.</summary>
    member __.Bind (maybe, rest) = maybe |> bindWith rest
    /// <summary>Combines two <c>maybe</c> values, returning the second if the first is Ok, otherwise propagating the error.</summary>
    member __.Combine (maybe1, maybe2) = maybe1 |> combineMaybeWith maybe2
    /// <summary>Returns a successful unit <c>maybe</c> value.</summary>
    member __.Zero () = ready

/// <summary>
/// The computation expression instance for the maybe monad.
/// </summary>
let maybe = MaybeBuilder ()