<?php

if (isset($_GET['amount'], $_GET['currency'], $_GET['interest'], $_GET['period'])) {

    $variables = [
        'amount' => $_GET['amount'],
        'interest' => $_GET['interest'] / 12,
        'period' => $_GET['period'],
    ];

    switch ($_GET['currency']) {
        case 'USD': $variables['currency'] = '$'; break;
        case 'EUR': $variables['currency'] = '€'; break;
        default: $variables['currency'] = 'lv.'; break;
    }

    $result = $variables['amount'];

    for ($i = 0; $i < $variables['period']; $i++) {
        $result *= (100 + $variables['interest']) / 100;
    }
}
?>

<!DOCTYPE html>
<html>
<head>
    <title>Calculate Interest</title>
</head>
<body>
<div id="container">
    <form action="" method="get">
        <div>
            <label for="amount">Enter Amount:</label>
            <input type="text" id="amount" name="amount" required />
        </div>
        <div>
            <input type="radio" name="currency" id="USD" value="USD" required />
            <label for="USD">USD</label>
            <input type="radio" name="currency" id="EUR" value="EUR" />
            <label for="EUR">EUR</label>
            <input type="radio" name="currency" id="BGN" value="BGN" />
            <label for="BGN">BGN</label>
        </div>
        <div>
            <label for="interest">Compound Interest Amount</label>
            <input type="text" name="interest" id="interest" required />
        </div>
        <div>
            <select name="period" required>
                <option selected value="" disabled>Period</option>
                <option value="6">6 Months</option>
                <option value="12">1 Year</option>
                <option value="24">2 Years</option>
                <option value="60">5 Years</option>
                <input type="submit" value="Calculate">
            </select>
        </div>
    </form>

    <?php if (isset($result)): ?>
        <p><?= htmlentities($variables['currency']) . ' ' . htmlentities(round($result, 2)) ?></p>
    <?php endif ?>
</div>
</body>
</html>