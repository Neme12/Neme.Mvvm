﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neme.Mvvm;

namespace Neme.Mvvm.Tests
{
    class NotifyBaseClass : NotifyBase
    {
        public new void RaisePropertyChanged(string propertyName)
        {
            base.RaisePropertyChanged(propertyName);
        }

        public new bool Set<T>(ref T field, T value, string propertyName)
        {
            return base.Set(ref field, value, propertyName);
        }

        public string GetCallerMemberName()
        {
            string field = null;
            string calledPropertyName = null;

            PropertyChanged += (sender, e) => calledPropertyName = e.PropertyName;

            base.Set(ref field, "value");
            return calledPropertyName;
        }
    }
}
