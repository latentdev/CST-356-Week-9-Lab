using RestAPIClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RestAPIClient.Network;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RestAPIClient
{

    public enum CRUD { GET,POST,PUT,DELETE };
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private String mAddress;
        private String mContentToSend;
        private ObservableCollection<User> mOutput;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<ComboItem>Methods { get; private set; }
        public String Address
        {
            get => mAddress;
            set
            {
                mAddress = value;
                NotifyPropertyChanged(nameof(Address));
            }
        }
        public String ContentToSend
        {
            get => mContentToSend;
            set
            {
                mContentToSend = value;
                NotifyPropertyChanged(nameof(ContentToSend));
            }
        }
        public ObservableCollection<User> Output
        {
            get => mOutput;
            set
            {
                mOutput = value;
                NotifyPropertyChanged(nameof(Output));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Methods = new List<ComboItem>();
            Methods.Add(new ComboItem("GET",(int)CRUD.GET));
            Methods.Add(new ComboItem("POST", (int)CRUD.POST));
            Methods.Add(new ComboItem("PUT", (int)CRUD.PUT));
            Methods.Add(new ComboItem("DELETE", (int)CRUD.DELETE));
            cmb.ItemsSource = Methods;
            cmb.SelectedIndex = 0;
        }

        private async void Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            var item = (ComboItem)cmb.SelectedItem;
            switch (item.Name)
            {
                case "GET":
                    {
                        Output = await Network.Network.Get(Address);
                        break;
                    }
                case "POST":
                    {
                        Output = await Network.Network.Post(Address, ContentToSend);
                        break;
                    }
                case "PUT":
                    {
                        Output = await Network.Network.Put(Address, ContentToSend);
                        break;
                    }
                case "Delete":
                    {
                        Output = await Network.Network.Delete(Address);
                        break;
                    }
                default:
                    break;
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
