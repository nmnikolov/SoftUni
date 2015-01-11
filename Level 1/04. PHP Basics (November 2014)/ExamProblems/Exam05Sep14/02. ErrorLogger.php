<?php
preg_match_all("/\s*Exception.* java\..*(?<=\.)(.*):.*?\n\s*at.*?\.(.*?)\((.*?):(\d+)/", $_GET['errorLog'], $logger);

echo '<ul>';
for ($i = 0; $i < count($logger[0]); $i++) {
    $line = $logger[4][$i];
    $exception = $logger[1][$i];
    $filename = $logger[3][$i];
    $method = $logger[2][$i];

    echo "<li>line <strong>$line</strong> - <strong>$exception</strong> in <em>$filename:$method</em></li>";

}
echo '</ul>';