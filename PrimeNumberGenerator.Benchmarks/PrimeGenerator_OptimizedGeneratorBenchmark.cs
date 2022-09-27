namespace PrimeNumberGenerator.Benchmarks;

using BenchmarkDotNet.Attributes;

public class PrimeGenerator_OptimizedGeneratorBenchmark
{
	private OptimizedPrimeGenerator _generator;

	[GlobalSetup]
	public void SetUp()
	{
		_generator = new OptimizedPrimeGenerator();
	}

	[Benchmark]
	public void PrimeGenerator_50MillionthPrime()
	{
		var result = _generator.Stream().Skip(49_999_999).Take(1);
		Console.WriteLine($"{result.Count()}");
	}

	[Benchmark]
	public void PrimeGenerator_5MillionthPrime()
	{
		var result = _generator.Stream().Skip(4_999_999).Take(1);
		Console.WriteLine($"{result.Count()}");
	}
}