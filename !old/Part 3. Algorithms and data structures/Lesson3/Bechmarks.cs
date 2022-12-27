using System;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;

namespace Lesson3
{

    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct FloatIntUnion
    {
        [FieldOffset(0)]
        public int i;

        [FieldOffset(0)]
        public float f;
    }
    public class BechmarkPointOperations
    {
        public float CalcDistValueTypeFloat(PointStruct p1, PointStruct p2)
        {
            float x = p1.X - p2.X;
            float y = p1.Y - p2.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        public float CalcDistRefTypeFloat(PointClass p1, PointClass p2)
        {
            float x = p1.X - p2.X;
            float y = p1.Y - p2.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        public double CalcDistValueTypeDouble(PointStructDouble p1, PointStructDouble p2)
        {
            double x = p1.X - p2.X;
            double y = p1.Y - p2.Y;
            return MathF.Sqrt((float)((x * x) + (y * y)));
        }

        public static float FastSqrt(float num)
        {
            if (num == 0) return 0;
            FloatIntUnion union;
            union.i = 0;
            union.f = num;
            union.i -= 1 << 23; /* вычесть 2^m. */
            union.i >>= 1; /* разделить на 2. */
            union.i += 1 << 29; /* прибавить ((b + 1) / 2) * 2^m. */
            return union.f;
        }

        public float CalcDistRefTypeFast(PointClass p1, PointClass p2)
        {
            float x = p1.X - p2.X;
            float y = p1.Y - p2.Y;
            return FastSqrt((x * x) + (y * y));
        }

        [Benchmark]
        public void TestCalcDistValueTypeFloat()
        {
            CalcDistValueTypeFloat(new PointStruct() { X = 54.683f, Y = 23.1976f }, new PointStruct() { X = 88.5274f, Y = 36.9356f });
        }

        [Benchmark]
        public void TestCalcDistRefTypeFloat()
        {
            CalcDistRefTypeFloat(new PointClass() { X = 63.72452f, Y = 23.85451f }, new PointClass() { X = 41.5274f, Y = 73.57157f });
        }

        [Benchmark]
        public void TestCalcDistValueTypeDouble()
        {
            CalcDistValueTypeDouble(new PointStructDouble() { X = 63.72452d, Y = 23.85451d }, new PointStructDouble() { X = 41.5274d, Y = 73.57157d });
        }

        [Benchmark]
        public void TestCalcDistRefTypeFast()
        {
            CalcDistRefTypeFast(new PointClass() { X = 63.72452f, Y = 23.85451f }, new PointClass() { X = 41.5274f, Y = 73.57157f });
        }
    }
}
