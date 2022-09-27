namespace PrimeNumberGenerator;

using System.Collections;

/// <summary>
/// Prime Generator, but with all values calculated upon instantiation.
/// Use if the time between instantiation and first use is long, but the interval between uses is short.
/// If possible, you can also instantiate the class on a separate thread.
/// </summary>
public class PrecalculatedPrimeGenerator
{
	private readonly int _limit;
	private readonly BitArray _primes;
	
	public PrecalculatedPrimeGenerator(int limit = 982_451_654)
	{
		_limit = limit;
		_primes = new BitArray(_limit, true)
		{
			[0] = false,
			[1] = false
		};

		PrecalculatePrimes();
	}

	private void PrecalculatePrimes()
	{
		int limitSqrt = (int)Math.Sqrt(_limit);

		for (int i = 2; i <= limitSqrt; i++)
		{
			if (_primes[i])
			{
				for (int j = i * i; j < _limit && j > 0; j += i)
				{
					_primes[j] = false;
				}
			}
		}
	}

	public IEnumerable<int> Stream()
	{
		for (int i = 2; i < _limit; i++)
		{
			if (_primes[i])
			{
				yield return i;
			}
		}
	}
}