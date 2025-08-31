<!-- (dl
(section-meta
    (title Maybe Module API)
)
) -->

<!-- (dl (# Overview)) -->

This document provides API documentation for the `Maybe` module in the F# library. It describes the core utilities for working with the `maybe` type.

<!-- (dl (# Functions)) -->

<!-- (dl (## wrap)) -->
Wraps a value in a `maybe` (Ok) type.

<!-- (dl (## orMaybe)) -->
Returns the first successful (Ok) value from two `maybe` values, or the second if both are errors.

<!-- (dl (## isPreferredOver)) -->
Returns the first value if it is Ok, otherwise the second.

<!-- (dl (## butPrefer)) -->
Returns the second value if it is Ok, otherwise the first.

<!-- (dl (## simplify)) -->
Flattens a nested `maybe` value (i.e., `maybe maybe`) into a single `maybe`.

<!-- (dl (## toBool)) -->
Converts a `bool maybe` to a `bool`, returning false if Error.

<!-- (dl (## hasValue)) -->
Returns true if the `maybe` value is Ok.

<!-- (dl (## isError)) -->
Returns true if the `maybe` value is Error.

<!-- (dl (## orDefault)) -->
Returns the value if Ok, otherwise returns the provided default value.

<!-- (dl (## lift)) -->
Lifts a function to operate on a `maybe` value.

<!-- (dl (## mlift)) -->
Lifts a function returning `maybe` to operate on a `maybe` value (monadic bind).

<!-- (dl (## llift)) -->
Applies a lifted function to a `maybe` value.

<!-- (dl (## mllift)) -->
Applies a monadic lifted function to a `maybe` value.

<!-- (dl (## partialLift)) -->
Partially lifts a function returning `maybe` to operate on a `maybe` value.

<!-- (dl (## map)) -->
Maps a function over a `maybe` value using computation expressions.

<!-- (dl (## check)) -->
Checks a predicate on a `maybe` value, returning a bool.

<!-- (dl (## fromOption)) -->
Converts an option to a `maybe`, using the provided error message if None.

<!-- (dl (## callToString)) -->
Converts a `maybe` value to a string representation.
