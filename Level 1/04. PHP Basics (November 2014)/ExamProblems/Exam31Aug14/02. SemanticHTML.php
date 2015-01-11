<?php
$openTags = '/(?:<div .*((?:id|class)\s*=\s*"([^"]+)").*>)/';
$closeTags = '/<\/div>\s*<!--\s*([^\s]+)\s*-->/';
$rows = preg_split("/\n/", $_GET['html'], -1, PREG_SPLIT_NO_EMPTY);

for ($i = 0; $i < count($rows); $i++) {
    if (preg_match($openTags , $rows[$i], $output_array1)) {
        $string = $output_array1[0];
        $replace = ['/<div/', '/' . $output_array1[1] . '/', '/[ ]+/', '/ >/'];
        $replacement = ['<' . $output_array1[2], "" ," ", ">"];
        $newString = preg_replace($replace, $replacement, $string);
        $rows[$i] = str_replace($output_array1[0], $newString, $rows[$i]);
    }

    if (preg_match($closeTags, $rows[$i], $output_array2)) {
        $newString = '</' . $output_array2[1] . '>';
        $rows[$i] = str_replace($output_array2[0], $newString, $rows[$i]);
    }

    echo $rows[$i];
}