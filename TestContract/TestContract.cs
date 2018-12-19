﻿using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract.Framework.Services.System;
using System.Numerics;
using Helper = Neo.SmartContract.Framework.Helper;

namespace TestContract
{
    public class TestContract : SmartContract
    {
        public static object Main(string method, object[] args)
        {
            var magicstr = "Test_Contract_v0.32";
            if (Runtime.Trigger == TriggerType.Verification)
            {
                return false;
            }

            if (Runtime.Trigger == TriggerType.VerificationR)
            {
                return true;
            }

            if (Runtime.Trigger == TriggerType.Application)
            {
                var callscript = ExecutionEngine.CallingScriptHash;
                if (method == "test")
                    return 1;
                if (method == "call")
                    return "yes";
                if (method == "getheight")
                    return Blockchain.GetHeight();
                if (method == "getheader")
                {
                    var height = (uint)args[0];
                    return Blockchain.GetHeader(height);
                }

                if (method == "name")
                {
                    byte[] asset_id = (byte[])args[0];
                    return NativeAsset.Name(asset_id);
                }

                if (method == "symbol")
                {
                    byte[] asset_id = (byte[])args[0];
                    return NativeAsset.Symbol(asset_id);
                }

                if (method == "decimals")
                {
                    byte[] asset_id = (byte[])args[0];
                    return NativeAsset.Decimals(asset_id);
                }

                if (method == "totalSupply")
                {
                    byte[] asset_id = (byte[])args[0];
                    return NativeAsset.TotalSupply(asset_id);
                }

                if (method == "balanceOf")
                {
                    byte[] asset_id = (byte[])args[0];
                    byte[] address = (byte[])args[1];
                    return NativeAsset.BalanceOf(asset_id, address);
                }

                if (method == "transfer")
                {
                    byte[] asset_id = (byte[])args[0];
                    byte[] from = (byte[])args[1];
                    byte[] to = (byte[])args[2];
                    BigInteger value = (BigInteger)args[3];
                    return NativeAsset.Transfer(asset_id, from, to, value);
                }

                if (method == "transfer_app")
                {
                    byte[] asset_id = (byte[])args[0];
                    byte[] from = ExecutionEngine.ExecutingScriptHash;
                    byte[] to = (byte[])args[1];
                    BigInteger value = (BigInteger)args[2];
                    return NativeAsset.TransferApp(asset_id, from, to, value);
                }

                if (method == "gettxfrom")
                {
                    byte[] asset_id = (byte[])args[0];
                    byte[] txid = (byte[])args[1];
                    return NativeAsset.GetTransferState(asset_id, txid).From;
                }

                if (method == "gettxto")
                {
                    byte[] asset_id = (byte[])args[0];
                    byte[] txid = (byte[])args[1];
                    return NativeAsset.GetTransferState(asset_id, txid).To;
                }

                if (method == "gettxvalue")
                {
                    byte[] asset_id = (byte[])args[0];
                    byte[] txid = (byte[])args[1];
                    return NativeAsset.GetTransferState(asset_id, txid).Value;
                }

                if (method == "gettxstate")
                {
                    byte[] asset_id = (byte[])args[0];
                    byte[] txid = (byte[])args[1];
                    return NativeAsset.GetTransferState(asset_id, txid);
                }

                if (method == "gettxstate1")
                {
                    byte[] asset_id = (byte[])args[0];
                    byte[] txid = (byte[])args[1];
                    return NativeAsset.GetTransferState(asset_id, txid).Serialize();
                }

                if (method == "gettxstate2")
                {
                    byte[] asset_id = (byte[])args[0];
                    byte[] txid = (byte[])args[1];
                    return NativeAsset.GetTransferState(asset_id, txid) as TransferState;
                }

                if (method == "gettxstate3")
                {
                    byte[] asset_id = (byte[])args[0];
                    byte[] txid = (byte[])args[1];
                    return ExecutionEngine.ScriptContainer as TransferState;
                }

                if (method == "gettxstate4")
                {
                    byte[] asset_id = (byte[])args[0];
                    byte[] txid = (byte[])args[1];
                    return ExecutionEngine.ScriptContainer;
                }

            }

            return false;
        }

    }
}
