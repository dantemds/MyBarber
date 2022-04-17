using Mybarber.Services;
using NUnit.Framework;

namespace TDD
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {




         var result =    GerarHorarioServices.RetornaHorario();

            Assert.Pass();
          
        }
    

        }
    }
