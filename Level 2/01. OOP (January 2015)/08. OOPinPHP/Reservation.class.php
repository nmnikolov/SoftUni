<?php

class Reservation {
    private static $id = 0;
    private $reservationId;
    private $startDate;
    private $endDate;
    private $guest;

    function __construct($startDate, $endDate, Guest $guest)
    {
        $this->setReservationId();
        $this->setStartDate($startDate);
        $this->setEndDate($endDate);
        $this->setGuest($guest);
    }

    public function getReservationId()
    {
        return $this->reservationId;
    }

    private function setReservationId()
    {
        $this->reservationId = ++self::$id;
    }

    public function getStartDate()
    {
        return $this->startDate;
    }

    private function setStartDate($startDate)
    {
        $this->startDate = $startDate;
    }

    public function getEndDate()
    {
        return $this->endDate;
    }

    private function setEndDate($endDate)
    {
        $this->endDate = $endDate;
    }

    public function getGuest()
    {
        return $this->guest;
    }

    private function setGuest($guest)
    {
        $this->guest = $guest;
    }

    function __toString(){
        $result = "</br><strong>Reservation ID:</strong> " . $this->getReservationId()
        . "</br><strong>Start date:</strong> " . date_format($this->getStartDate(), "d-m-y")
        . "</br><strong>End date:</strong> " . date_format($this->getEndDate(), "d-m-y")
        . "</br><strong>Guest: </strong></br>" . $this->getGuest();

        return $result;
    }
}