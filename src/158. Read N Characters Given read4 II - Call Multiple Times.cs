/**
 * The Read4 API is defined in the parent class Reader4.
 *     int Read4(char[] buf4);
 */

public class Solution : Reader4 {
    /**
     * @param buf Destination buffer
     * @param n   Number of characters to read
     * @return    The number of actual characters read
     */
    char[] buf4 = new char[4];
    int readPos = 0, writePos = 0;
    public int Read(char[] buf, int n) {
        for (int i = 0; i< n; i++) {
            if (readPos == writePos) { // finish to buf from buf4, read again
                writePos = Read4(buf4);
                readPos = 0;
                if (writePos == 0) return i; // read all of file before n
            }
            buf[i] = buf4[readPos++];
        }
        return n;
    }
}
