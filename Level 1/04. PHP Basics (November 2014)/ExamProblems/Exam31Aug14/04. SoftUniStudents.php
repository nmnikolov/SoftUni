<?php
$inputRows = preg_split('/\n/', $_GET['students'], -1, PREG_SPLIT_NO_EMPTY);

for ($i = 0; $i < count($inputRows); $i++) {
    $studentData =  preg_split('/,\s/', $inputRows[$i], -1, PREG_SPLIT_NO_EMPTY);

    $students[] = [
        'id' => $i + 1,
        'username' => $studentData[0],
        'email' => $studentData[1],
        'type' => $studentData[2],
        'result' => intval($studentData[3])
    ];
}

if (!empty($students)) {
    usort($students, function($a, $b) {
        $sortBy = $_GET['column'];

        if ($a[$sortBy] !== $b[$sortBy]) {
            return $_GET['order'] == 'ascending' ?  $a[$sortBy] > $b[$sortBy] : $a[$sortBy] < $b[$sortBy];
        }

        return $_GET['order'] == 'ascending' ?  $a['id'] > $b['id'] : $a['id'] < $b['id'];
    });
}

echo '<table><thead><tr><th>Id</th><th>Username</th><th>Email</th><th>Type</th><th>Result</th></tr></thead>';

for ($i = 0; $i < count($students); $i++) {
    echo '<tr>' .
        '<td>' . htmlentities($students[$i]['id']) . '</td>' .
        '<td>' . htmlentities($students[$i]['username']) . '</td>' .
        '<td>' . htmlentities($students[$i]['email']) . '</td>' .
        '<td>' . htmlentities($students[$i]['type']) . '</td>' .
        '<td>' . htmlentities($students[$i]['result']) . '</td>' .
        '</tr>';
}

echo '</table>';