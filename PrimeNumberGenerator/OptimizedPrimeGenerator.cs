namespace PrimeNumberGenerator;

using System.Collections;

/// <summary>
/// Optimized version of the Prime Generator, using Sieve of Atkin.
/// This code is based on the C# implementation of the Sieve of Atkin by Ashraff Ali Wahab,
/// to be found here: https://www.codeproject.com/Articles/490085/Eratosthenes-Sundaram-Atkins-Sieve-Implementation
/// Used in accordance with the Code Project Open License (CPOL) 1.02: https://www.codeproject.com/info/cpol10.aspx
/// </summary>
public class OptimizedPrimeGenerator
{
	private readonly int _limit;
	private readonly BitArray _primes;

	public OptimizedPrimeGenerator(int limit = 982_451_654)
	{
		_limit = limit;
		_primes = new BitArray(_limit, false);

		PrecalculatePrimes();
	}

	private void PrecalculatePrimes()
	{
		int sqrt = (int)Math.Sqrt(_limit);

		int xStepSize = 3;
		int yLimit = 0;
		int n = 0;

		int temp = (int)Math.Sqrt((_limit - 1) / 3);
		
		for (int i = 0; i < 12 * temp; i += 24)
		{
			xStepSize += i;
			yLimit = 12 * (int)Math.Sqrt(_limit - xStepSize) - 36;
			n = xStepSize + 16;
			for (int j = -12; j < yLimit + 1; j += 72)
			{
				n += j;
				_primes[n] ^= true;
			}

			n = xStepSize + 4;

			for (int j = 12; j < yLimit + 1; j += 72)
			{
				n += j;
				_primes[n] ^= true;
			}
		}

		xStepSize = 0;
		temp = 8 * (int)Math.Sqrt((_limit - 1) / 4) + 4;
		
		for (int i = 4; i < temp; i += 8)
		{
			xStepSize += i;
			n = xStepSize + 1;

			if (xStepSize % 3 != 0)
			{
				int tempTwo = 4 * (int)Math.Sqrt(_limit - xStepSize) - 3;
				for (int j = 0; j < tempTwo; j += 8)
				{
					n += j;
					_primes[n] ^= true;
				}
			}
			else
			{
				yLimit = 12 * (int)Math.Sqrt(_limit - xStepSize) - 36;
				n = xStepSize + 25;
				for (int j = -24; j < yLimit + 1; j += 72)
				{
					n += j;
					_primes[n] ^= true;
				}

				n = xStepSize + 1;

				for (int j = 24; j < yLimit + 1; j += 72)
				{
					n += j;
					_primes[n] ^= true;
				}
			}
		}

		xStepSize = 1;
		temp = (int)Math.Sqrt(_limit / 2) + 1;
		
		for (int i = 3; i < temp; i += 2)
		{
			xStepSize += 4 * i - 4;
			n = 3 * xStepSize;
			int s = 4;
			if (n > _limit)
			{
				int min_y = ((int)Math.Sqrt(n - _limit) >> 2) << 2;
				int yy = min_y * min_y;
				n -= yy;
				s = 4 * min_y + 4;
			}
			else
			{
				s = 4;
			}

			for (int j = s; j < 4 * i; j += 8)
			{
				n -= j;
				if (n <= _limit && n % 12 == 11)
				{
					_primes[n] ^= true;
				}
			}
		}

		xStepSize = 0;
		
		for (int i = 2; i < temp; i += 2)
		{
			xStepSize += 4 * i - 4;
			n = 3 * xStepSize;
			int s = 0;
			if (n > _limit)
			{
				int min_y = (((int)Math.Sqrt(n - _limit) >> 2) << 2) - 1;
				int yy = min_y * min_y;
				n -= yy;
				s = 4 * min_y + 4;
			}
			else
			{
				n -= 1;
				s = 0;
			}

			for (int j = s; j < 4 * i; j += 8)
			{
				n -= j;
				if (n <= _limit && n % 12 == 11)
				{
					_primes[n] ^= true;
				}
			}
		}

		for (int i = 5; i < sqrt + 1; i += 2)
		{
			if (_primes[i])
			{
				int k = i * i;
				for (int z = k; z < _limit; z += k)
				{
					_primes[z] = false;
				}
			}
		}
	}

	public IEnumerable<int> Stream()
	{
		yield return 2;
		yield return 3;

		for (int i = 5; i < _limit; i += 2)
		{
			if (_primes[i])
			{
				yield return i;
			}
		}
	}
}