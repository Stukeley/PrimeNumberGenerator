using BenchmarkDotNet.Running;
using PrimeNumberGenerator.Benchmarks;

//BenchmarkRunner.Run<PrimeGenerator_5MillionBenchmarks>();
//BenchmarkRunner.Run<PrimeGenerator_50MillionBenchmarks>();
//BenchmarkRunner.Run<PrimeGenerator_PrecalculatedBenchmarks>();
//BenchmarkRunner.Run<PrimeGenerator_PrecalculatedCalculationBenchmark>();
BenchmarkRunner.Run<PrimeGenerator_OptimizedGeneratorBenchmark>();