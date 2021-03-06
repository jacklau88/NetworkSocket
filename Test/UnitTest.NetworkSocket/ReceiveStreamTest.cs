﻿using NetworkSocket;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using NetworkSocket.Util;

namespace UnitTest.NetworkSocket
{


    /// <summary>
    ///这是 NsStreamTest 的测试类，旨在
    ///包含所有 NsStreamTest 单元测试
    ///</summary>
    [TestClass()]
    public class ReceiveStreamTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        // 
        //编写测试时，还可使用以下特性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Clear 的测试
        ///</summary>
        [TestMethod()]
        public void ClearTest()
        {
            NsStream target = new NsStream(); // TODO: 初始化为适当的值
            target.Write(new byte[] { 1, 2 }, 0, 2);
            target.Clear();
            Assert.IsTrue(target.Length == 0);
        }

        /// <summary>
        ///Clear 的测试
        ///</summary>
        [TestMethod()]
        public void ClearTest1()
        {
            NsStream target = new NsStream(); // TODO: 初始化为适当的值
            target.Write(new byte[] { 1, 2 }, 0, 2);
            int count = 1; // TODO: 初始化为适当的值
            target.Clear(count);
            Assert.IsTrue(target.Length == 1 && target[0] == 2);             
        }

        /// <summary>
        ///CopyTo 的测试
        ///</summary>
        [TestMethod()]
        public void CopyToTest()
        {
            NsStream target = new NsStream(); // TODO: 初始化为适当的值
            target.Write(new byte[] { 1, 2, 3, 4 }, 0, 4);
            byte[] dstArray = new byte[2]; // TODO: 初始化为适当的值
            int count = 2; // TODO: 初始化为适当的值
            target.CopyTo(dstArray, count);
            Assert.IsTrue(dstArray[0] == 1 && dstArray[1] == 2);
        }

        /// <summary>
        ///CopyTo 的测试
        ///</summary>
        [TestMethod()]
        public void CopyToTest1()
        {
            NsStream target = new NsStream(); // TODO: 初始化为适当的值
            target.Write(new byte[] { 1, 2, 3, 4 }, 0, 4);
            byte[] dstArray = new byte[3]; // TODO: 初始化为适当的值
            int dstOffset = 1; // TODO: 初始化为适当的值
            int count = 2; // TODO: 初始化为适当的值
            target.CopyTo(dstArray, dstOffset, count);
            Assert.IsTrue(dstArray[1] == 1 && dstArray[2] == 2);
        }

        /// <summary>
        ///CopyTo 的测试
        ///</summary>
        [TestMethod()]
        public void CopyToTest2()
        {
            NsStream target = new NsStream(); // TODO: 初始化为适当的值
            target.Write(new byte[] { 1, 2, 3, 4 }, 0, 4);
            int srcOffset = 2; // TODO: 初始化为适当的值
            byte[] dstArray = new byte[3]; ; // TODO: 初始化为适当的值
            int dstOffset = 1; // TODO: 初始化为适当的值
            int count = 2; // TODO: 初始化为适当的值
            target.CopyTo(srcOffset, dstArray, dstOffset, count);
            Assert.IsTrue(dstArray[1] == 3 && dstArray[2] == 4);
        }

        /// <summary>
        ///ReadArray 的测试
        ///</summary>
        [TestMethod()]
        public void ReadAndPositionTest()
        {
            NsStream target = new NsStream(); // TODO: 初始化为适当的值
            var bytes = new byte[]{
                1,
                3,
                0,1,
                0,0,0,1,
                0,0,0,0,0,0,0,5,
                255,
                255,255
            };
            target.Write(bytes, 0, bytes.Length);
            target.Position = 0;

            Assert.IsTrue(target.ReadBoolean() && target.Position == 1);
            Assert.IsTrue(target.ReadByte() == 3 && target.Position == 1 + 1);
            Assert.IsTrue(target.ReadInt16() == 1 && target.Position == 1 + 1 + 2);
            Assert.IsTrue(target.ReadInt32() == 1 && target.Position == 1 + 1 + 2 + 4);
            Assert.IsTrue(target.ReadInt64() == 5 && target.Position == 1 + 1 + 2 + 4 + 8);
            Assert.IsTrue(target.ReadArray(1)[0] == 255 && target.Position == 1 + 1 + 2 + 4 + 8 + 1);
            Assert.IsTrue(target.ReadArray().Length == 2 && target.Position == 1 + 1 + 2 + 4 + 8 + 1 + 2);
        }

        /// <summary>
        ///Item 的测试
        ///</summary>
        [TestMethod()]
        public void ItemTest()
        {
            NsStream target = new NsStream(); // TODO: 初始化为适当的值
            target.Write(new byte[] { 234 }, 0, 1);
            int index = 0; // TODO: 初始化为适当的值
            byte actual;
            actual = target[index];
            Assert.IsTrue(actual == 234);
        }

        [TestMethod()]
        public void IndexOfTest()
        {
            NsStream target = new NsStream(); // TODO: 初始化为适当的值
            var bytes = new byte[] { 2, 3, 4, 4 };
            target.Write(bytes, 0, bytes.Length);
            target.Position = 0;

            var actual = target.IndexOf(bytes);
            Assert.AreEqual(0, actual);

            var byte2 = new byte[] { 3, 4 };
            actual = target.IndexOf(byte2);
            Assert.AreEqual(1, actual);

            var byte3 = new byte[] { 3, 4, 5 };
            actual = target.IndexOf(byte3);
            Assert.AreEqual(-1, actual);

            var byte4 = new byte[] { 4 };
            actual = target.IndexOf(byte4);
            Assert.AreEqual(2, actual);

            var byte5 = new byte[] { 2, 3, 4, 4 };
            actual = target.IndexOf(byte5);
            Assert.AreEqual(0, actual);
            
            var byte6 = new byte[] { 2, 3, 4, 4,5 };
            actual = target.IndexOf(byte6);
            Assert.AreEqual(-1, actual);
        }
    }
}
