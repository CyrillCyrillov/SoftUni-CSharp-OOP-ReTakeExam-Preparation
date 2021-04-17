using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars
{
    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;
        private int minHorsePower;
        private int maxHorsePower;
        private double cubicCentimeters;

        // HashSet<string> existingModels = new HashSet<string>();

        public Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.minHorsePower = minHorsePower;

            this.maxHorsePower = maxHorsePower;
            
            Model = model;

            HorsePower = horsePower;

            CubicCentimeters = cubicCentimeters;

        }


        public string Model
        { 
            get
            {
                return model;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, 4));
                }

                /*
                if (existingModels.Contains(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, value));
                }
                */

                model = value;
                //existingModels.Add(model);
            }
        }

        public int HorsePower
        {
            get
            {
                return horsePower;
            }

            private set
            {
                if(value < minHorsePower || value > maxHorsePower)
                {
                    throw new AggregateException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                horsePower = value;

            }

        }

        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps)
        {
            return cubicCentimeters / horsePower * laps;
        }
    }
}


//VIDEO -> 3:30