namespace PrimeNumberGenerator;

using System.Collections;

/// <summary>
/// Alternative Prime Generator using Eratosthenes Sieve.
/// All values are calculated upon request.
/// This can perform better than the default implementation for small ranges, or if you need a lot of primes in a short time.
/// </summary>
public class EratosthenesPrimeGenerator
{
	/// <summary>
	/// Limit of numbers to check for primes (NOT the number of primes).
	/// </summary>
	private readonly int _limit;
	
	/// <summary>
	/// BitArray to store the prime numbers.
	/// Each index in the array represents a natural number, and the value of each bit represents if its prime (true) or not (false).
	/// </summary>
	private readonly BitArray _primes;
	
	/// <summary>
	/// Instantiates the Prime Generator.
	/// </summary>
	/// <param name="limit">The upper limit of numbers to check for primes (NOT the number of primes). Default value allows up to 50 Million primes.</param>
	public EratosthenesPrimeGenerator(int limit = 982_451_654)
	{
		_limit = limit;
		_primes = new BitArray(_limit, true)
		{
			[0] = false,
			[1] = false
		};
	}

	/// <summary>
	/// Returns a sequence of prime numbers. The number of primes returned is limited by the number limit passed to the constructor.
	/// The function will return one prime at a time through 'yield return'.
	/// Additionally, primes are calculated on demand.
	/// </summary>
	/// <example>new EratosthenesPrimeGenerator().Stream().Skip(100_000).Take(50).ToArray()</example>
	/// <returns>A sequence of prime numbers, one by one, as IEnumerable.</returns>
	public IEnumerable<int> Stream()
	{
		int limitSqrt = (int)Math.Sqrt(_limit);

		int index;

		for (index = 2; index <= limitSqrt; index++)
		{
			if (_primes[index])
			{
				for (int j = index * index; j < _limit && j > 0; j += index)
				{
					_primes[j] = false;
				}

				yield return index;
			}
		}

		while (index < _limit)
		{
			if (_primes[index])
			{
				yield return index;
			}

			index++;
		}
	}
}