<?php

require_once('iReservable.class.php');

abstract class Room implements iReservable {
    private $roomId;
    private $beds;
    private $typeOfRoom;
    private $hasRestroom;
    private $hasBalcony;
    private $price;
    private $reservations = [];
    private $extras =[];

    protected function __construct($roomId, $beds, $typeOfRoom, $hasRestroom, $hasBalcony, $price)
    {
        $this->setRoomId($roomId);
        $this->setBeds($beds);
        $this->setTypeOfRoom($typeOfRoom);
        $this->setHasRestroom($hasRestroom);
        $this->setHasBalcony($hasBalcony);
        $this->setPrice($price);
    }

    public function getRoomId()
    {
        return $this->roomId;
    }

    protected function setRoomId($roomId)
    {
        if (!is_int($roomId)) {
            throw new InvalidArgumentException('Wrong Room ID format.');
        }

        $this->roomId = $roomId;
    }

    public function getBeds()
    {
        return $this->beds;
    }

    protected function setBeds($beds)
    {
        $this->beds = $beds;
    }

    public function getTypeOfRoom()
    {
        return $this->typeOfRoom;
    }

    protected function setTypeOfRoom($typeOfRoom)
    {
        $this->typeOfRoom = $typeOfRoom;
    }

    public function getHasRestroom()
    {
        return $this->hasRestroom;
    }

    protected function setHasRestroom($hasRestroom)
    {
        $this->hasRestroom = $hasRestroom;
    }

    public function getHasBalcony()
    {
        return $this->hasBalcony;
    }

    protected function setHasBalcony($hasBalcony)
    {
        $this->hasBalcony = $hasBalcony;
    }

    public function getPrice()
    {
        return $this->price;
    }

    protected function setPrice($price)
    {
        if (!is_double($price) && !is_int($price)) {
            throw new InvalidArgumentException("Invalid price format");
        }
        
        if ($price < 0) {
            throw new InvalidArgumentException("Price should be positive");
        }

        $this->price = doubleval($price);
    }

    public function getReservations()
    {
        return $this->reservations;
    }

    public function getExtras()
    {
        return $this->extras;
    }

    protected function setExtras($extras)
    {
        $this->extras[] = $extras;
    }

    public function addReservation(Reservation $reservation){
        if (!empty($this->reservations)) {
            foreach ($this->reservations as $res) {
                if ($reservation->getStartDate() >= $res->getStartDate() && $reservation->getStartDate() <= $res->getEndDate()) {
                    throw new EReservationException("A reservation already exists in that period.");
                }

                if ($reservation->getEndDate() >= $res->getStartDate() && $reservation->getEndDate() <= $res->getEndDate()) {
                    throw new EReservationException("A reservation already exists in that period.");
                }
            }
        }

        $this->reservations[] = $reservation;
    }

    public function removeReservation($id){
        $isFound = false;

        for ($i = 0; $i < count($this->reservations); $i++) {
            if ($this->reservations[$i]->getReservationId() == $id) {
                unset($this->reservations[$i]);
                $isFound = true;
                array_multisort($this->reservations);
            }
        }

        if (!$isFound) {
            throw new InvalidArgumentException("Reservation with ID = " . $id . " does not exist.");
        }
    }

    function __toString(){

        $result = "</br><strong>Room number:</strong> " . $this->getRoomId()
            . "</br><strong>Room type:</strong> " . get_called_class()
            . "</br><strong>Beds:</strong> " . $this->getBeds()
            . "</br><strong>Has restroom:</strong> " . ($this->getHasRestroom() == true ? "yes" : "no")
            . "</br><strong>Has balcony:</strong> " . ($this->getHasBalcony() == true ? "yes" : "no")
            . "</br><strong>Extras:</strong> " . implode(", ", $this->getExtras())
            . "</br><strong>Number of reservations:</strong> " . count($this->getReservations())
            . "</br><strong>Price:</strong> " . number_format($this->getPrice(), 2);

        return $result;
    }
}