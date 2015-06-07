<?php

class SingleRoom extends Room {

    function __construct($roomId, $price)
    {
        parent::__construct($roomId, 1, RoomType::STANDARD, true, false, $price);
        $this->setExtras(Extra::TV);
        $this->setExtras(Extra::AIR_CONDITIONER);
    }
}