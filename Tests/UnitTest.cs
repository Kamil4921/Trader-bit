﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TraderLibrary;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            ApiHelper.InitializeClient();
            List<int> numbers = new List<int> { 1, 26, 70, 5 };
            List<Type> expected = new List<Type> { typeof(TradeModel[]), typeof(TradeModel[]), typeof(TradeModel[]), typeof(TradeModel[]) };
            List<Type> actual = new List<Type>();

            for(int i= 0; i < 4; i++)
            {
                var trades = await TradeProcessor.LoadTrades(numbers[i]);
                actual.Add(trades.GetType());
            }

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
