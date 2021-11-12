using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Customer
    {
        public string fullname;
        public string ci;
        public Customer(string fullname, string ci)
        {
            this.fullname = fullname;
            this.ci = ci;
        }
    }
    abstract class Boat
    {
        public string plate;
        public double length;
        public Boat(string plate, double length)
        {
            this.plate = plate;
            this.length = length;
        }
        public abstract double module();
    }

    class Sailboat : Boat
    {
        public int masts;
        public Sailboat(string plate, double length, int masts) : base(plate, length)
        {
            this.masts = masts;
        }

        public override double module()
        {
            return 10 * this.length + this.masts;
        }
    }

    class Yatch : Boat
    {
        public int cabins;
        public double power;
        public Yatch(string plate, double length, int cabins, double power) : base(plate, length)
        {
            this.cabins = cabins;
            this.power = power;
        }

        public override double module()
        {
            return 10 * this.length + this.power + this.cabins;
        }
    }

    class Sport : Boat
    {
        public double power;
        public Sport(string plate, double length, double power) : base(plate, length)
        {
            this.power = power;
        }

        public override double module()
        {
            return 10 * this.length + this.power;
        }
    }

    class Rental
    {
        public RentalTime rental_time;
        public readonly string position;
        public readonly double base_price;
        public readonly Boat boat;
        public readonly Customer customer;

        public Rental(double base_price, string position, Boat boat, Customer customer, RentalTime rental_time)
        {
            this.rental_time = rental_time;
            this.position = position;
            this.boat = boat;
            this.customer = customer;
            this.base_price = base_price;
        }

        public double calculate()
        {
            return this.rental_time.getTotalDays() * this.boat.module() * this.base_price;
        }

    }

    class RentalTime
    {
        private DateTime start_date;
        private DateTime end_date;
        public RentalTime(DateTime start_date, DateTime end_date)
        {
            if (start_date > end_date)
                throw new Exception("Dates not valid");
            this.start_date = start_date;
            this.end_date = end_date;
        }

        public DateTime Start_date { get => start_date; set => start_date = value; }
        public DateTime End_date { get => end_date; set => end_date = value; }

        public int getTotalDays()
        {
            return (this.end_date - this.start_date).Days + 1;
        }


    }

    class Business
    {
        private string business_name;
        private string nit;
        private List<Port> _ports = new List<Port>();
        public Business(string nit, string business_name)
        {
            this.business_name = business_name;
            this.nit = nit;
        }
        public string Business_name { get => business_name; set => business_name = value; }
        public string Nit { get => nit; set => nit = value; }

        internal List<Port> Ports { get => _ports; set => _ports = value; }

        public void addPort(Port port)
        {
            this._ports.Add(port);
        }

    }

    class Port
    {
        private List<Rental> _rents = new List<Rental>();
        private double base_price;
        private string name;
        private int moorings;


        public Port(double base_price, string name, int moorings)
        {
            this.base_price = base_price;
            this.name = name;
            this.moorings = moorings;
        }

        public double Base_price { get => base_price; set => base_price = value; }
        public string Name { get => name; set => name = value; }
        public int Moorings { get => moorings; set => moorings = value; }

        public void addRental(Rental rental)
        {
            this._rents.Add(rental);
        }

        public double getTotalRents()
        {
            double total = 0;
            this._rents.ForEach(item => { total += item.calculate(); });
            return total;
        }

    }

}
