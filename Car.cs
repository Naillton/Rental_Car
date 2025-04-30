using System.Diagnostics.Contracts;

namespace CarRental
{
    public class Car : SkeletonCar, Icar
    {
         private string _type = string.Empty;

        public string Type
        {
            get { return _type; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Type cannot be null or empty.");
                }

                if (value.Length < 3 || value.Length > 50)
                {
                    throw new ArgumentException("Type must be between 3 and 50 characters long.");
                }
                _type = value;
            }
        }
        private int _year = 0;
        public int Year {
            get { return _year; }
            set
            {
                if (value < 1886 || value > DateTime.Now.Year)
                {
                    throw new ArgumentException($"Year must be between 1886 and the current year {DateTime.Now.Year}.");
                }
                _year = value;
            }
        }
        private int _speed = 0;
        public int Speed
        {
            get { return _speed; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Speed cannot be negative.");
                }
                _speed = value;
            }
        }

        private double _rentalPrice = 0;
        public double RentalPrice
        {
            get { return _rentalPrice; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Rental price cannot be negative or zero.");
                }
                _rentalPrice = value;
            }
        }

        public Car(string model, string type, int year, int speed, double price) : base(model)
        {
            this.Type = type;
            this.Year = year;
            this.Speed = speed;
            this.RentalPrice = price;
        }

        public string StartEngine()
        {
            return "Engine started.";
        }

        public string StopEngine()
        {
            return "Engine stopped.";
        }

        public string Accelerate(int speed)
        {
            if (speed > this.Speed)
            {
                throw new ArgumentException("Speed cannot be greater than the current speed.");
            }
            return $"Accelerating to {speed} km/h. VRUUMM! VRUUMM!";
        }

        public string Brake(int speed)
        {
            if (speed < 0)
            {
                throw new ArgumentException("Speed cannot be negative.");
            }
            return $"Braking to {speed} km/h. SSSHHHH!";
        }

        public string GetCarInfo()
        {
            return $"Model: {Model}, Type: {Type}, Year: {Year}, Speed: {Speed} km/h, Doors: {Doors}, Wheels: {Wheels}";
        }
    }
}