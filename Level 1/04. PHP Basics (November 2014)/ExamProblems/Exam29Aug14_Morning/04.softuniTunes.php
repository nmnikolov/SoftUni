<!DOCTYPE html>
<html>
<head>
    <title>SoftUni Tunes</title>
    <style>
        textarea {
            width: 500px;
            height: 200px;
        }
        select, textarea, input {
            display: block;
            margin: 5px;
        }
    </style>
</head>
<body>
    <form action="" method="get">
        <label>Text:</label>
        <textarea name="text">Krali Marko | Rock | Nakov, Joro, Pesho | 1250 | 4.8
Sladkarnica Malinka | Jazz | Pencho, Nakov, Gero | 728 | 4.3
Hvani me Minke | Rock | Kaloqn, Tosho | 1930 | 4.4
V starite Karpati | Rock | Nakov | 1029 | 4.1
Rakiichice | Rock | Ceco, Joro, Nakov, Preslav, Petya | 453 | 4.2</textarea>
        <label>Artist:</label>
        <input type="text" name="artist" value="Nakov"/>
        <label>Sort by:</label>
        <select name="property">
            <option value="name">name</option>
            <option value="genre">genre</option>
            <option value="downloads">downloads</option>
            <option value="rating" selected>rating</option>
        </select>
        <label>Order by:</label>
        <select name="order">
            <option value="ascending" selected>ascending</option>
            <option value="descending">descending</option>
        </select>
        <input type="submit" value="SUBMIT"/>
    </form>
</body>
</html>

<?php
$pattern = '/([^\|]+)\|([^\|]+)\|([^\|]+)\|([^\|]+)\|([^\|\n]+)\n*/';
$songs = [];
preg_match_all($pattern, $_GET['text'], $rows);

for ($i = 0; $i < count($rows[0]); $i++) {
        $artists = explode(', ', trim($rows[3][$i]));
        if (in_array($_GET['artist'], $artists)) {
        sort($artists);

        $songs[] = [
            'name' => trim($rows[1][$i]),
            'genre' => trim($rows[2][$i]),
            'artists' => implode(', ', $artists),
            'downloads' => intval(trim($rows[4][$i])),
            'rating' => floatval(trim($rows[5][$i]))
        ];
    }
}

usort($songs, function($a, $b) {
    $property = $_GET['property'];

    if ($b[$property] !== $a[$property]) {
        return $_GET['order'] === 'ascending' ? $b[$property] < $a[$property] : $a[$property] < $b[$property];
    }
    return $b['name'] < $a['name'];
});

echo "<table>", "\n";
echo "<tr><th>Name</th><th>Genre</th><th>Artists</th><th>Downloads</th><th>Rating</th></tr>", "\n";

foreach ($songs as $song) {
    echo "<tr><td>" . htmlentities($song['name']) . "</td><td>" . htmlentities($song['genre']) . "</td><td>" . htmlentities($song['artists']) . "</td><td>" . htmlentities($song['downloads']) . "</td><td>" . htmlentities($song['rating']) . "</td></tr>", "\n";
}

echo "</table>", "\n";