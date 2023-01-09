using MusicApplication.Commands;
using MusicApplication.Service;
using MusicApplication.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        public bool isClickedMain { get; set; } = false;


        public MainViewModel()
        {
            PlusButtonCommand = new RelayCommand(p =>
            {
                MusicWindow musicWindow = new MusicWindow();
                MusicViewModel musicViewModel = new MusicViewModel(musicWindow);
                musicWindow.pathTxtb.Text = musicViewModel.Path;
                musicWindow.DataContext = musicViewModel;
                musicWindow.ShowDialog();
                if (musicViewModel.IsClicked)
                {
                    Thread task = null;
                    MusicDownloadingUCViewModel musicDownloadingUCViewModel = new MusicDownloadingUCViewModel(musicViewModel.Music, task);
                    MusicDownloadingUC musicDownloadingUC = new MusicDownloadingUC();
                    musicDownloadingUC.DataContext = musicDownloadingUCViewModel;
                    myWrapPanel.Children.Add(musicDownloadingUC);
                    //MusicService.SaveMP3(musicDownloadingUCViewModel, task);

                }
            });
        }

    }
}
