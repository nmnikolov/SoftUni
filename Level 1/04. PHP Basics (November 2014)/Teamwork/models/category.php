<?php

namespace Models;

class Category_Model extends \Models\Master_Model {

    public function __construct( $args = array() ) {
        parent::__construct( array(
            'table' => 'categories'
        ) );
// 		echo "Artist model <br />";
    }

    public function get_categories() {
        return parent::find( );
    }
}