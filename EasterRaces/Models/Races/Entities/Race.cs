using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private string name;
        private int laps;
        private readonly Dictionary<string, IDriver> driversInRace = new Dictionary<string, IDriver>();


        public Race(string name, int laps)
        {
            Name = name;
            Laps = laps;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if(string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.RaceInvalid, value));
                }

                name = value;
            }

        }

        public int Laps
        {
            get
            {
                return laps;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, value));
                }

                laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers
        {
            get
            {
                return driversInRace.Values.ToList();
            }
        }

        public void AddDriver(IDriver driver)
        {
            if(driversInRace.ContainsKey(driver.Name))
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.DriverInvalid));
            }

            if(driver.Car == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }

            if(driversInRace.ContainsKey(driver.Name))
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, Name));
            }

            driversInRace.Add(driver.Name, driver);

        }
    }
}
