using Microsoft.VisualStudio.TestPlatform.TestHost;
using TriangleCalculator;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("a", "3", "4")]
        [TestCase("3", "a", "4")]
        [TestCase("3", "4", "a")]
        public void InvalidInput_ReturnsInvalidTriangle(string a, string b, string c)
        {

            // Act
            Triangle triangle = TriangleCalculator.Program.CalculateTriangle(a, b, c);

            // Assert
            Assert.AreEqual(TriangleType.InvalidInput, triangle.Type);
            Assert.AreEqual(3, triangle.Vertices.Count);
            Assert.AreEqual((-2, -2), triangle.Vertices[0]);
            Assert.AreEqual((-2, -2), triangle.Vertices[1]);
            Assert.AreEqual((-2, -2), triangle.Vertices[2]);
        }



        [TestCase("1", "2", "3")]
        [TestCase("3", "2", "1")]
        [TestCase("1", "3", "2")]
        public void NotTriangle_ReturnsInvalidTriangle(string a, string b, string c)
        {
            

            // Act
            Triangle triangle = TriangleCalculator.Program.CalculateTriangle(a, b, c);

            // Assert
            Assert.AreEqual(TriangleType.NotTriangle, triangle.Type);
            Assert.AreEqual(3, triangle.Vertices.Count);
            Assert.AreEqual((-1, -1), triangle.Vertices[0]);
            Assert.AreEqual((-1, -1), triangle.Vertices[1]);
            Assert.AreEqual((-1, -1), triangle.Vertices[2]);
        }



        


        [TestCase("0", "4", "6")]
        [TestCase("4", "0", "6")]
        [TestCase("6", "4", "0")]
        public void NotTriangle_ReturnsInvalidTriangle2(string a, string b, string c)
        {
            

            // Act
            Triangle triangle = TriangleCalculator.Program.CalculateTriangle(a, b, c);

            // Assert
            Assert.AreEqual(TriangleType.NotTriangle, triangle.Type);
            Assert.AreEqual(3, triangle.Vertices.Count);
            Assert.AreEqual((-1, -1), triangle.Vertices[0]);
            Assert.AreEqual((-1, -1), triangle.Vertices[1]);
            Assert.AreEqual((-1, -1), triangle.Vertices[2]);
        }

        [TestCase("3", "-4", "6")]
        [TestCase("-4", "3", "6")]
        [TestCase("6", "-4", "3")]
        public void NotTriangle_ReturnsInvalidTriangle3(string a, string b, string c)
        {


            // Act
            Triangle triangle = TriangleCalculator.Program.CalculateTriangle(a, b, c);

            // Assert
            Assert.AreEqual(TriangleType.NotTriangle, triangle.Type);
            Assert.AreEqual(3, triangle.Vertices.Count);
            Assert.AreEqual((-1, -1), triangle.Vertices[0]);
            Assert.AreEqual((-1, -1), triangle.Vertices[1]);
            Assert.AreEqual((-1, -1), triangle.Vertices[2]);
        }

        [TestCase("1", "2", "10")]
        [TestCase("2", "1", "10")]
        [TestCase("10", "2", "1")]
        public void NotTriangle_ReturnsInvalidTriangle4(string a, string b, string c)
        {
            
            // Act
            Triangle triangle = TriangleCalculator.Program.CalculateTriangle(a, b, c);

            // Assert
            Assert.AreEqual(TriangleType.NotTriangle, triangle.Type);
            Assert.AreEqual(3, triangle.Vertices.Count);
            Assert.AreEqual((-1, -1), triangle.Vertices[0]);
            Assert.AreEqual((-1, -1), triangle.Vertices[1]);
            Assert.AreEqual((-1, -1), triangle.Vertices[2]);
        }

       



        [TestCase("-1", "2", "3")]
        [TestCase("2", "-1", "3")]
        [TestCase("3", "2", "-1")]
        public void NotTriangle_ReturnsInvalidTriangle5(string a, string b, string c)
        {
           

            // Act
            Triangle triangle = TriangleCalculator.Program.CalculateTriangle(a, b, c);

            // Assert
            Assert.AreEqual(TriangleType.NotTriangle, triangle.Type);
            Assert.AreEqual(3, triangle.Vertices.Count);
            Assert.AreEqual((-1, -1), triangle.Vertices[0]);
            Assert.AreEqual((-1, -1), triangle.Vertices[1]);
            Assert.AreEqual((-1, -1), triangle.Vertices[2]);
            
        }


        [TestCase("2.5", "3", "4")]
        [TestCase("3", "2.5", "4")]
        [TestCase("4", "3", "2.5")]
        public void InvalidInput_ReturnsInvalidTriangle2(string a, string b, string c)
        {
            

            // Act
            Triangle triangle = TriangleCalculator.Program.CalculateTriangle(a, b, c);

            // Assert
            Assert.AreEqual(TriangleType.InvalidInput, triangle.Type);
            Assert.AreEqual(3, triangle.Vertices.Count);
            Assert.AreEqual((-2, -2), triangle.Vertices[0]);
            Assert.AreEqual((-2, -2), triangle.Vertices[1]);
            Assert.AreEqual((-2, -2), triangle.Vertices[2]);
        }




       
        

        [TestCase("2", "3", "10")]
        [TestCase("2", "10", "3")]
        [TestCase("10", "3", "2")]
        public void NotTriangle_ReturnsInvalidTriangle6(string a, string b, string c)
        {
            

            // Act
            Triangle triangle = TriangleCalculator.Program.CalculateTriangle(a, b, c);

            // Assert
            Assert.AreEqual(TriangleType.NotTriangle, triangle.Type);
            Assert.AreEqual(3, triangle.Vertices.Count);
            Assert.AreEqual((-1, -1), triangle.Vertices[0]);
            Assert.AreEqual((-1, -1), triangle.Vertices[1]);
            Assert.AreEqual((-1, -1), triangle.Vertices[2]);
        }

       
       
        

        [TestCase(" ", "\t", "\n")]
        [TestCase("\t", " ", "\n")]
        [TestCase("\n", "\t", " ")]
        public void InvalidInput_ReturnsInvalidTriangle3(string a, string b, string c)
        {
            // Arrange
            string sideA = " ";
            string sideB = "\t";
            string sideC = "\n";

            // Act
            Triangle triangle = TriangleCalculator.Program.CalculateTriangle(a, b, c);

            // Assert
            Assert.AreEqual(TriangleType.InvalidInput, triangle.Type);
            Assert.AreEqual(3, triangle.Vertices.Count);
            Assert.AreEqual((-2, -2), triangle.Vertices[0]);
            Assert.AreEqual((-2, -2), triangle.Vertices[1]);
            Assert.AreEqual((-2, -2), triangle.Vertices[2]);

        }
    }



    
}