using EndPointManager.Controller;
using EndPointManager.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EndPointManager.Enums.Enumerators;

namespace Testes
{
    [TestClass]
    public class EndPointTests
    {
        private readonly Meter _meter = new Meter((int) MeterModel.NSX1P2W, 16, "abc", (int) SwitchState.Disconnected);
        private readonly Meter _meterinvalid = new Meter(50, 16, "abc", (int)SwitchState.Disconnected);
        private readonly Endpoint _endpoint = new Endpoint("1", new Meter((int)MeterModel.NSX1P2W, 16, "abc", (int)SwitchState.Disconnected));
        private readonly EndpointController _endpointcontroller = new EndpointController();
        [TestMethod]
        public void InsertNewEndpoint()
        {
            _endpointcontroller.Create(_endpoint);
            Assert.AreEqual(1, _endpointcontroller.endpoints.Count);
        }

        [TestMethod]
        public void InsertValidMeter()
        {
            bool valid = _meter.IsValid();
            Assert.AreEqual(true, valid);
            
        }

        [TestMethod]
        public void InsertInvalidMeter()
        {
            bool valid = _meterinvalid.IsValid();
            Assert.AreNotEqual(true, valid);

        }
        [TestMethod]
        public void DeleteConfirmEndpoint()
        {
            _endpointcontroller.Create(_endpoint);
            _endpointcontroller.Delete(_endpoint, "y");
            Assert.AreEqual(0, _endpointcontroller.endpoints.Count);


        }
        [TestMethod]
        public void DeleteNotConfirmEndpoint()
        {
            _endpointcontroller.Create(_endpoint);
            _endpointcontroller.Delete(_endpoint, "n");
            Assert.AreEqual(1, _endpointcontroller.endpoints.Count);

        }
    }
}
