using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Carlen
{
    public class BaseTime : INotifyPropertyChanged
    {
        private int _Time;
        public int Time { get => _Time; set { _Time = value; OnValueChanged(); } }

        private bool _ItemIsSelected;
        public bool ItemIsSelected { get => _ItemIsSelected; set { _ItemIsSelected = value; OnValueChanged(); OnSelecChanged?.Invoke(this); } }

        private bool _IsChangTemplate;
        public bool IsChangTemplate { get => _IsChangTemplate; set { _IsChangTemplate = value; OnValueChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnValueChanged([CallerMemberName]string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public Action<BaseTime> OnSelecChanged;

        private ShowMode _ShowMode = ShowMode.None;

        public ShowMode BackGroundShowMode
        {
            get => _ShowMode;
            set
            {
                _ShowMode = value;
                OnValueChanged();
            }
        }
    }
}
