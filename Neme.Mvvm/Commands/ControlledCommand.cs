﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Neme.Mvvm.Commands
{
    public class ControlledCommand : ControlledCommandShared
    {
        private readonly Action execute;

        public ControlledCommand(Action execute, bool isEnabled)
            : base(isEnabled)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));

            this.execute = execute;
        }

        // ICommand

        public override void Execute(object parameter)
        {
            execute();
        }
    }
}
