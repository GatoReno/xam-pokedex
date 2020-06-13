using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;

namespace PokedexUITest.UITest
{
    [TestFixture(Platform.Android)]

    public class Tests
    {
        protected IApp app;
        protected Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        //[Test]
        public void LaunchREPLTool()
        {
            app.Repl();
        }       
    }
}
