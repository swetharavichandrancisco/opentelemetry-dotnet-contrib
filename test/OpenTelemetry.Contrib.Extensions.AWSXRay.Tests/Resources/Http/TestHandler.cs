﻿// <copyright file="TestHandler.cs" company="OpenTelemetry Authors">
// Copyright The OpenTelemetry Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

using OpenTelemetry.Contrib.Extensions.AWSXRay.Resources.Http;
using Xunit;

namespace OpenTelemetry.Contrib.Extensions.AWSXRay.Tests.Resources.Http
{
    [Trait("Platform", "Any")]
    public class TestHandler
    {
        private const string CRTNAME = "cert";
        private const string INVALIDCRTNAME = "invalidcert";

        [Fact]
        public void TestValidHandler()
        {
            // Creates a self-signed certificate
            CertificateUtil.CreateCertificate(CRTNAME);

            // Validates if the handler created.
            Assert.NotNull(Handler.Create(CRTNAME));

            // Deletes the certificate
            CertificateUtil.DeleteCertificate(CRTNAME);
        }

        [Fact]
        public void TestInValidHandler()
        {
            // Validates if the handler created if no certificate is loaded into the trusted collection
            Assert.Null(Handler.Create(INVALIDCRTNAME));
        }
    }
}
