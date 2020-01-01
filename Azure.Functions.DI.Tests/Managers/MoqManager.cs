﻿using Microsoft.AspNetCore.Http;
using Moq;
using Newtonsoft.Json;
using System.IO;

namespace Azure.Functions.DI.Tests.Managers
{
    public class MoqManager
    {
        public Mock<HttpRequest> CreateMockRequest(object body)
        {
            var ms = new MemoryStream();
            var sw = new StreamWriter(ms);

            var json = JsonConvert.SerializeObject(body);

            sw.Write(json);
            sw.Flush();

            ms.Position = 0;

            var mockRequest = new Mock<HttpRequest>();
            mockRequest.Setup(x => x.Body).Returns(ms);

            return mockRequest;
        }
    }
}
