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

        public new void SetProperty<T>(ref T field, T value, string propertyName)
        {
            base.SetProperty(ref field, value, propertyName);
        }

        public string GetCallerMemberName()
        {
            string field = null;
            string calledPropertyName = null;

            PropertyChanged += (sender, e) => calledPropertyName = e.PropertyName;

            base.SetProperty(ref field, "value");
            return calledPropertyName;
        }
    }
}
