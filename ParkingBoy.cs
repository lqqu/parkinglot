namespace ClassLibrary2
{
    public class ParkingBoy
    {
        private ParkingLot[] parkingLots;

        public ParkingBoy(params ParkingLot[] parkingLots)
        {
            this.parkingLots = parkingLots;
        }
        public Ticket park(Car car)
        {
            foreach (var parkingLot in parkingLots)
            {
                var ticket =  parkingLot.park(car);
                if (ticket != null) return ticket;
            }

            return null;
        }

        public Car pick(Ticket ticket)
        {
            foreach (var parkingLot in parkingLots)
            {
                var car = parkingLot.pick(ticket);
                if (car != null) return car;
            }

            return null;
        }
    }

}