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

using Nethermind.Core.Crypto;
using Nethermind.Evm.Tracing;
using Nethermind.JsonRpc.DataModel;

namespace Nethermind.JsonRpc.Module
{
    public interface ITraceModule : IModule
    {
        ResultWrapper<ParityLikeTxTrace> trace_call(Transaction message, string[] traceTypes, BlockParameter numberOrTag);
        ResultWrapper<ParityLikeTxTrace[]> trace_callMany((Transaction message, string[] traceTypes, BlockParameter numberOrTag)[] calls);
        ResultWrapper<ParityLikeTxTrace> trace_rawTransaction(byte[] data, string[] traceTypes);
        ResultWrapper<ParityLikeTxTrace> trace_replayTransaction(Keccak txHash, string[] traceTypes);
        ResultWrapper<ParityLikeTxTrace[]> trace_replayBlockTransactions(BlockParameter numberOrTag, string[] traceTypes);
        
//        ResultWrapper<ParityLikeTxTrace[]> trace_filter();
//        ResultWrapper<ParityLikeTxTrace[]> trace_block(BlockParameter numberOrTag);
//        ResultWrapper<ParityLikeTxTrace> trace_get(Data txHash, int[] positions);
//        ResultWrapper<ParityLikeTxTrace> trace_transaction(Data transactionHash);
    }
}