<?php

namespace Models;

class Topic_Model extends \Models\Master_Model {

    public function __construct( $args = array() ) {
        parent::__construct( array(
            'table' => 'topics'
        ) );
// 		echo "Artist model <br />";
    }

    public function get_topics() {
        return parent::find( );
    }
}