using ClassLibrary2;
using Xunit;

namespace test
{
    public class ParkingBoyTest
    {
        public ParkingBoy parkingBoy;

        public ParkingLot parkinglot;

        public ParkingBoyTest()
        {
            parkinglot = new ParkingLot(3);
            parkingBoy = new ParkingBoy(parkinglot);
        }

        [Fact]
        public void should_get_ticket_when_using_paring_boy_to_part()
        {
            Assert.NotNull(parkingBoy.park(new Car()));
        }

        [Fact]
        public void should_get_car_when_using_parking_boy_fetch_car()
        {
            Assert.NotNull(parkingBoy.pick(new Ticket()));
        }
        
        [Fact]
        public void should_get_correct_ticket_when_using_paring_boy_park_car()
        {
            var car = new Car();
            var ticket = parkingBoy.park(car);
            Assert.Same(car, parkinglot.pick(ticket));
        }

        [Fact]
        public void should_get_correct_car_when_using_paring_boy_pick_car()
        {
            var car = new Car();
            var ticket = parkinglot.park(car);
            Assert.Same(car, parkingBoy.pick(ticket));
        }

        [Fact]
        public void should_get_null_when_parking_lot_is_full()
        {
            parkinglot.park(new Car());
            parkinglot.park(new Car());
            parkinglot.park(new Car());
            Assert.Null(parkingBoy.park(new Car()));
        }

        [Fact]
        public void should_get_null_when_parking_lot_is_empty()
        {
            Assert.Null(parkingBoy.pick(new Ticket()));
        }

        [Fact]
        public void should_park_car_into_first_parking()
        {
            var parkingLot1 = new ParkingLot(2);
            var parkingLot2 = new ParkingLot(2);
            parkingBoy = new ParkingBoy(parkingLot1, parkingLot2);
            parkingBoy.park(new Car());
            Assert.NotNull(parkingLot1.park(new Car()));
            Assert.NotNull(parkingLot2.park(new Car()));
            Assert.NotNull(parkingLot2.park(new Car()));
        }

        [Fact]
        public void should_park_car_into_second_parking_when_first_is_full()
        {
            var parkingLot1 = new ParkingLot(2);
            var parkingLot2 = new ParkingLot(2);
            parkingBoy = new ParkingBoy(parkingLot1, parkingLot2);
            parkingLot1.park(new Car());
            parkingLot1.park(new Car());

            parkingBoy.park(new Car());
            Assert.NotNull(parkingLot2.park(new Car()));
            Assert.Null(parkingLot2.park(new Car()));
        }

        [Fact]
        public void should_get_null_when_parking_lot_both_full()
        {
            var parkingLot1 = new ParkingLot(2);
            var parkingLot2 = new ParkingLot(2);
            parkingBoy = new ParkingBoy(parkingLot1, parkingLot2);
            parkingLot1.park(new Car());
            parkingLot1.park(new Car());
            parkingLot2.park(new Car());
            parkingLot2.park(new Car());

            Assert.Null(parkingBoy.park(new Car()));
        }
    }
}