using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
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
        private DateTime myDate;

        public DateTime MyDate
        {
            get { return myDate; }
            set { myDate = value; RaisePropertyChanged("MyDate"); }                     //View ist über MyDate mit dem ModelView "verbunden"; Mithilfe des raiseproperty bekommt die View eine Änderung mitgeteilt.
        }

        DispatcherTimer dt = new System.Windows.Threading.DispatcherTimer();            //Erstellt einen Timer für die Uhrzeit

        public MainViewModel()
        {
            dt.Tick += Dt_Tick;                                                         //Dt_Tick entspricht einem Event, welches unten erstellt wurde; Dieses Event wird bei jedem Tick ausgelöst
            dt.Interval = new TimeSpan(0, 0, 1);                                        //TimeSpan erstellt einen Zeitabstand, welcher als Tick-Auslöser übernommen wird
            dt.Start();
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