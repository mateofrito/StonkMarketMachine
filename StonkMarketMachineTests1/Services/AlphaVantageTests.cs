using Microsoft.VisualStudio.TestTools.UnitTesting;
using StonkMarketMachine;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

namespace StonkMarketMachine.Tests
{
    [TestClass()]
    public class AlphaVantageTests
    {
        [TestMethod()]
        public void InitializeAlphaVantage()
        {
            AlphaVantage alphaVantage = new AlphaVantage();

            string apiKey = System.Environment.GetEnvironmentVariable("ALPHAVANTAGE_TOKEN");

            Assert.AreEqual(alphaVantage.apiKey, apiKey);


        }

        [TestMethod()]
        public void IntraDayQuoteTest()
        {
            AlphaVantage alphaVantage = new AlphaVantage();
            string quote = alphaVantage.IntraDayQuote("IBM", "5");
            Trace.WriteLine(quote);
        }
    }
}