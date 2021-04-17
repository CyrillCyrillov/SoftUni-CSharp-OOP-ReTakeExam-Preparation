using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private string name;
        
        

        //HashSet<string> existingDrivers = new HashSet<string>();


        public Driver(string name)
        {
            Name = name;
        }


        public string Name
        {
            get
            {
                return Name;
            }

            private set
            {
                if(string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, 5));
                }

                /*
                if(existingDrivers.Contains(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, value));
                }
                */

                name = value;
                //existingDrivers.Add(name);
            }


        }

        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate
        {
            get
            {
                return Car != null;
            }
        }

        public void AddCar(ICar car)
        {
            if(car == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarInvalid));
            }

            Car = car;
        }

        public void WinRace()
        {
            NumberOfWins ++;
        }
    }
}
