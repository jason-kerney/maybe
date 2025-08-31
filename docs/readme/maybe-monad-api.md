<!-- (dl
(section-meta
    (title Maybe Monad API)
)
) -->

<!-- (dl (# Overview)) -->

This document describes the monadic and computation expression support for the `maybe` type in the F# library, as implemented in `MaybeMonad.fs`.

<!-- (dl (# Functions)) -->

<!-- (dl (## asMaybe)) -->
Wraps a value in a `maybe` (Ok) type.

<!-- (dl (## delayMaybe)) -->
Delays the execution of a function returning a `maybe` value.

<!-- (dl (## bindWith)) -->
Binds a function to a `maybe` value, propagating errors and exceptions.

<!-- (dl (## combineMaybeWith)) -->
Combines two `maybe` values, returning the second if the first is Ok, otherwise propagating the error.

<!-- (dl (## ready)) -->
A `maybe` value representing a successful unit result.

<!-- (dl (# MaybeBuilder)) -->

The computation expression builder for the maybe monad, enabling F# computation expressions with `maybe` values.

- **Return**: Wraps a value in a `maybe` (Ok) type.
- **ReturnFrom**: Returns an existing `maybe` value.
- **Delay**: Delays the execution of a function returning a `maybe` value.
- **Bind**: Binds a function to a `maybe` value, propagating errors and exceptions.
- **Combine**: Combines two `maybe` values, returning the second if the first is Ok, otherwise propagating the error.
- **Zero**: Returns a successful unit `maybe` value.

<!-- (dl (## maybe)) -->
The computation expression instance for the maybe monad. Use `maybe { ... }` to write monadic code with `maybe` values.
