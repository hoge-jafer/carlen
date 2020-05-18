using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Carlen
{
    public class ClickCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter != null)
                Action?.Invoke(parameter);
            else
                NoParameterAction?.Invoke();
        }
        private Action NoParameterAction;
        private Action<object> Action;
        public ClickCommand(Action<object> acion)
        {
            this.Action = acion;
        }
        public ClickCommand(Action action)
        {
            this.NoParameterAction = action;
        }
    }

    public enum BaseDateTime
    {
        周一,
        周二,
        周三,
        周四,
        周五,
        周六,
        周日,
    }
    public enum ShowMode
    {
        Left,
        Right,
        Both,
        None
    }
}
