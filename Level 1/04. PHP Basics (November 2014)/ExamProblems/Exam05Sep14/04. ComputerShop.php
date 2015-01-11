<?php
$list = $_GET['list'];
$minPrice = floatval($_GET['minPrice']);
$maxPrice = floatval($_GET['maxPrice']);
$filter = $_GET['filter'];
$rows = preg_split('/\r?\n/', $list, -1, PREG_SPLIT_NO_EMPTY);
$index = 1;

for ($row = 0; $row < count($rows); $row++) {
    if (trim($rows[$row]) !== '') {
        $rowData = preg_split('/\|/', $rows[$row], -1, PREG_SPLIT_NO_EMPTY);
        $type = trim($rowData[1]);
        $components = preg_split('/, /', $rowData[2], -1, PREG_SPLIT_NO_EMPTY);
        $price = floatval($rowData[3]);

        if (($filter === 'all' || $filter === $type) && $price >= $minPrice && $price <= $maxPrice) {
            $computers[] = [
                'id' => $index,
                'type' => $type,
                'name' => trim($rowData[0]),
                'components' => $components,
                'price' => $price
            ];
        }
        $index++;
    }
}

if (isset($computers)) {
    usort($computers, function($a, $b) {
        $order = $_GET['order'];
        if ($a['price'] !== $b['price']) {
            return $order == 'ascending' ? $a['price'] - $b['price'] : $b['price'] - $a['price'];
        }

        return $a['id'] - $b['id'];
    });
}

for ($i = 0; $i < count($computers); $i++) {
    $product = trim(htmlspecialchars($computers[$i]['id']));
    $name = trim(htmlspecialchars($computers[$i]['name']));
    $price = number_format($computers[$i]['price'], 2, '.', '');
    $components = $computers[$i]['components'];

    echo "<div class=\"product\" id=\"product$product\"><h2>$name</h2><ul>";

    for ($j = 0; $j < count($components); $j++) {
        $component = htmlspecialchars(trim($components[$j]));
        echo "<li class=\"component\">$component</li>";
    }

    echo "</ul><span class=\"price\">$price</span></div>";
}