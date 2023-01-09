using MusicApplication.Commands;
using MusicApplication.Models;
using MusicApplication.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MusicApplication.ViewModels
{
    public class MusicViewModel : BaseViewModel
    {

        private Music music;

        public Music Music
        {
            get { return music; }
            set { music = value; OnPropertyChanged(); }
        }

        private string path;

        public string Path
        {
            get { return path; }
            set { path = value; Music.Path = value; OnPropertyChanged(); }
        }

        public RelayCommand DownloadMusicCommand { get; set; }


        private MusicWindow _musicWindow { get; set; }

        public bool IsClicked { get; set; } = false;

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }



        private string url;

        public string Url
        {
            get { return url; }
            set { url = value; OnPropertyChanged(); }
        }




        public MusicViewModel(MusicWindow musicWindow)
        {
            Music = new Music();
            Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";
            _musicWindow = musicWindow;
            DownloadMusicCommand = new RelayCommand(d =>
            {
                try
                {
                    IsClicked = true;
                    Music.Name = Name;
                    Music.Url = Url;
                    Music.Path = Path;
                    _musicWindow.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });

        }


    }
}
