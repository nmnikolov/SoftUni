<?php

$nationalities = ['Albanian', 'Austrian', 'Bulgarian', 'Canadian', 'Cuban', 'German', 'Israeli', 'Nigerian', 'Pakistani',
    'Tunisian', 'Zambian', 'Other'];

$skillLevels = ['Beginner', 'Intermediate', 'Advanced', 'Expert', 'Other'];

$langLevels = ['A1', 'A2', 'B1', 'B2', 'C1', 'C2'];
?>

<!DOCTYPE html>
<html>
<head>
    <title>CV Generator</title>
    <link type="text/css" rel="stylesheet" href="styles/style.css">
    <script src="js/CVGenerator.js" defer></script>
</head>
<body>
<div id="container">
    <form action="" method="post">
        <fieldset id="personal-info">
            <legend>Personal Information</legend>
            <input class="block" type="text" name="first-name" placeholder="First Name" required />
            <input class="block" type="text" name="last-name" placeholder="Last Name" required />
            <input class="block" type="email" name="email" placeholder="Email" required />
            <input class="block" type="tel" name="tel" placeholder="Phone Number" required />
            <div id="gender">
                <label for="Female">Female</label>
                <input type="radio" name="gender" id="Female" value="Female" required=""/>
                <label for="Male">Male</label>
                <input type="radio" name="gender" id="Male" value="Male" />
            </div>
            <label>Birth Date</label>
            <input class="block" type="date" name="bdate" placeholder="mm/dd/yyyy" required />
            <label>Nationality</label>
            <select class="block" name="nationality" required>
                <option selected value="" disabled>-Nationality-</option>

                <?php for ($i = 0; $i < count($nationalities); $i++): ?>
                    <option value="<?= htmlentities($nationalities[$i]) ?>"> <?= htmlentities($nationalities[$i]) ?> </option>
                <?php endfor; ?>

            </select>
        </fieldset>

        <fieldset id="work-position">
            <legend>Last Work Position</legend>
            <div>
                <label for="company">Company Name</label>
                <input type="text" name="company" id="company" required />
            </div>
            <div>
                <label for="work-from">From</label>
                <input type="date" name="work-from" id="work-from" placeholder="mm/dd/yyyy" required />
            </div>
            <div>
                <label for="work-to">To</label>
                <input type="date" name="work-to" id="work-to" placeholder="mm/dd/yyyy" required />
            </div>
        </fieldset>

        <fieldset id="computer-skills">
            <legend>Computer Skills</legend>
            <label for="pr-lang">Programming Languages</label>
            <div id="prog-lang">
                <div id="pr-lang-hidden" class="hidden" >
                    <input type="text"/>
                    <select>
                        <option selected value="" disabled>-Skill Level-</option>

                        <?php for ($i = 0; $i < count($skillLevels); $i++): ?>
                            <option value="<?= htmlentities($skillLevels[$i]) ?>"> <?= htmlentities($skillLevels[$i]) ?> </option>
                        <?php endfor; ?>

                    </select>
                    <input type="button" class="remove" value="x" onclick="removeProgLang('')"/>
                </div>
            </div>
            <input type="button" value="Add Language" id="add-pr-lang" onclick="addProgLang()"/>
        </fieldset>

        <fieldset id="other-skills">
            <legend>Other Skills</legend>
            <label>Languages</label>
            <div id="lang">
                <div id="lang-hidden" class="hidden">
                    <input type="text">
                    <select>
                        <option selected value="" disabled>-Comprehension-</option>

                        <?php for ($i = 0; $i < count($langLevels); $i++): ?>
                            <option value="<?= htmlentities($langLevels[$i]) ?>"> <?= htmlentities($langLevels[$i]) ?> </option>
                        <?php endfor; ?>

                    </select>
                    <select>
                        <option selected value="" disabled>-Reading-</option>

                        <?php for ($i = 0; $i < count($langLevels); $i++): ?>
                            <option value="<?= htmlentities($langLevels[$i]) ?>"> <?= htmlentities($langLevels[$i]) ?> </option>
                        <?php endfor; ?>

                    </select>
                    <select>
                        <option selected value="" disabled>-Writing-</option>

                        <?php for ($i = 0; $i < count($langLevels); $i++): ?>
                            <option value="<?= htmlentities($langLevels[$i]) ?>"> <?= htmlentities($langLevels[$i]) ?> </option>
                        <?php endfor; ?>

                    </select>
                    <input type="button" class="remove" value="x" onclick="removeLang('')"/>
                </div>
            </div>
            <input type="button" value="Add Language" onclick="addLang()"/>
            <div id="driver-license">
                <label>Driver's License</label>
                <div>
                    <label for="B">B</label>
                    <input type="checkbox" name="driver-license[]" id="B" value="B">
                    <label for="A">A</label>
                    <input type="checkbox" name="driver-license[]" id="A" value="A">
                    <label for="C">C</label>
                    <input type="checkbox" name="driver-license[]" id="C" value="C">
                </div>
            </div>
        </fieldset>
        <input type="submit" value="Generate CV" />
    </form>

    <?php require 'CVGenerator.php'; ?>

</div>
</body>
</html>