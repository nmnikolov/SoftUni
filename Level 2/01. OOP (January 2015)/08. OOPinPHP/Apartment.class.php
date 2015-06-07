<?php

class Apartment extends Room {
    function __construct($roomId, $price)
    {
        parent::__construct($roomId, 4, RoomType::DIAMOND, true, true, $price);
        $this->setExtras(Extra::TV);
        $this->setExtras(Extra::AIR_CONDITIONER);
        $this->setExtras(Extra::REFRIGERATOR);
        $this->setExtras(Extra::MINI_BAR);
        $this->setExtras(Extra::BATHTUB);
        $this->setExtras(Extra::KITCHEN_BOX);
        $this->setExtras(Extra::BATHTUB);
    }
}