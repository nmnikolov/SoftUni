<?php

if (isset($_POST['string'], $_POST['option'])):

    function isPalindrome($string) {
        $a = strtolower(preg_replace("/[^A-Za-z0-9]/","",$string));
        return $a==strrev($a);
    }

    function splitLetters($string) {
        $letters = preg_replace('/[^A-Za-z]/', '', $string);

        return implode(' ', str_split($letters));
    }

    $string = $_POST['string'];
    $option = $_POST['option'];

    switch ($option) {
        case "Check Palindrome": $output = "'$string' is " . (isPalindrome($string) ? "a palindrome." : "not a palindrome!"); break;
        case "Reverse String": $output = strrev($string); break;
        case "Split": $output = splitLetters($string); break;
        case "Hash String": $output = crypt($string); break;
        case "Shuffle String": $output = str_shuffle($string); break;
    }
?>

    <p> <span>Input: </span> <?= htmlentities($string) ?> </p>
    <p> <span> <?= $option ?>: </span> <?= htmlentities($output) ?> </p>

<?php endif; ?>