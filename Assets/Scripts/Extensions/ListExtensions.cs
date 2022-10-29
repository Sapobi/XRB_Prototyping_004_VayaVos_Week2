using System.Collections.Generic;
using UnityEngine;

public static class ListExtensions
{
	public static void Shuffle<T>(this IList<T> list)
	{
		var n = list.Count;
		while (n > 1)
		{
			var k = Random.Range(0, n);
			n--;
			(list[k], list[n]) = (list[n], list[k]);
		}
	}
}