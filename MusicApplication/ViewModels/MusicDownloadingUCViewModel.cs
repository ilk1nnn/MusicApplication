using MusicApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace MusicApplication.ViewModels
{
    public class MusicDownloadingUCViewModel : BaseViewModel
    {
		private Music music;

		public Music Music
		{
			get { return music; }
			set { music = value; OnPropertyChanged(); }
		}


        private string status;

        public string Status
        {
            get { return status; }
            set { status = value; OnPropertyChanged(); }
        }
        public DispatcherTimer Timer { get; set; }

        private int second;

        public int Second
        {
            get { return second; }
            set { second = value; OnPropertyChanged(); }
        }


        private int minute;

        public int Minute
        {
            get { return minute; }
            set { minute = value; OnPropertyChanged(); }
        }

        public void StopTimer()
        {
            Timer.Stop();
        }

        public Thread _task { get; set; }


        public MusicDownloadingUCViewModel(Music music,Thread task)
        {
            _task = task;
            Timer = new DispatcherTimer();
            Second = 0;
            Minute = 0;
            Music = music;
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Tick += IncreaseSeconds;
            Timer.Start();
            Status = "Downloading ...";
        }

        private void IncreaseSeconds(object sender, EventArgs e)
        {
            Second += 1;
            if (Second == 60)
            {
                Second = 0;
                Minute += 1;
            }
        }
    }
}
