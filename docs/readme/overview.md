<!-- (dl
(section-meta
    (title RJK.Maybe Library Overview)
)
) -->

<!-- (dl (# Introduction)) -->

The `RJK.Maybe` library is an F# implementation of error handling and workflows around the `Result` type. It provides types and functions to safely manage errors and propagate them through functional workflows, reducing the need for exceptions and manual error checking in your code.

<!-- (dl (# Features)) -->

- **Maybe Type**: A type alias for `Result<'Value, ProcessFailure>`, representing computations that may succeed or fail with rich error information.
- **Maybe Monad**: Enables monadic operations for chaining computations that may fail, propagating errors automatically.
- **MaybeList, MaybeSeq**: Utilities for working with lists and sequences of results.
- **Operators**: Custom operators for more expressive functional error handling.
- **Base Types**: Foundational types for error representation and workflow composition.

<!-- (dl (# Project Structure)) -->

- `Maybe.fs` – Core Maybe type and functions for error-aware workflows
- `MaybeMonad.fs` – Monad implementation and helpers for chaining error-prone computations
- `MaybeList.fs` – List utilities for Maybe (Result) types
- `MaybeSeq.fs` – Sequence utilities for Maybe (Result) types
- `Operators.fs` – Functional operators for error handling
- `BaseTypes.fs` – Supporting types for error representation

<!-- (dl (# Usage Example)) -->

```fsharp
open RJK.Maybe

let tryParseInt (s: string) =
    match System.Int32.TryParse(s) with
    | true, v -> Ok v
    | false, _ -> Error (GeneralFailure "Not an int")

let result =
    tryParseInt "42"
    |> Maybe.map ((*) 2)
// result = Ok 84
```

<!-- (dl (# Getting Started)) -->

1. Reference the `RJK.Maybe` library in your F# project.
2. Open the `RJK.Maybe` namespace.
3. Use the provided types and functions to handle errors and propagate them safely.

<!-- (dl (# License)) -->

This project is licensed under the MIT License. See the `LICENSE` file for details.

<!-- (dl (# Contributing)) -->

Contributions are welcome! Please see the contributing guidelines in the repository.
