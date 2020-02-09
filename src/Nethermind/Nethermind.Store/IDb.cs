//  Copyright (c) 2018 Demerzel Solutions Limited
//  This file is part of the Nethermind library.
// 
//  The Nethermind library is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  The Nethermind library is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU Lesser General Public License for more details.
// 
//  You should have received a copy of the GNU Lesser General Public License
//  along with the Nethermind. If not, see <http://www.gnu.org/licenses/>.

using System;

namespace Nethermind.Store
{
    public interface IDb : IDisposable
    {
        string Name { get; }
        byte[] this[byte[] key] { get; set; }
        byte[][] GetAll();
        void StartBatch();
        void CommitBatch();
        void Remove(byte[] key);
        bool KeyExists(byte[] key);

        /// <summary>
        /// For nested DB structures returns the innermost one
        /// </summary>
        public IDb Innermost { get; }
    }

    public interface IDbWithSpan : IDisposable
    {
        Span<byte> GetSpan(byte[] key);
        void DangerousReleaseMemory(in Span<byte> span);
    }
}