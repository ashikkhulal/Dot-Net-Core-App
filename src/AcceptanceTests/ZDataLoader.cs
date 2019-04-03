﻿using System;
using ClearMeasure.OnionDevOpsArchitecture.Core.Model;
using ClearMeasure.OnionDevOpsArchitecture.IntegrationTests;
using NUnit.Framework;

namespace ClearMeasure.OnionDevOpsArchitecture.AcceptanceTests
{
    [TestFixture]
    public class ZDataLoader
    {
        [Test, Category("DataLoader"), Explicit]
        public void LoadLocalData()
        {
            new IntegrationTests.ZDataLoader().LoadLocalData();
        }
    }
}