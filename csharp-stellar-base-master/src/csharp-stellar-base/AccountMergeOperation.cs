﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Stellar.Preconditions;

namespace Stellar
{   
    public class AccountMergeOperation : Operation
    {
        public KeyPair Destination { get; private set; }

        private AccountMergeOperation(KeyPair destination)
        {
            Destination = CheckNotNull(destination, "destination cannot be null.");
        }

        //public override OperationThreshold Threshold
        //{
        //    get => OperationThreshold.High;
        //}

        public override Generated.Operation.OperationBody ToOperationBody()
        { 
            var body = new Generated.Operation.OperationBody
            {
                Destination = Destination.AccountId,
                Discriminant = Generated.OperationType.Create(Generated.OperationType.OperationTypeEnum.ACCOUNT_MERGE)
            };

            return body;
        }

        public class Builder
        {
            public KeyPair SourceAccount { get; private set; }
            private readonly KeyPair Destination;            

            public Builder(Generated.CreateAccountOp op)
            {
                Destination = KeyPair.FromXdrPublicKey(op.Destination.InnerValue);
            }

            public Builder(KeyPair destination)
            {
                Destination = CheckNotNull(destination, "destination cannot be null.");               
            }

            public Builder SetSourceAccount(KeyPair sourceAccount)
            {
                SourceAccount = CheckNotNull(sourceAccount, "sourceAccount cannot be null.");
                return this;
            }           

            public AccountMergeOperation Build()
            {
                var operation = new AccountMergeOperation(Destination);
                if (SourceAccount != null)
                    operation.SourceAccount = SourceAccount;
                return operation;
            }
        }
    }
}