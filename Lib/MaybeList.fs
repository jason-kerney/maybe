
/// <summary>
/// Maybe-aware list operations and helpers.
/// </summary>
module Utils.Maybe.MaybeList

/// <summary>
/// Reduces a list of maybe values, combining errors if present.
/// </summary>
let reduceErrors = MaybeSeq.reduceErrors

/// <summary>
/// Concatenates a maybe-wrapped list of lists into a single maybe-wrapped list.
/// </summary>
let concat (items : _ list mlist) : _ mlist=
    maybe {
        let! items = items
        
        return items |> List.concat
    }
    
/// <summary>
/// Determines if any element of a maybe-wrapped list satisfies the predicate.
/// </summary>
let exists predicate (items: _ mlist) =
    maybe {
        let! items = items
        return
            items
            |> List.exists predicate
    } |> Maybe.toBool
    
/// <summary>
/// Finds the first element in a maybe-wrapped list that satisfies the predicate.
/// </summary>
let find predicate : _ mlist -> _ maybe =
    predicate
    |> List.find
    |> Maybe.lift

/// <summary>
/// Filters a maybe-wrapped list by a predicate.
/// </summary>
let filter predicate : _ mlist -> _ mlist =
    predicate
    |> List.filter
    |> Maybe.lift
    
/// <summary>
/// Sorts a maybe-wrapped list.
/// </summary>
let sort (list: _ mlist) : _ mlist =
    list |> Maybe.lift List.sort
    
/// <summary>
/// Sorts a maybe-wrapped list by a key function.
/// </summary>
let sortBy f (list: _ mlist) : _ mlist =
    f
    |> Ok
    |> Maybe.lift List.sortBy
        <-/ list

/// <summary>
/// Flattens a list of maybe values into a maybe-wrapped list, combining errors if present.
/// </summary>
let flatten (items: _ maybe list) : _ mlist =
    maybe {
        let errors =
            items
            |> List.filter (fun item -> match item with Error _ -> true | _ -> false)
            |> List.map (fun (Error item) -> item)
        
        if 0 < errors.Length
        then return! errors |> asCombinationFailure
        else
            return
                items
                |> List.map (fun (Ok item) -> item)
    }
    
/// <summary>
/// Maps a function over a maybe-wrapped list.
/// </summary>
let map f : _ mlist -> _ mlist = f |> List.map |> Maybe.lift

/// <summary>
/// Maps a function returning maybe over a maybe-wrapped list, then flattens the result.
/// </summary>
let mapM f items : _ mlist =
    maybe {
        let! items =
            items |> map (fun a -> a |> asMaybe |> f)
        
        return! items |> flatten
    }
    
/// <summary>
/// Prepends an item to a maybe-wrapped list.
/// </summary>
let cons (items: _ mlist) item : _ mlist =
    maybe {
        let! items = items
        return item::items
    }

/// <summary>
/// Prepends a maybe-wrapped item to a maybe-wrapped list.
/// </summary>
let consM items item : _ mlist =
    maybe {
        let! item = item
        return! item |> cons items
    }

/// <summary>
/// Returns the head of a maybe-wrapped list.
/// </summary>
let head (list: _ mlist) = (List.head |> Maybe.lift) list

/// <summary>
/// Returns the tail of a maybe-wrapped list.
/// </summary>
let tail (list: _ mlist) = (List.tail |> Maybe.lift) list

/// <summary>
/// Converts a maybe-wrapped item to a maybe-wrapped single-item list.
/// </summary>
let toListM item : _ mlist =
    maybe {
        let! item = item
        return item::[]
    }
    
/// <summary>
/// Iterates over a maybe-wrapped list, applying a function to each element.
/// </summary>
let iter f (items: _ mlist) =
    maybe {
        let! items = items
        
        return
            items
            |> List.iter f
    }

/// <summary>
/// Iterates over a maybe-wrapped list, applying a function returning maybe to each element.
/// </summary>
let iterM (f: _ maybe -> unit maybe) (items: _ mlist) : unit maybe =
    let result = items |> mapM f
    
    match result with
    | Ok _ -> Ok ()
    | Error e -> Error e

/// <summary>
/// Iterates over a maybe-wrapped list, applying a function returning maybe to each element and reducing errors.
/// </summary>
let iter_M (f: _ -> unit maybe) (items: _ mlist) : unit maybe =
    maybe {
        let! items = items
        
        return!
            items
            |> List.map f
            |> reduceErrors
    }
    
/// <summary>
/// Appends two maybe-wrapped lists.
/// </summary>
let append (itemsA: _ mlist) (itemsB: _ mlist) : _ mlist =
    maybe {
        let! itemsA = itemsA
        let! itemsB = itemsB
        
        return
            itemsB
            |> List.append itemsA
    }

/// <summary>
/// Returns the elements of the second maybe-wrapped list that are not in the first.
/// </summary>
let except (itemsA: _ mlist) (itemsB: _ mlist) : _ mlist =
    maybe {
        let! itemsA = itemsA
        let! itemsB = itemsB
        
        let result =
            itemsB
            |> List.except itemsA
        
        return result
    }
    
/// <summary>
/// Determines if a maybe-wrapped list contains a given item.
/// </summary>
let contains item (items: _ mlist) =
    maybe {
        let! items = items
        return
            items
            |> List.contains item
    } |> Maybe.toBool
    
/// <summary>
/// Simplifies a maybe-wrapped list of maybe values into a maybe-wrapped list, combining errors if present.
/// </summary>
let simplify (items: _ maybe mlist) : _ mlist =
    maybe {
        let! items = items
        return! items |> flatten
    }
    
/// <summary>
/// Reduces a maybe-wrapped list using the provided function.
/// </summary>
let reduce f (items: _ mlist): _ maybe =
    maybe {
        let! items = items
        
        return items |> List.reduce f
    }