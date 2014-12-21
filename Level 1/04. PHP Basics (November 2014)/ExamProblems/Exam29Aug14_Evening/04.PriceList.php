<?php
$products = [];
$text = explode("\n", $_GET['priceList']);
$text = implode("", $text);

preg_match_all("/<tr>(?:(?!<\/tr>).)*<\/tr>/", $text, $rows);

for ($i = 1; $i < count($rows[0]); $i++) {
    preg_match_all("/<td>((?:(?!<\/td>).)*)<\/td>/", $rows[0][$i], $data);

    $products[trim($data[1][1])][] = [
        "product" => html_entity_decode(trim($data[1][0])),
        "price" => html_entity_decode(trim($data[1][2])),
        "currency" => html_entity_decode(trim($data[1][3]))
    ];
}

$keys = array_keys($products);

foreach ($keys as $key) {
    usort($products[$key], function($a, $b) {
        return $b['product'] < $a['product'];
    });
}

ksort($products);
echo json_encode($products);