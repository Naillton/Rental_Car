using System;
using System.Diagnostics.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRental
{
    public class RentalStore
    {

        // lista de carros disponiveis para alugar
        // definindo readonly para evitar que a lista seja alterada diretamente
        private readonly List<Car> _cars = new List<Car>();

        // propriedadr para acessar carros disponiveis (somente leitura)
        public IReadOnlyList<Car> Cars => _cars.AsReadOnly();

        public void AddCar(Car car)
        {
            if (_cars.Any(c => c.Model == car.Model && c.Type == car.Type && c.Year == car.Year))
            {
                throw new ArgumentException("Car already exists in the store.");
            }
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car), "Car cannot be null.");
            }
            _cars.Add(car);
        }

        public void RemoveCar(string model, string type)
        {
            Car? existingCar = Cars.FirstOrDefault(c => c.Model == model && c.Type == type);
            if (existingCar == null)
            {
                throw new ArgumentException("Car does not exist in the store.");
            }
            _cars.Remove(existingCar);
        }

        public List<Car> GetAvailableCars()
        {
            return _cars.Where(c => !c.Rented).ToList();
        }

        public List<Car> GetRentedCars()
        {
            return _cars.Where(c => c.Rented).ToList();
        }

        public void RentCar(string model, string type)
        {
            Car? existingCar = Cars.FirstOrDefault(c => c.Model == model && c.Type == type);
            if (existingCar == null)
            {
                throw new ArgumentException("Car does not exist in the store.");
            }
            if (existingCar.Rented)
            {
                throw new InvalidOperationException("Car is already rented.");
            }
            existingCar.Rented = true;
        }
    }
}