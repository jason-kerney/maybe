
/// <summary>
/// Maybe-aware sequence operations and helpers.
/// </summary>
module Utils.Maybe.MaybeSeq

/// <summary>
/// Reduces a sequence of maybe values, combining errors if present. Returns Ok () if no errors.
/// </summary>
let reduceErrors (items: _ maybe seq) =
    /// <summary>
    /// Helper to wrap a list of failures as a combination failure or Ok ().
    /// </summary>
    let maybeFailures (items: _ list) =
        if 0 < items.Length then items |> asCombinationFailure
        else Ok ()
        
    items
    |> Seq.toList
    |> List.filter Maybe.isError
    |> List.map (function Error e -> e | _ -> failwith "Unexpected Ok in error filter")
    |> maybeFailures