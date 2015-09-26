<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Lab</title>
    <link rel="stylesheet" href="<?=\SoftUni\Helpers\Helpers::url()?>Styles/style.css" type="text/css">
    <link rel="stylesheet" href="<?=\SoftUni\Helpers\Helpers::url()?>Styles/bootstrap.min.css" type="text/css">
    <script src="<?=\SoftUni\Helpers\Helpers::url()?>Libs/jquery-2.1.4.min.js" type="application/javascript"></script>
    <script src="<?=\SoftUni\Helpers\Helpers::url()?>Libs/bootstrap.min.js"></script>
</head>
<body>
<header>
    <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
        <div class="container-fluid">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-9" aria-expanded="false">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>

                <span class="navbar-brand header-logo">Game</span>
            </div>

            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="navbar-collapse collapse" id="bs-example-navbar-collapse-9" aria-expanded="false">


                    <?php if(!isset($_SESSION['id'])): ?>
                    <ul class="nav navbar-nav navbar-right">
                        <li><a href="<?= \SoftUni\Helpers\Helpers::url() . 'users/login'?>" class="hvr-underline-reveal"><span class="glyphicon glyphicon-log-in"></span> Login</a></li>
                        <li><a href="<?= \SoftUni\Helpers\Helpers::url() . 'users/register'?>" class="hvr-underline-reveal"><span class="glyphicon glyphicon-registration-mark"></span> Register</a></li>
                    </ul>
                    <?php else: ?>
                        <ul class="nav navbar-nav">
                            <li><a href="<?= \SoftUni\Helpers\Helpers::url() . 'users/profile'?>" class="hvr-underline-reveal"><span class="glyphicon glyphicon-user"></span> Profile</a></li>
                            <li><a href="<?= \SoftUni\Helpers\Helpers::url() . 'users/buildings'?>"><span class="glyphicon glyphicon-home"></span> Buildings</a></li>
                        </ul>
                        <ul class="nav navbar-nav navbar-right">
                            <li><a href="<?= \SoftUni\Helpers\Helpers::url() . 'users/logout'?>" class="hvr-underline-reveal"><span class="glyphicon glyphicon-log-out"></span> Logout</a></li>
                        </ul>
                    <?php endif; ?>
                </ul>
            </div><!-- /.navbar-collapse -->
        </div><!-- /.container-fluid -->
    </nav>
</header>

<main class="row">