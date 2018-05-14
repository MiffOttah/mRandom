Provides a number of methods related to randomness.

The base class of this library is `RandomGenerator`. This class provides methods to generate random numbers, data, and samples from a list.

A `RandomGenerator` requires a source of randomness to initialize. For basic applications, a static one is provided at `RandomGenerator.Default` which uses `System.Random` to provide randomness. For more secure randomness, you can use a `CryptoRandomnessSource`, or implement the `IRandomnessSource` interface.

Disclaimer: I wouldn't trust the math in the library too much. ^^;
