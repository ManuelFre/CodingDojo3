using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Shared.Interfaces;
using Simulation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Threading;

namespace CodingDojo3.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// 
        private List<Items> modelItems = new List<Items>();
        public ObservableCollection<Items> SensorList { get; set; }
        public ObservableCollection<Items> ActorList { get; set; }
        public ObservableCollection<string> ModeSelectionList { get; private set; }
        private DateTime myDate;

        public DateTime MyDate
        {
            get { return myDate; }
            set { myDate = value; RaisePropertyChanged("MyDate"); }                     //View ist über MyDate mit dem ModelView "verbunden"; Mithilfe des raiseproperty bekommt die View eine Änderung mitgeteilt.
        }

        private Simulator sim;
        DispatcherTimer dt = new System.Windows.Threading.DispatcherTimer();            //Erstellt einen Timer für die Uhrzeit
        public MainViewModel()
        {
            SensorList = new ObservableCollection<Items>();
            ActorList = new ObservableCollection<Items>();
            ModeSelectionList = new ObservableCollection<string>();

            dt.Tick += Dt_Tick;                                                         //Dt_Tick entspricht einem Event, welches unten erstellt wurde; Dieses Event wird bei jedem Tick ausgelöst
            dt.Interval = new TimeSpan(0, 0, 1);                                        //TimeSpan erstellt einen Zeitabstand, welcher als Tick-Auslöser übernommen wird
            dt.Start();
            LoadData();
        }

        private void LoadData()
        {
            Simulator sim = new Simulator(modelItems);
            foreach (var item in sim.It)
            {
                if (item.ItemType.Equals(typeof(ISensor)))
                    SensorList.Add(item);
                else if (item.ItemType.Equals(typeof(IActuator)))
                    ActorList.Add(item);
            }

        }


        private void Dt_Tick(object sender, EventArgs e)
        {
            MyDate = DateTime.Now;                                                      //Ruft das Set der PRoperty auf
        }

        /*private void NowChangeTime()
        {
            myDate = DateTime.Now;
        }*/


        
    }
}