<?php

class Bedroom extends Room{
    function __construct($roomId, $price)
    {
        parent::__construct($roomId, 2, RoomType::GOLD, true, true, $price);
        $this->setExtras(Extra::TV);
        $this->setExtras(Extra::AIR_CONDITIONER);
        $this->setExtras(Extra::REFRIGERATOR);
        $this->setExtras(Extra::MINI_BAR);
        $this->setExtras(Extra::BATHTUB);
    }
}