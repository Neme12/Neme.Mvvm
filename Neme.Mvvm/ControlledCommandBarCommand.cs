﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neme.Mvvm
{
    public class ControlledCommandBarCommand : IControlledCommandBarCommand
    {
        private readonly Action execute;
        private Availability availibility;

        public ControlledCommandBarCommand(Action execute, Availability availibility)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            this.execute = execute;
            this.availibility = availibility;
        }

        private void RaiseAvailabilityChanged()
        {
            var handler = AvailabilityChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        // IControlledCommandBarCommand

        public Availability Availability
        {
            get { return availibility; }
            set { availibility = value; RaiseAvailabilityChanged(); }
        }

        // ICommandBarCommand

        public void Execute()
        {
            execute();
        }

        public event EventHandler AvailabilityChanged;
    }
}