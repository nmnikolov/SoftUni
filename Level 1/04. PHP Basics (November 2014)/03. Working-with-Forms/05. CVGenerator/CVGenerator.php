<?php

if (isset($_POST['first-name'], $_POST['last-name'], $_POST['email'], $_POST['tel'], $_POST['gender'],
    $_POST['bdate'], $_POST['nationality'], $_POST['company'], $_POST['work-from'], $_POST['work-to'])):

    function validateFields($fields) {
        $patterns = [
            'name' => '/^[A-Za-z]{2,20}$/',
            'company' => '/^[A-Za-z\d]{2,20}$/',
            'phone' => '/^[\d+\- ]+$/',
            'email' => '/^[a-zA-z\d]+@[a-zA-Z\d]+.[a-zA-z]+$/'
        ];


        if (!preg_match($patterns['name'], $fields['fn'])) {
            echo "<p>Only letters Between 2 and 20 symbols are allowed for First Name</p>";
            exit;
        }

        if (!preg_match($patterns['name'], $fields['ln'])) {
            echo "<p>Only letters Between 2 and 20 symbols are allowed for Last Name</p>";
            exit;
        }

        if (!preg_match($patterns['email'], $fields['email'])) {
            echo "<p>Only Letters, Numbers, one '@' and one '.' are allowed for Email</p>";
            exit;
        }

        if (!preg_match($patterns['phone'], $fields['tel'])) {
            echo "<p>Only numbers, +, - and space are allowed for Phone Number</p>";
            exit;
        }

        if (!preg_match($patterns['company'], $fields['company'])) {
            echo "<p>Only letters and numbers Between 2 and 20 symbols are allowed for Company Name</p>";
            exit;
        }

        foreach ($fields['lang'] as $value) {
            if (isset($_POST['lang']) && !preg_match($patterns['name'], $value)) {
                echo "<p>Only letters Between 2 and 20 symbols are allowed for Language</p>";
                exit;
            }
        }
    }

    $fields = [
        'fn' => $_POST["first-name"],
        'ln' => $_POST["last-name"],
        'email' => $_POST["email"],
        'tel' => $_POST["tel"],
        'gender' => $_POST["gender"],
        'bdate' => $_POST["bdate"],
        'nationality' => $_POST["nationality"],
        'company' => $_POST["company"],
        'work-from' => $_POST["work-from"],
        'work-to' => $_POST["work-to"],
        'pr-lang' => isset($_POST["pr-lang"]) ? $_POST["pr-lang"] : ['-'],
        'pr-skill' => isset($_POST["pr-skill"]) ? $_POST["pr-skill"] : ['-'],
        'lang' => isset($_POST["lang"]) ? $_POST["lang"] : ['-'],
        'comprehension' => isset($_POST["comprehension"]) ? $_POST["comprehension"] : ['-'],
        'reading' => isset($_POST["reading"]) ? $_POST["reading"] : ['-'],
        'writing' => isset($_POST["writing"]) ? $_POST["writing"] : ['-'],
        'driver-license' => isset($_POST["driver-license"]) ? $_POST["driver-license"] : ['no']
    ];

    validateFields($fields);

?>

    <table class="main">
        <thead>
        <tr>
            <th colspan="2">Personal Information</th>
        </tr>
        </thead>
        <tbody>
        <tr>
            <td>First name</td>
            <td> <?= htmlentities($fields['fn']) ?> </td>
        </tr>
        <tr>
            <td>Last name</td>
            <td> <?= htmlentities($fields['ln']) ?> </td>
        </tr>
        <tr>
            <td>Email</td>
            <td> <?= htmlentities($fields['email']) ?> </td>
        </tr>
        <tr>
            <td>Phone Number</td>
            <td> <?= htmlentities($fields['tel']) ?> </td>
        </tr>
        <tr>
            <td>Gender</td>
            <td> <?= htmlentities($fields['gender']) ?> </td>
        </tr>
        <tr>
            <td>Birth Date</td>
            <td> <?= htmlentities($fields['bdate']) ?> </td>
        </tr>
        <tr>
            <td>Nationality</td>
            <td> <?= htmlentities($fields['nationality']) ?> </td>
        </tr>
        </tbody>
    </table>

    <table class="main">
        <thead>
        <tr>
            <th colspan="2">Last Work Position</th>
        </tr>
        </thead>
        <tbody>
        <tr>
            <td>Company Name</td>
            <td> <?= htmlentities($fields['company']) ?> </td>
        </tr>
        <tr>
            <td>From</td>
            <td> <?= htmlentities($fields['work-from']) ?> </td>
        </tr>
        <tr>
            <td>To</td>
            <td> <?= htmlentities($fields['work-to']) ?> </td>
        </tr>
        </tbody>
    </table>

    <table class="main">
        <thead>
        <tr>
            <th colspan="3">Computer Skills</th>
        </tr>
        </thead>
        <tbody>
        <tr>
            <td>Programming Languages</td>
            <td>
                <table>
                    <thead>
                    <tr>
                        <th>Language</th>
                        <th>Skill Level</th>
                    </tr>
                    </thead>
                    <tbody>
                    <?php for ($i = 0; $i < count($fields['pr-lang']); $i++): ?>
                        <tr>
                            <td> <?= htmlentities($fields['pr-lang'][$i]) ?> </td>
                            <td> <?= htmlentities($fields['pr-skill'][$i]) ?> </td>
                        </tr>
                    <?php endfor; ?>
                    </tbody>
                </table>
            </td>
        </tr>
        </tbody>
    </table>

    <table class="main">
        <thead>
        <tr>
            <th colspan="3">Other Skills</th>
        </tr>
        </thead>
        <tbody>
        <tr>
            <td>Languages</td>
            <td>
                <table>
                    <thead>
                    <tr>
                        <th>Language</th>
                        <th>Comprehension</th>
                        <th>Reading</th>
                        <th>Writing</th>
                    </tr>
                    </thead>
                    <tbody>
                    <?php for ($i = 0; $i < count($fields['lang']); $i++): ?>
                        <tr>
                            <td> <?= htmlentities($fields['lang'][$i]) ?> </td>
                            <td> <?= htmlentities($fields['comprehension'][$i]) ?> </td>
                            <td> <?= htmlentities($fields['reading'][$i]) ?> </td>
                            <td> <?= htmlentities($fields['writing'][$i]) ?> </td>
                        </tr>
                    <?php endfor; ?>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <td>Driver's license</td>
            <td> <?= htmlentities(implode(', ', $fields['driver-license'])) ?> </td>
        </tr>
        </tbody>
    </table>
<?php endif; ?>