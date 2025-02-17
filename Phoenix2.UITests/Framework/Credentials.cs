using NUnit.Framework;
using System;

namespace Phoenix2.UITests.Framework
{
    class Credentials
    {
        public static string TestingMode = TestContext.Parameters["TestingMode"];
        public static string EnvironmentURL = TestContext.Parameters["EnvironmentURL"];
        public static string AdminLogin = TestContext.Parameters["AdminLogin"];
        public static string AdminPassword = TestContext.Parameters["AdminPassword"];
        public static string LCLogin = TestContext.Parameters["AdminPassword"];
        public static string DocGen2Login = TestContext.Parameters["DocGen2Login"];
        public static string DocGen2Password = TestContext.Parameters["DocGen2Password"];
    }
}
