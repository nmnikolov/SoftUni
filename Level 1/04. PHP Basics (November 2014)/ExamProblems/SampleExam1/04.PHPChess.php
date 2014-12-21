<?php
$input = $_GET['board'];
$input = preg_replace("/\+/", " ", $input);
$input = preg_replace("/%2F/","/", $input);

if(! preg_match("/^[RHBKQP\-\s\/]{127}$/", $input, $output_array)) {
    echo "<h1>Invalid chess board</h1>";
    return;
}


for ($i = 0; $i < strlen($input); $i += 2) {
    if (!preg_match('/[RHBKQP\s]/', $input[$i])) {
        echo "<h1>Invalid chess board</h1>";
        return;
    }
}

$table = preg_split("/\//", $output_array[0] );

$count = [
    "Bishop" => 0,
    "Horseman" => 0,
    "King" => 0,
    "Pawn" => 0,
    "Queen" => 0,
    "Rook" => 0
];

echo "<table>";
foreach ($table as $row) {
    echo "<tr>";
    for ($i = 0; $i < strlen($row) ; $i += 2) {
        if ($row[$i] != "-") {
            echo "<td>$row[$i]</td>";
            $count = countBoard($row[$i], $count);
        }

    }
    echo "</tr>";
}
echo "</table>";

foreach ($count as $key => $value) {
    if ($value == 0) {
        unset($count[$key]);
    }
}

if (!empty ($count)) {
    echo json_encode($count);
}




function countBoard($i, $count) {
    switch ($i) {
        case "R": $count['Rook']++; break;
        case "H": $count['Horseman']++; break;
        case "B": $count['Bishop']++; break;
        case "K": $count['King']++; break;
        case "Q": $count['Queen']++; break;
        case "P": $count['Pawn']++; break;
    }

    return $count;
}
?>