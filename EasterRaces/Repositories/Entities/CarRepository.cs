using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly Dictionary<string, ICar> carsByModel;

        public CarRepository()
        {
            carsByModel = new Dictionary<string, ICar>();
        }
        
        public void Add(ICar model)
        {
            if(carsByModel.ContainsKey(model.Model))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model.Model));
            }

            carsByModel.Add(model.Model, model);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return carsByModel.Values.ToList();
        }

        public ICar GetByName(string name)
        {
            ICar car = null;

            if(carsByModel.ContainsKey(name))
            {
                car = carsByModel[name];
            }

            return car;

        }

        public bool Remove(ICar model)
        {
            if (carsByModel.ContainsKey(model.Model))
            {
                carsByModel.Remove(model.Model);
                return true;
            }

            return false;

        }
    }


}
