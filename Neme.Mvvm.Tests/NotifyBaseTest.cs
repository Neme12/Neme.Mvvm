﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Neme.Mvvm.Tests
{
    [TestClass]
    public class NotifyBaseTest
    {
        private readonly NotifyBaseClass notifyClass = new NotifyBaseClass();

        [TestMethod]
        public void TestRaisePropertyChanged()
        {
            notifyClass.RaisePropertyChanged("Property");

            int timesCalled = 0;
            string calledPropertyName = null;

            notifyClass.PropertyChanged += (sender, e) => {
                Assert.AreEqual(notifyClass, sender);
                Assert.IsNotNull(e);
                calledPropertyName = e.PropertyName;
                timesCalled += 1;
            };

            notifyClass.RaisePropertyChanged("Property1");
            Assert.AreEqual(1, timesCalled);
            Assert.AreEqual("Property1", calledPropertyName);

            notifyClass.RaisePropertyChanged("Property2");
            Assert.AreEqual(2, timesCalled);
            Assert.AreEqual("Property2", calledPropertyName);
        }

        [TestMethod]
        public void TestSetProperty()
        {
            string field = null;
            notifyClass.Set(ref field, "oldValue", "Property");
            Assert.AreEqual("oldValue", field);

            string calledPropertyName = null;

            notifyClass.PropertyChanged += (sender, e) => {
                calledPropertyName = e.PropertyName;
                Assert.AreEqual("newValue", field);
            };

            var result = notifyClass.Set(ref field, "newValue", "Property");
            Assert.AreEqual("Property", calledPropertyName);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SetProperty_EqualValueDoesNotRaise()
        {
            string field = "value";
            bool called = false;

            notifyClass.PropertyChanged += (sender, e) => called = true;

            var result = notifyClass.Set(ref field, "value", "Property");
            Assert.IsFalse(called);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SetProperty_TestCallerMemberName()
        {
            var result = notifyClass.GetCallerMemberName();
            Assert.AreEqual("GetCallerMemberName", result);
        }
    }
}
