using System;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Business b1 = new Business("11001215", "GlobalPorts srl");
            Port port1 = new Port(12, "Singapur Port",20);
            Port port2 = new Port(20, "Iquique Port", 30);

            b1.addPort(port1);
            b1.addPort(port2);

            Customer customer = new Customer("John wick", "3528412");
            Boat boat = new Sailboat("XSDD4522", 15.8, 4);
            RentalTime time = new RentalTime(new DateTime(2021, 11, 1), new DateTime(2021, 11, 15));
            Rental rent = new Rental(port1.Base_price ,"Left", boat, customer, time);

            Customer customer2 = new Customer("Juan Perez", "5492151");
            Boat boat2 = new Sport("XSDD4522", 15.8, 4);
            RentalTime time2 = new RentalTime(new DateTime(2021, 11, 1), new DateTime(2021, 11, 7));
            Rental rent2 = new Rental(port1.Base_price, "Left", boat2, customer2, time2);


            port1.addRental(rent);
            port1.addRental(rent2);

            Console.WriteLine(
                $"Alquiler 1: \n"+
                $"Precio de alquiler: {rent.calculate()} $us \n" +
                $"Matricula :  { rent.boat.plate }  \n" +
                $"Cliente : { rent.customer.fullname }"
            );

            Console.WriteLine(
                $"Alquiler 2: \n" +
                $"Precio de alquiler: {rent2.calculate()} $us \n" +
                $"Matricula :  { rent2.boat.plate }  \n" +
                $"Cliente : { rent2.customer.fullname }"
            );

            Console.WriteLine($"total ganancias : {port1.getTotalRents()}");


        }
    }
}
