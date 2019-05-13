using System;
using System.Collections.Generic;

namespace ClassLibrary2
{
    public class ParkingLot
    {
        private int capacity;
        private Car car;
        private int availableSpace;
        private Dictionary<Ticket, Car> parkedCars = new Dictionary<Ticket, Car>();

        public ParkingLot(int capacity)
        {
            this.capacity = capacity;
            this.availableSpace = capacity;
            
        }

        public Ticket park(Car car)
        {
            if (hasEmptySpace())
            {
                Ticket ticket = new Ticket();
                parkedCars.Add(ticket, car);
                availableSpace--;
                
                return ticket;
            }

            return null;
        }

        

        public Car pick(Ticket ticket)
        {
            if (hasMatchedCar(ticket))
            {
                availableSpace++;
                return parkedCars.GetValueOrDefault(ticket);
            }

            return null;

        }
        private Boolean hasEmptySpace()
        {
            if (availableSpace > 0)
            {
                return true;
            }

            return false;
        }

        private Boolean hasMatchedCar(Ticket ticket)
        {
            for (int i = 0; i <= parkedCars.Count; i++)
            {
                if (parkedCars.ContainsKey(ticket))
                {
                    return true;
                }
            }

            return false;
        }
    }
}