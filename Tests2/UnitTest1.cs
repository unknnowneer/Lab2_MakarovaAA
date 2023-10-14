using Microsoft.VisualStudio.TestPlatform.TestHost;
using TriangleCalculator;

namespace Tests2
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CalculateTriangle_IsoscelesTriangle_ReturnsIsoscelesTriangleTypeAndVertices()
        {
            string sideA = "5";
            string sideB = "5";
            string sideC = "6";

            // Act
            Triangle triangle = TriangleCalculator.Program.CalculateTriangle(sideA, sideB, sideC);

            // Assert
            Assert.AreEqual(TriangleType.Isosceles, triangle.Type);
            Assert.AreEqual(3, triangle.Vertices.Count);
            Assert.AreEqual((50, 50), triangle.Vertices[0]);
            Assert.AreEqual((25, 75), triangle.Vertices[1]);
            Assert.AreEqual((75, 75), triangle.Vertices[2]);
        }
    }
}