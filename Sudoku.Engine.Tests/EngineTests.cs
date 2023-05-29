using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Engine.Tests
{
  internal class EngineTests
  {
    [SetUp]
    public void Setup()
    {
    }

    [TearDown]
    public void TearDown() { }

    [Test]
    public void EngineCtorWithoutParameters()
    {
      var engine = new Engine();
      Assert.IsNotNull(engine);
    }
  }
}
