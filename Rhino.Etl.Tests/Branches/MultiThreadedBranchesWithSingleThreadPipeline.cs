﻿namespace Rhino.Etl.Tests.Branches
{
    using Rhino.Etl.Core;

    public class MultiThreadedBranchesWithSingleThreadPipeline : BranchesFixture
    {
        public MultiThreadedBranchesWithSingleThreadPipeline(TestDatabaseFixture testDatabase) 
            : base(testDatabase)
        { }

        protected override EtlProcess CreateBranchingProcess(int iterations, int childOperations)
        {
            return new MultiThreadedWithSingleThreadPipelineFibonacciBranchingProcess(TestDatabase.ConnectionStringName, iterations, childOperations);
        }
    }
}