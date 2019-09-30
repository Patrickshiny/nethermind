/*
 * Copyright (c) 2018 Demerzel Solutions Limited
 * This file is part of the Nethermind library.
 *
 * The Nethermind library is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * The Nethermind library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with the Nethermind. If not, see <http://www.gnu.org/licenses/>.
 */

using System.Text.Json;
using Nethermind.Core.Crypto;
using Nethermind.Core.Json;
using Nethermind.Core.Json.Converters;
using NUnit.Framework;

namespace Nethermind.Core.Test.Json
{
    public class PublicKeyConverterTests
    {
        [Test]
        public void Can_read_null()
        {
            PublicKeyConverter converter = new PublicKeyConverter();
            Utf8JsonReader reader = new Utf8JsonReader(System.Text.Encoding.UTF8.GetBytes(""));
            reader.Read();
            PublicKey result = converter.Read(ref reader, typeof(PublicKey), null);
            Assert.AreEqual(null, result);
        }
    }
}