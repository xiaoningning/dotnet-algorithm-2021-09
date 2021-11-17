public class Solution {
    // N = k, k + 1, k + 2, ..., k + (i - 1)
    // N = k * i + (i - 1) * i / 2
    // N - (i - 1) * i / 2 = k * i => i < sqrt(2N)
    // Time: O(N ^ 0.5) => O(sqrt(N)), space: O(1) Solve the equation i * (i - 1) / 2 = N, we know i ~ N ^ 0.5
    public int ConsecutiveNumbersSum1(int n) {
        int ans = 0;
        for (int i = 1; i * (i - 1) / 2 < n; i++) if ((n - i * (i - 1) / 2) % i == 0) ans++;
        return ans;
    }
    // N = k + (k+1) + (k+2) + (k+3) + ... + (k+i-1) = i*k + (1+2+3+... + i-1)
    // sum(i) = (1+2+3+...+i-1) => N = sum(i) + i*k ==>i*k = N - sum(i)
    public int ConsecutiveNumbersSum(int n) {
        int ans = 0, sum = 0;
        for (int i = 1; sum < n; i++) { 
            sum += i;
            if ((n - sum) % i == 0) ans++;
        }
        return ans;
    }
    /**
    To be more accurate, it's O(biggest prime factor).
    Because every time I find a odd factor, we do N /= i.
    This help reduce N faster.

    Assume P is the biggest prime factor of a odd number N .
    If N = 3^x * 5^y ...* P, Loop on i will stop at P^0.5
    If N = 3^x * 5^y ...* P^z, Loop on i will stop at P.
    In the best case, N = 3^x and our solution is O(log3N)
    In the worst case, N = P^2 and our solution is O(P) = O(N^0.5) => O(sqrt(N))
    */
}
