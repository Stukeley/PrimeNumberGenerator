namespace PrimeNumberGenerator.Benchmarks;

using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class PrimeGenerator_PrecalculatedBenchmarks
{
	private PrecalculatedPrimeGenerator _generator;

	[GlobalSetup]
	public void SetUp()
	{
		_generator = new PrecalculatedPrimeGenerator();
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