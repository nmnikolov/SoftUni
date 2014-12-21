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