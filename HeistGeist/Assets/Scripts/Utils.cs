using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public static class Utils
{
    public static IEnumerable<T> Sample<T>(T[] population, int k)
    {
        var pool = (T[]) population.Clone();
        var n = pool.Length;
        if (k < 0 || k > n)
            throw new ArgumentOutOfRangeException(nameof(k), "Sample larger than population or is negative");
        for (var i = 0; i < k; ++i)
        {
            var j = Random.Range(0, n - i);
            yield return pool[j];
            pool[j] = pool[n - i - 1];
        }
    }
}