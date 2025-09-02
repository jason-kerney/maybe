<!-- (dl
(section-meta
    (title Base Types API)
)
) -->

<!-- (dl (# Overview)) -->

This document describes the base types and helpers for the `maybe` library, as defined in `BaseTypes.fs`. The `maybe` type is an alias for `Result<'Value, ProcessFailure>`, providing a foundation for error-aware workflows and rich error information.

<!-- (dl (# Types)) -->

<!-- (dl (## ProcessFailure)) -->
Represents the possible failure cases for a process.
- **ExceptionFailure**: Failure due to an exception.
- **GeneralFailure**: Failure with a general error message.
- **CombinationError**: Failure due to a combination of multiple failures.

<!-- (dl (## maybe<'Value>)) -->
Alias for a result type with a value or `ProcessFailure`.

<!-- (dl (## Maybe<'Value>)) -->
Synonym for `maybe<'Value>` for convenience.

<!-- (dl (## mlist<'Value>)) -->
A maybe-wrapped list of values.

<!-- (dl (## mseq<'Value>)) -->
A maybe-wrapped sequence of values.

<!-- (dl (# Helpers)) -->

<!-- (dl (## asGeneralFailure)) -->
Wraps a string as a `GeneralFailure` in a `maybe` error.

<!-- (dl (## asExceptionFailure)) -->
Wraps an exception as an `ExceptionFailure` in a `maybe` error.

<!-- (dl (## asCombinationFailure)) -->
Wraps a list of failures as a `CombinationError` in a `maybe` error.

<!-- (dl (## combineWith)) -->
Combines two `ProcessFailure` values into a single `CombinationError`.

<!-- (dl (## asFailureCombinedWith)) -->
Synonym for `combineWith`.

<!-- (dl (## apply)) -->
Applies a maybe-wrapped function to a maybe-wrapped value.
