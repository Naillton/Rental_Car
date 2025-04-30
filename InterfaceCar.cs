using System;
using System.Diagnostics.Contracts;

namespace CarRental
{
    interface Icar
    {
        string StartEngine();
        string StopEngine();
        string Accelerate(int speed);
        string Brake(int speed);
    }
}