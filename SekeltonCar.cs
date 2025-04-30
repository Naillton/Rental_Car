using System.Diagnostics.Contracts;

namespace CarRental

{
    public class SkeletonCar
    {
        private string _model = string.Empty;
        public string Model
        {
            get { return _model; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Model cannot be null or empty.");
                }

                if (value.Length < 3 || value.Length > 50)
                {
                    throw new ArgumentException("Model must be between 3 and 50 characters long.");
                }
                _model = value;
            }
        }
        public int Doors { get; } = 4;
        public int Wheels { get; } = 4;

        private Boolean rented = false;
        public Boolean Rented
        {
            get { return rented; }
            set
            {
                if (value != true && value != false)
                {
                    throw new ArgumentException("Rented must be true or false.");
                }
                rented = value;
            }
        }

        public SkeletonCar(string model)
        {
            this.Model = model;
            
        }
    }
}