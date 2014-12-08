<?php

if (isset($_POST['string'])):

    function isInteger($str) {
        $pattern = '/^\s*((\-)|(\+))?\s*[\d]+((.|,){1}[0]+)?\s*$/';
        if(preg_match($pattern, $str))
            return true;
        else
            return false;
    }

    function sumOfDigits ($num) {
        $sum = 0;
        $num = preg_replace('/[^\d]/', '', $num);

        for ($i = 0; $i < strlen($num); $i++) {
            $sum += (int)$num[$i];
        }

        return $sum;
    }

    $input = explode(', ', $_POST['string']);
?>

<table>
    <tbody>

    <?php foreach ($input as $str): ?>
        <tr>
            <td> <?= htmlentities(trim($str)) ?></td>
            <td> <?= isInteger($str) ? sumOfDigits($str) : "I cannot sum that" ?></td>
        </tr>
    <?php endforeach; ?>

    </tbody>
</table>

<?php endif; ?>