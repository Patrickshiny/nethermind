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

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Nethermind.Dirichlet.Numerics;

namespace Nethermind.Core.Json
{
    public class NullableUInt256Converter : JsonConverter<UInt256?>
    {
        private UInt256Converter _uInt256Converter;
        
        public NullableUInt256Converter()
            : this(NumberConversion.Hex)
        {
        }

        public NullableUInt256Converter(NumberConversion conversion)
        {
            _uInt256Converter = new UInt256Converter(conversion);
        }

        public override UInt256? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }
            
            return _uInt256Converter.Read(ref reader, typeToConvert, options);
        }

        public override void Write(Utf8JsonWriter writer, UInt256? value, JsonSerializerOptions options)
        {
            if (!value.HasValue)
            {
                writer.WriteNullValue();
                return;
            }
            
            _uInt256Converter.Write(writer, value.Value, options);
        }
    }
}