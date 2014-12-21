<?php

namespace Models;

class Answer_Model extends \Models\Master_Model {

    public function __construct( $args = array() ) {
        parent::__construct( array(
            'table' => 'answers'
        ) );
// 		echo "Artist model <br />";
    }

    public function get_answers() {
        return parent::find( );
    }
}