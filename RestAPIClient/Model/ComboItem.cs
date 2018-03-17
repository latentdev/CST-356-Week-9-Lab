using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIClient.Model
{
    public class ComboItem:INotifyPropertyChanged
    {
        private String mName;
        public String Name
        {
            get => mName;
            set
            {
                mName = value;
                NotifyPropertyChanged(nameof(Name));
            }
        }
        public int Type { get; set; }

        public ComboItem(String name, int type)
        {
            Name = name;
            Type = type;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
