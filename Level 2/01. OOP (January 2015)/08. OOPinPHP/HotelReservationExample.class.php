<?php

spl_autoload_register(function($class) {
    include './' . $class . '.class.php';
});

try{
    $guests[1] = new Guest("Svetlin", "Nakov", 8003224277);
    $guests[2] = new Guest("Ivan", "Ivanov", 8003221111);
    $guests[3] = new Guest("Petar", "Petrov", 1234567890);

    $reservations[1] = new Reservation(date_create("24.10.2014"), date_create("26.10.2014"), $guests[1]);
    $reservations[2] = new Reservation(date_create("01.02.2015"), date_create("05.02.2015"), $guests[2]);
    $reservations[3] = new Reservation(date_create("16.07.2010"), date_create("22.07.2010"), $guests[1]);
    $reservations[4] = new Reservation(date_create("13.12.2013"), date_create("29.12.2013"), $guests[3]);

    $rooms[101] = new SingleRoom(101, 25);
    $rooms[113] = new SingleRoom(113, 42.1);
    $rooms[306] = new Bedroom(306, 104.2);
    $rooms[333] = new Bedroom(333, 93.1);
    $rooms[501] = new Apartment(501, 1343.12);
    $rooms[505] = new Apartment(505, 930);

    BookingManager::bookRoom($rooms[101], $reservations[1]);
    BookingManager::bookRoom($rooms[505], $reservations[2]);
    BookingManager::bookRoom($rooms[501], $reservations[4]);

    $priceFilter = array_filter($rooms, function(Room $room){
        if (($room instanceof Bedroom || $room instanceof Apartment) && $room->getPrice() <= 250.0) {
            return true;
        }

        return false;
    });

    $balconyFilter = array_filter($rooms, function(Room $room){
        if ($room->getHasBalcony() == true) {
            return true;
        }

        return false;
    });

    $bathtubFilter = array_filter($rooms, function(Room $room){
        if (in_array(Extra::BATHTUB, $room->getExtras())) {
            return true;
        }

        return false;
    });

    $roomNumbers = function($room) {
        return $room->getRoomId();;
    };

    $bathtubRoomNumbers = array_map($roomNumbers, $bathtubFilter);

    echo "</br><font color=\"red\"><strong>Filter the array by bedrooms and apartments with a price less or equal to 250.00: </strong></font>";
    printAll($priceFilter);

    echo "</br><font color=\"red\"><strong>Filter the array by all rooms with a balcony: </strong></font>";
    printAll($balconyFilter);

    echo "</br><font color=\"red\"><strong>Return the room numbers of all rooms which have a bathtub in their extras: </strong></font></br>";
    printAll($bathtubRoomNumbers);

} catch(Exception $ex) {
    echo $ex->getMessage();
}

function printAll($inputArray){
    foreach ($inputArray as $element) {
        echo $element . "</br>";
    }
}