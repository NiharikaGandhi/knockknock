using System.Linq;
using System.Runtime.Serialization;

namespace ReferenceAPI.Services
{
    public interface IShapeService
    {
        ShapeService.TriangleType GetTriangleType(long a, long b, long c);
    }

    public class ShapeService : IShapeService
    {
        public TriangleType GetTriangleType(long a, long b, long c)
        {
            var values = new[] { a, b, c };
            const long maxValue = 2147483648;
            const int zero = 0;

            if (a <= zero || b <= zero || c <= zero || a >= maxValue || b >= maxValue || c >= maxValue)
            {
                return TriangleType.Error;
            }
            if (b + c <= a || a + c <= b || a + b <= c)
            {
                return TriangleType.Error;
            }
            if (values.Distinct().Count() == 1)
            {
                return TriangleType.Equilateral;
            }
            if (values.Distinct().Count() == 2)
            {
                return TriangleType.Isosceles;
            }
            if (values.Distinct().Count() == 3)
            {
                return TriangleType.Scalene;
            }
            return TriangleType.Error;
        }

        public enum TriangleType
        {
            [EnumMember(Value = "Error")] Error = 0,
            [EnumMember(Value = "Equilateral")] Equilateral = 1,
            [EnumMember(Value = "Isosceles")] Isosceles = 2,
            [EnumMember(Value = "Scalene")] Scalene = 3
        }
    }
}