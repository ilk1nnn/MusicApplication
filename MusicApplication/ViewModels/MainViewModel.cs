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
                    MusicDownloadingUC musicDownloadingUC = new MusicDownloadingUC();
                    MusicDownloadingUCViewModel musicDownloadingUCViewModel = new MusicDownloadingUCViewModel(musicViewModel.Music, task);
                    musicDownloadingUC.DataContext = musicDownloadingUCViewModel;
                    musicViewModel.Music.Name = musicWindow.nametxtb.Text;
                    musicViewModel.Music.Url = musicWindow.urltxtb.Text;
                    musicViewModel.Music.Path = musicWindow.pathTxtb.Text;
                    musicDownloadingUC.urltxtb.Text = musicViewModel.Music.Url;
                    musicDownloadingUC.filenametxtb.Text = musicViewModel.Music.Name;
                    musicDownloadingUC.pathtxtb.Text = musicViewModel.Music.Path;
                    myWrapPanel.Children.Add(musicDownloadingUC);
                    MusicService.SaveMP3(musicDownloadingUCViewModel, task);
                    
                }
            });
        }

    }
}
