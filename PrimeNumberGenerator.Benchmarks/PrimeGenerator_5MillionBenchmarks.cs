namespace PrimeNumberGenerator.Benchmarks;

using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class PrimeGenerator_5MillionBenchmarks
{
	private PrimeGenerator _generator;

	[GlobalSetup]
	public void SetUp()
	{
		_generator = new PrimeGenerator(86_028_122);
	}

	[Benchmark]
	public void PrimeGenerator_5MillionthPrime()
	{
		var result = _generator.Stream().Skip(4_999_999).Take(1);
		Console.WriteLine($"{result.Count()}");
	}
	
	[Benchmark]
	public void PrimeGenerator_1ThousandthPrime()
	{
		var result = _generator.Stream().Skip(999).Take(1);
		Console.WriteLine($"{result.Count()}");
	}
}