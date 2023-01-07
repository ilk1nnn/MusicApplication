using MusicApplication.Commands;
using MusicApplication.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MusicApplication.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public RelayCommand PlusButtonCommand { get; set; }

        private WrapPanel myWrapPanel;

        public WrapPanel MyWrapPanel
        {
            get { return myWrapPanel; }
            set { myWrapPanel = value; OnPropertyChanged(); }
        }




        public MainViewModel()
        {
            PlusButtonCommand = new RelayCommand(p =>
            {
                var view = new MusicDownloadingUC();
                view.Margin = new Thickness(10, 10, 0, 0);
                MyWrapPanel.Children.Add(view);
            });
        }

    }
}
