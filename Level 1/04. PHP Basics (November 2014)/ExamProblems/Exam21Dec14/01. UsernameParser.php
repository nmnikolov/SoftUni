<?php
$list = $_GET['list'];
$show = isset($_GET['show']) ? true : false;
$length = intval($_GET['length']);
$names = preg_split('/\n/', $list, -1, PREG_SPLIT_NO_EMPTY);

echo "<ul>";
foreach ($names as $name) {
    $name = trim($name);

    if (strlen($name) >= $length) {
        echo "<li>" . htmlspecialchars($name) . "</li>";
    } elseif ($show && $name != "") {
        echo '<li style="color: red;">' . htmlspecialchars($name) . "</li>";
    }
}
echo "</ul>";