<?php

if (isset($_POST['text'],$_POST['sort'], $_POST['sort-type'])):
    preg_match_all("/[^\n]+/", $_POST['text'], $match);

    foreach ($match[0] as $value) {
        if (preg_match("/(.+)-(.+)-(\d{2}-\d{2}-\d{4}\s\d{2}:\d{2})\s(.+)/", $value, $temp)){
            $seminars[] = [
                'name' => $temp[1],
                'lecturer' => $temp[2],
                'date' => date_create_from_format('d-m-Y H:i', $temp[3]),
                'details' => $temp[4]
            ];
        }
    }

    if (!empty($seminars)) :
        usort($seminars, function($a, $b) {
            $sort = $_POST['sort'];
            $sortType = $_POST['sort-type'];

            return $sortType === 'ascending' ? $b[$sort] < $a[$sort] : $a[$sort] < $b[$sort];
        });
?>

    <p><span class="info">Sort by: </span> <span class="bold"> <?= htmlentities($_POST['sort']) ?> </span></p>
    <p><span class="info">Sort type: </span>  <span class="bold"> <?= htmlentities($_POST['sort-type']) ?> </p>

        <table>
            <thead>
                <tr>
                    <th>Seminar name</th>
                    <th>Date</th>
                    <th>Participate</th>
                </tr>
            </thead>
            <tbody>
                <?php foreach ($seminars as $seminar) : ?>
                    <tr>
                        <td>
                            <a href="#" class="seminar">
                                <?= htmlentities($seminar['name']) ?>
                                <div class="hide">
                                    <p><span class="bold">Lecturer: </span> <?= $seminar['lecturer'] ?> </p>
                                    <p><span class="bold">Details: </span> <?= $seminar['details'] ?> </p>
                                </div>
                            </a>

                        </td>
                        <td> <?= htmlentities($seminar['date']->format('d-m-Y H:i')) ?> </td>
                        <td> <input type="button" onclick="location.href='#'" class="sign-up"  value="SIGN UP"/> </td>
                    </tr>
                <?php endforeach; ?>
            </tbody>
        </table>
    <?php else: ?>
        <p id="error">Invalid entry!</p>
    <?php endif;

endif; ?>