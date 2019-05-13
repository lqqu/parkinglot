using System;
using System.Globalization;
using ClassLibrary2;
using Xunit;

namespace test
{
    public class ParkingLotTest
    {
        [Fact]
        public void should_return_a_ticket_when_parking_car_to_a_parking_lot_with_empty_space()
        {
            Car car = new Car();
            
            ParkingLot pl = new ParkingLot(20);
            Ticket ticket = pl.park(car);

            Assert.NotNull(ticket);
        }
        
        [Fact]
        public void should_not_park_car_successfully_when_parking_car_to_a_parking_lot_with_mo_empty_space()
        {
            Car car = new Car();
            
            ParkingLot pl = new ParkingLot(0);
            
            Assert.Null(pl.park(car));
        
        }
        
        [Fact]
        public void should_pick_car_successfully_when_picking_car_with_a_matched_ticket()
        {
            Car car1 = new Car();
            Car car2 = new Car();

            
            ParkingLot pl = new ParkingLot(20);
            Ticket ticket1 =  pl.park(car1);
            Ticket ticket2  = pl.park(car2);

            Car pickedCar = pl.pick(ticket1);
            
            Assert.NotNull(pickedCar);
            Assert.Same(car1, pickedCar);
            
        
        }
        
        [Fact]
        public void should_not_pick_car_successfully_when_picking_car_with_a_not_matched_ticket()
        {
            Ticket ticket = new Ticket();
            Car car = new Car();
            
            ParkingLot pl = new ParkingLot(20);
            pl.park(car);
            Assert.Null(pl.pick(ticket));

        }
        
        
    }
}
