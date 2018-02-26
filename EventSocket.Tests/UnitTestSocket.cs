using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Sockets;
using System.Threading;

namespace EventSocket.Tests
{
    [TestClass]
    public class UnitTestSocket
    {

        private TestContext testContextInstance;

        /// <summary>
        ///  Gets or sets the test context which provides
        ///  information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod]
        public void ConnectTestMethod()
        {
            var socket = new ClientEventSocket();
            socket.OnConnected += OnConnected;
            socket.OnDisconnected += OnDisconnected;
            socket.OnReceived += OnReceived;
            socket.OnSended += OnSended;
            socket.OnError += OnError;

            bool result = socket.Connect("127.0.0.1", 23);
            if (!result) Assert.Fail();

            result = socket.Send("Simple");
            if (!result) Assert.Fail();

            result = socket.SendEof("Simple", ';');
            if (!result) Assert.Fail();


            //Wait for you send some data from your tcp server
            TestContext.WriteLine("Wait for you send some data from your tcp server...");
            Thread.Sleep(5000);

            result = socket.Disconnect();
            Assert.IsTrue(result);
        }

        private void OnConnected(object sender, string Message)
        {
            var socket = (Socket)sender;
            TestContext.WriteLine(string.Format("Socket {0} Say On Conneted: ", socket.ToString(), Message));
        }
        private void OnDisconnected(object sender, string Message)
        {
            var socket = (Socket)sender;
            TestContext.WriteLine(string.Format("Socket {0} Say On Disconnected: ", socket.ToString(), Message));
        }
        private void OnReceived(object sender, string Message)
        {
            var socket = (Socket)sender;
            TestContext.WriteLine(string.Format("Socket {0} Say On Received: ", socket.ToString(), Message));
        }
        private void OnSended(object sender, string Message)
        {
            var socket = (Socket)sender;
            TestContext.WriteLine(string.Format("Socket {0} Say On Sended: ", socket.ToString(), Message));
        }
        private void OnError(object sender, string Message)
        {
            var socket = (Socket)sender;
            TestContext.WriteLine(string.Format("Socket {0} Say On Error: ", socket.ToString(), Message));
        }

    }
}
