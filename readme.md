<!-- GENERATED DOCUMENT DO NOT EDIT! -->
<!-- prettier-ignore-start -->
<!-- markdownlint-disable -->

<!-- Compiled with doculisp https://www.npmjs.com/package/doculisp -->
<!-- Written By: Jason Kerney -->

# "Maybe" #

1. Section: [RJK.Maybe Library Overview](#rjkmaybe-library-overview)
2. Section: [Maybe Module API](#maybe-module-api)
3. Section: [Maybe Monad API](#maybe-monad-api)
4. Section: [Contributors ✨](#contributors-)

## RJK.Maybe Library Overview ##

### Introduction ###

The `RJK.Maybe` library is an F# implementation of the Maybe monad and related functional programming constructs. It provides types and functions to safely handle optional values, reducing the need for null checks and exception handling in your code.

### Features ###

- **Maybe Type**: Represents optional values, encapsulating the presence or absence of a value.
- **Maybe Monad**: Enables monadic operations for chaining computations that may fail.
- **MaybeList, MaybeSeq**: Utilities for working with lists and sequences of optional values.
- **Operators**: Custom operators for more expressive functional code.
- **Base Types**: Foundational types used throughout the library.

### Project Structure ###

- `Maybe.fs` – Core Maybe type and functions
- `MaybeMonad.fs` – Monad implementation and helpers
- `MaybeList.fs` – List utilities for Maybe
- `MaybeSeq.fs` – Sequence utilities for Maybe
- `Operators.fs` – Functional operators for Maybe
- `BaseTypes.fs` – Supporting types

### Usage Example ###

```fsharp
open RJK.Maybe

let tryParseInt (s: string) =
    match System.Int32.TryParse(s) with
    | true, v -> Some v
    | false, _ -> None

let result =
    tryParseInt "42"
    |> Maybe.map ((*) 2)
// result = Some 84
```

### Getting Started ###

1. Reference the `RJK.Maybe` library in your F# project.
2. Open the `RJK.Maybe` namespace.
3. Use the provided types and functions to handle optional values safely.

### License ###

This project is licensed under the MIT License. See the `LICENSE` file for details.

### Contributing ###

Contributions are welcome! Please see the contributing guidelines in the repository.

## Maybe Module API ##

### Overview ###

This document provides API documentation for the `Maybe` module in the F# library. It describes the core utilities for working with the `maybe` type.

### Functions ###

#### wrap ####

Wraps a value in a `maybe` (Ok) type.

#### orMaybe ####

Returns the first successful (Ok) value from two `maybe` values, or the second if both are errors.

#### isPreferredOver ####

Returns the first value if it is Ok, otherwise the second.

#### butPrefer ####

Returns the second value if it is Ok, otherwise the first.

#### simplify ####

Flattens a nested `maybe` value (i.e., `maybe maybe`) into a single `maybe`.

#### toBool ####

Converts a `bool maybe` to a `bool`, returning false if Error.

#### hasValue ####

Returns true if the `maybe` value is Ok.

#### isError ####

Returns true if the `maybe` value is Error.

#### orDefault ####

Returns the value if Ok, otherwise returns the provided default value.

#### lift ####

Lifts a function to operate on a `maybe` value.

#### mlift ####

Lifts a function returning `maybe` to operate on a `maybe` value (monadic bind).

#### llift ####

Applies a lifted function to a `maybe` value.

#### mllift ####

Applies a monadic lifted function to a `maybe` value.

#### partialLift ####

Partially lifts a function returning `maybe` to operate on a `maybe` value.

#### map ####

Maps a function over a `maybe` value using computation expressions.

#### check ####

Checks a predicate on a `maybe` value, returning a bool.

#### fromOption ####

Converts an option to a `maybe`, using the provided error message if None.

#### callToString ####

Converts a `maybe` value to a string representation.

## Maybe Monad API ##

### Overview ###

This document describes the monadic and computation expression support for the `maybe` type in the F# library, as implemented in `MaybeMonad.fs`.

### Functions ###

#### asMaybe ####

Wraps a value in a `maybe` (Ok) type.

#### delayMaybe ####

Delays the execution of a function returning a `maybe` value.

#### bindWith ####

Binds a function to a `maybe` value, propagating errors and exceptions.

#### combineMaybeWith ####

Combines two `maybe` values, returning the second if the first is Ok, otherwise propagating the error.

#### ready ####

A `maybe` value representing a successful unit result.

### MaybeBuilder ###

The computation expression builder for the maybe monad, enabling F# computation expressions with `maybe` values.

- **Return**: Wraps a value in a `maybe` (Ok) type.
- **ReturnFrom**: Returns an existing `maybe` value.
- **Delay**: Delays the execution of a function returning a `maybe` value.
- **Bind**: Binds a function to a `maybe` value, propagating errors and exceptions.
- **Combine**: Combines two `maybe` values, returning the second if the first is Ok, otherwise propagating the error.
- **Zero**: Returns a successful unit `maybe` value.

#### maybe ####

The computation expression instance for the maybe monad. Use `maybe { ... }` to write monadic code with `maybe` values.

## Contributors ✨ ##

Thanks goes to these wonderful people ([emoji key](https://allcontributors.org/docs/en/emoji-key)):

<table>
  <tr>
    <td align="center"><a href="https://github.com/edf-re"><img src="https://avatars.githubusercontent.com/u/13739273?v=4?s=100" width="100px;" alt=""/><br /><sub><b>EDF Renewables</b></sub></a><br /><a href="#financial-edf-re" title="Financial">💵</a></td>
  </tr>
</table>

This project follows the [all-contributors](https://github.com/all-contributors/all-contributors) specification. Contributions of any kind welcome!

<!-- Written By: Jason Kerney -->
<!-- markdownlint-restore -->
<!-- prettier-ignore-end -->
<!-- GENERATED DOCUMENT DO NOT EDIT! -->