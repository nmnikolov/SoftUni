<?php
$text = trim($_GET['text']);
$length = $_GET['lineLength'];
$rows = intval(strlen($text) / $length) + (strlen($text) % $length !== 0 ? 1 : 0);
$output = [];

for ($row = 0; $row < $rows; $row++) {
    $rowData = [];
    for ($col = 0; $col < $length; $col++) {
        $index = $row * $length + $col;
        if ($index < strlen($text)) {
            $rowData[] = $text[$index];
        } else {
            $rowData[] = ' ';
        }
    }
    $output[] = $rowData;
}

for ($row = count($output) - 2; $row >= 0 ; $row--) {
    for ($col = 0; $col < $length; $col++) {
        for ($i = $row; $i < count($output) - 1; $i++) {
            if ($output[$i + 1][$col] == ' ') {
                $output[$i + 1][$col] = $output[$i][$col];
                $output[$i][$col] = ' ';
            }
        }
    }
}

echo '<table>';

for ($row = 0; $row < $rows; $row++) {
    echo '<tr>';
    for ($col = 0; $col < $length; $col++) {
        echo '<td>' . htmlspecialchars($output[$row][$col]) . '</td>';
    }

    echo '</tr>';
}

echo '<table>';