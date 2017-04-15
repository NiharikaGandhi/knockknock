namespace ReferenceAPI.Services
{
    public interface IMathService
    {
       long FibonacciValue(int n);
    }

    public class MathService : IMathService
    {
       public long FibonacciValue(int n)
        {
            if (n == 0) return 0;
            if (n == 1 || n == -1) return 1;

            return n > 1 ? FibonacciForPositive(n) : FibonacciForNegative(n);
        }

        private static long FibonacciForNegative(int n)
        {
            long a = 0;
            long b = 1;
            long c = 1;
            for (var i = -2; i >= n; i--)
            {
                c = a - b;
                a = b;
                b = c;
            }
            return c;
        }

        private static long FibonacciForPositive(int n)
        {
            long a = 0;
            long b = 1;
            long c = 1;

            for (var i = 2; i <= n; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }

            return c;
        }
       
    }
}