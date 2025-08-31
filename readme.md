<!-- GENERATED DOCUMENT DO NOT EDIT! -->
<!-- prettier-ignore-start -->
<!-- markdownlint-disable -->

<!-- Compiled with doculisp https://www.npmjs.com/package/doculisp -->
<!-- Written By: Jason Kerney -->

# "Maybe" #

## RJK.Maybe Library Overview ##

## Introduction

The `RJK.Maybe` library is an F# implementation of the Maybe monad and related functional programming constructs. It provides types and functions to safely handle optional values, reducing the need for null checks and exception handling in your code.

## Features

- **Maybe Type**: Represents optional values, encapsulating the presence or absence of a value.
- **Maybe Monad**: Enables monadic operations for chaining computations that may fail.
- **MaybeList, MaybeSeq**: Utilities for working with lists and sequences of optional values.
- **Operators**: Custom operators for more expressive functional code.
- **Base Types**: Foundational types used throughout the library.

## Project Structure

- `Maybe.fs` – Core Maybe type and functions
- `MaybeMonad.fs` – Monad implementation and helpers
- `MaybeList.fs` – List utilities for Maybe
- `MaybeSeq.fs` – Sequence utilities for Maybe
- `Operators.fs` – Functional operators for Maybe
- `BaseTypes.fs` – Supporting types

## Usage Example

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

## Getting Started

1. Reference the `RJK.Maybe` library in your F# project.
2. Open the `RJK.Maybe` namespace.
3. Use the provided types and functions to handle optional values safely.

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.

## Contributing

Contributions are welcome! Please see the contributing guidelines in the repository.

## Contributors ✨

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