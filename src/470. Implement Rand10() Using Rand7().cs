/**
 * The Rand7() API is already defined in the parent class SolBase.
 * public int Rand7();
 * @return a random integer in the range 1 to 7
 */
public class Solution : SolBase {
    // https://en.wikipedia.org/wiki/Rejection_sampling
    public int Rand10() {
        // Rand7 => [1,7]
        var num = (Rand7() - 1) * 7 + Rand7(); // => Rand49() [1, 49]
        return num <= 40 ? num % 10 + 1 : Rand10(); // if [41, 49] => rejection sampling
    }
}
