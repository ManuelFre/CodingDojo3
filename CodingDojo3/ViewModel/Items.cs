using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Einzubindende Elemente aus der Shared.dll (von Eckkrammer zur Verfügung gestellt) 
using Shared.BaseModels;
using Shared.Interfaces;
using Shared.Models;

namespace CodingDojo3.ViewModel
{
    public class Items : ViewModelBase
    {
        private ItemBase baseItem;                  //Klasse ItemBase aus der Shared.dll

        private int id;

        public int Id
        {
            get { return baseItem.Id; }
        }

        private String description;

        public String Description
        {
            get { return baseItem.Description; }
            set { baseItem.Description = value; RaisePropertyChanged(); }
        }

        private String name;

        public String Name
        {
            get { return baseItem.Name; }
            set { baseItem.Name = value; RaisePropertyChanged(); }
        }
        private string room;

        public string Room
        {
            get { return baseItem.Room; }
            set { baseItem.Room = value; RaisePropertyChanged(); }
        }
        private double posX;

        public int PosX
        {
            get { return baseItem.PosX; }
            set { baseItem.PosX = value; RaisePropertyChanged(); }
        }
        private double posY;

        public int PosY
        {
            get { return baseItem.PosY; }
            set { baseItem.PosY = value; RaisePropertyChanged(); }
        }

        public string ValueType
        {
            get
            {
                if (baseItem is ISensor)                        //ISensor aus der Shared.dll -> überprüft, ob mein Item ein SensorItem ist
                    return (baseItem as BaseSensor).SensorValueType.Name;
                else if (baseItem is IActuator)                 //IActuator aus der Shared.dll -> überprüft, ob mein Item ein ActuatorItem ist
                    return (baseItem as BaseActuator).ActuatorValueType.Name;
                else
                    throw new NotImplementedException();
            }

        }
        public Type ItemType
        {
            get
            {
                if (baseItem is ISensor)                        //ISensor aus der Shared.dll -> überprüft, ob mein Item ein SensorItem ist
                    return typeof(ISensor);                     //gibt den Datentyp (Sensor) zurück
                else if (baseItem is IActuator)                 //IActuator aus der Shared.dll -> überprüft, ob mein Item ein ActuatorItem ist
                    return typeof(IActuator);                   //gibt den Datentyp (Actuator) zurück
                else
                    throw new NotImplementedException();
            }

        }
        //private String mode;

        public String Mode
        {
            get
            {
                if (baseItem is BaseSensor)                        //Sensor aus der Shared.dll -> überprüft, ob mein Item ein SensorItem ist; Im Original wird auf IBaseSensor überprüft -> warum?
                    return (baseItem as BaseSensor).SensorMode.ToString();      //zuerst Typkonvertierung as BaseSensor, danach kann auf die Property des Sensors (sensormode) zugegriffen werden - davor ist basemode ja nur ein ItemBase
                else if (baseItem is IActuator)                 //IActuator aus der Shared.dll -> überprüft, ob mein Item ein ActuatorItem ist
                    return (baseItem as BaseActuator).ActuatorMode.ToString();
                else
                    throw new NotImplementedException();
            }
            set
            {
                if (baseItem is ISensor)
                    (baseItem as BaseSensor).SensorMode = (SensorModeType)Enum.Parse(typeof(SensorModeType), value, false);
                if (baseItem is IActuator)
                    (baseItem as BaseActuator).ActuatorMode = (ModeType)Enum.Parse(typeof(ModeType), value, false);

                RaisePropertyChanged();
            }
        }

        public object Value
        {
            get
            {
                if (baseItem is ISensor)
                    return (baseItem as BaseSensor).SensorValue;
                else if (baseItem is IActuator)
                    return (baseItem as BaseActuator).ActuatorValue;
                else
                    throw new NotImplementedException();
            }

            set
            {
                if (baseItem is ISensor) (baseItem as BaseSensor).SensorValue = value;
                else if (baseItem is IActuator) (baseItem as BaseActuator).ActuatorValue = value;
                else
                    throw new NotImplementedException();
                RaisePropertyChanged();

            }
        }



        public Items(ISensor sensor)
        {
            baseItem = sensor as ItemBase;
        }

        public Items(IActuator actuator)
        {
            baseItem = actuator as ItemBase;
        }


    }
}
