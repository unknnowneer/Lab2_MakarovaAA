using Microsoft.VisualStudio.TestPlatform.TestHost;
using TriangleCalculator;



namespace Test
{
    public class Tests
    {
       public void Setup()
       {

       }
            [Test]
            public void Test1()
            {
                Triangle triangle = new Triangle();
                triangle.Type = TriangleType.InvalidInput;
                triangle.Vertices = new List<(int, int)>();
                triangle.Vertices.Add((-2, -2));
                triangle.Vertices.Add((-2, -2));
                triangle.Vertices.Add((-2, -2));

                Triangle result = .CalculateTriangle("pp", "22", "77");

            
                Assert.AreEqual( triangle.Type, result.Type);
                Assert.AreEqual(triangle.Vertices, result.Vertices);
               
            }
        
    }
}