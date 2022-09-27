# PrimeNumberGenerator
A lightning fast Prime Number generator created with C# in .NET 6.0.

## About
Initially started as a casual project that fulfills the requirements of [Prime Streaming (PG-13) on CodeWars](https://www.codewars.com/kata/5519a584a73e70fa570005f5), the project has since been better optimized and documented.

**PrimeNumberGenerator** is an (in)finite stream of prime numbers, with its upper limit defined by the user upon instantiation.

Simple to use and fast - this project is a great solution for those who need a constant stream of prime numbers with little downtime.

The default **PrimeGenerator** (based on Sieve of Atkin) is capable of generating a sequence of 50 Million primes in less than 3 seconds.

The **ErastothenesPrimeGenerator** (based on Sieve of Erastothenes) is significantly slower, and generates 50 Million primes in about 11 seconds.

## Prerequisites
- .NET 6.0

## Usage

The limit of numbers to check for primes (NOT the number of primes in the stream) is passed to the constructor, with the default value being **982_451_654** - enough to generate 50 million primes.

Calling `Stream()` will return an `IEnumerable<int>` that is easy to manipulate using LINQ methods, such as `Skip()` or `Take()`.

Examples:

```csharp
// Get the list of first 10_000 primes.
var primes = new PrimeGenerator(200_000).Take(10_000).ToList();

// Get the 50 millionth prime.
var prime = new PrimeGenerator().Skip(49_999_999).Take(1).First();
```

The limit of numbers, passed as parameter to constructor, can be a great performance improvement, so if possible, you should only take as many numbers as you need.

## Memory consumed

PrimeGenerator operates using `BitArray`, which only requires 1 bit per element. Therefore, the amount of memory to store the first 50 million primes is only about:

(982_451_654 / (8 * 1024)) = 120_000 KB = **118 MB**

## Benchmarks

| Generator | Amount of primes | Mean | Error | StdDev | Allocated |
| --------- | ---------------- | ---- | ----- | ------ | --------- |
| Default   | 50 Million       | 2778 ms| 10.44 ms| 9.77 ms| 11056 B   |
| Erastothenes   | 50 Million        | 10.669 s| 0.0465 s| 0.0388 s| 664 B   |
| Default   | 5 Million        | 252 ms| 0.54 ms| 0.51 ms| 868 B   |
| Erastothenes   | 5 Million        | 9.009 s| 0.0120 s| 0.0106 s| 664 B   |

## Reference

- Sieve of Atkin theory by Clay Wrentz: https://medium.com/smucs/sieve-of-atkin-the-theoretical-optimization-of-prime-number-generation-e47107d61e28
- Sieve of Atkin implementation by Ashraff Ali Wahab: https://www.codeproject.com/Articles/490085/Eratosthenes-Sundaram-Atkins-Sieve-Implementation (used in accordance with The Code Project Open License (CPOL) 1.02, available here: https://www.codeproject.com/info/cpol10.aspx)
- Sieve of Eratosthenes optimization (multiple authors) by Algorithms for Competitive Programming: https://cp-algorithms.com/algebra/sieve-of-eratosthenes.html
