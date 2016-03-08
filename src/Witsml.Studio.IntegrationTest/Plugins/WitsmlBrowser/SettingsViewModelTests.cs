﻿using System;
using Energistics.DataAccess;
using Energistics.DataAccess.WITSML141;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PDS.Witsml.Studio.Plugins.WitsmlBrowser.ViewModels;
using PDS.Witsml.Studio.Plugins.WitsmlBrowser.ViewModels.Request;
using PDS.Witsml.Studio.Runtime;
using PDS.Witsml.Studio.ViewModels;

namespace PDS.Witsml.Studio.Plugins.WitsmlBrowser
{
    [TestClass]
    public class SettingsViewModelTests
    {
        const string _validWitsmlUri = "http://localhost/Witsml.Web/WitsmlStore.svc";
        private BootstrapperHarness _bootstrapper;
        private TestRuntimeService _runtime;
        private SettingsViewModel _settingsViewModel;

        [TestInitialize]
        public void TestSetUp()
        {
            _bootstrapper = new BootstrapperHarness();
            _runtime = new TestRuntimeService(_bootstrapper.Container);
            _runtime.Shell = new ShellViewModel(_runtime);
            _settingsViewModel = new SettingsViewModel(_runtime);
        }

        [TestMethod]
        public void TestSettingsViewModelGetVersions()
        {
            WITSMLWebServiceConnection proxy = new WITSMLWebServiceConnection(_validWitsmlUri, WMLSVersion.WITSML141);
            var versions = _settingsViewModel.GetVersions(proxy, _validWitsmlUri);
            Assert.IsTrue(!string.IsNullOrEmpty(versions));
        }
    }
}
