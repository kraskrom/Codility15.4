/*
Let A be a non-empty array consisting of N integers.

The abs sum of two for a pair of indices (P, Q) is the absolute value |A[P] + A[Q]|, for 0 ≤ P ≤ Q < N.

For example, the following array A:

  A[0] =  1
  A[1] =  4
  A[2] = -3
has pairs of indices (0, 0), (0, 1), (0, 2), (1, 1), (1, 2), (2, 2).
The abs sum of two for the pair (0, 0) is A[0] + A[0] = |1 + 1| = 2.
The abs sum of two for the pair (0, 1) is A[0] + A[1] = |1 + 4| = 5.
The abs sum of two for the pair (0, 2) is A[0] + A[2] = |1 + (−3)| = 2.
The abs sum of two for the pair (1, 1) is A[1] + A[1] = |4 + 4| = 8.
The abs sum of two for the pair (1, 2) is A[1] + A[2] = |4 + (−3)| = 1.
The abs sum of two for the pair (2, 2) is A[2] + A[2] = |(−3) + (−3)| = 6.
Write a function:

class Solution { public int solution(int[] A); }

that, given a non-empty array A consisting of N integers, returns the minimal abs sum of two for any pair of indices in this array.

For example, given the following array A:

  A[0] =  1
  A[1] =  4
  A[2] = -3
the function should return 1, as explained above.

Given array A:

  A[0] = -8
  A[1] =  4
  A[2] =  5
  A[3] =-10
  A[4] =  3
the function should return |(−8) + 5| = 3.

Write an efficient algorithm for the following assumptions:

N is an integer within the range [1..100,000];
each element of array A is an integer within the range [−1,000,000,000..1,000,000,000].
*/

using System;

namespace Codility15._4
{
    class Solution
    {
        public int solution(int[] A)
        {
            Array.Sort(A);
            if (A[0] == 0)
                return 0;
            if (A[A.Length - 1] == 0)
                return 0;
            if (A[0] > 0)
                return 2 * A[0];
            if (A[A.Length - 1] < 0)
                return -2 * A[A.Length - 1];
            int i = 0;
            while (A[i] < 0)
                i++;
            if (A[i] == 0)
                return 0;
            int s = Math.Abs(A[i] + A[i]);
            if (Math.Abs(A[i - 1] + A[i - 1]) < s)
                s = Math.Abs(A[i - 1] + A[i - 1]);
            int l = i - 1;
            int r = i;
            while (l >= 0 && r < A.Length)
            {
                int sum = Math.Abs(A[l] + A[r]);
                if (sum < s)
                {
                    s = sum;
                    if (s == 0)
                        return 0;
                }
                if (-A[l] < A[r])
                    l--;
                else
                    r++;
            }
            return s;
        }
    }

    class Program
    {
        static void Main()
        {
            Solution sol = new Solution();
            int[] A = { 1, 4, -3 };
            //int[] A = { -8, 4, 5, -10, 3 };
            //int[] A = { -5, -3, -1, 2, 3, 4 };
            int s = sol.solution(A);
            Console.WriteLine("Solution: " + s);
            //Console.WriteLine("Solution: " + string.Join(", ", s));
        }
    }
}
