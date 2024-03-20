using Microsoft.VisualStudio.TestTools.UnitTesting;
using webapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Legacy;
using webapi.Models.Domain;

namespace webapi.Services.Tests
{
    [TestClass()]
    public class ResultServiceTests
    {
        [TestMethod()]
        public void HasWinnerTest()
        {
            List<int> numbers = new < int > (13, 40, 15, 19, 6);
            Ticket t = new ( 1001, "string", "string", numbers );

            List<Ticket> tickets = {  };
            Result result = new()

            ResultService = new ResultService();
            ClassicAssert(  );
        }
    }
}