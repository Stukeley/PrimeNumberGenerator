namespace PrimeNumberGenerator.Benchmarks;

using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class PrimeGenerator_PrecalculatedCalculationBenchmark
{
	private PrecalculatedPrimeGenerator _generator;

	[Benchmark]
	public void SetUp()
	{
		_generator = new PrecalculatedPrimeGenerator();
		Console.WriteLine(_generator.Stream().First());
	}
}