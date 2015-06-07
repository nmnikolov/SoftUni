<?php

class BookingManager {

    private function __construct()
    {
    }

    static function bookRoom(Room $room, Reservation $reservation){
        try{
            $room->addReservation($reservation);
            $startDate = $reservation->getStartDate();
            $endDate = $reservation->getEndDate();
            $guestName = $reservation->getGuest()->getFistName() . " " . $reservation->getGuest()->getLastName();

            echo "\nRoom <strong>" . $room->getRoomId() . "</strong> successfully booked for <strong>"
                . $guestName
                . "</strong> from <time>" . date_format($startDate, "d-m-y")
                . "</time> to <time>" . date_format($endDate, "d-m-y")
                . "</time>!</br>";
        } catch(EReservationException $ex){
            echo $ex->getMessage();
        }
    }
}