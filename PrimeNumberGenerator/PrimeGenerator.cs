namespace PrimeNumberGenerator;

using System.Collections;

/// <summary>
/// Default Prime Generator.
/// All values are calculated upon request.
/// This means that it is better suited for small ranges, or if you need a lot of primes in a short time.
/// </summary>
public class PrimeGenerator
{
	private readonly int _limit;
	private readonly BitArray _primes;
	
	public PrimeGenerator(int limit = 982_451_654)
	{
		_limit = limit;
		_primes = new BitArray(_limit, true)
		{
			[0] = false,
			[1] = false
		};
	}

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