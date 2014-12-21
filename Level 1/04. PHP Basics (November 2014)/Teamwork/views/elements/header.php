<?php $loggedUser = \Lib\Auth::get_instance()->get_logged_user(); ?>

<!DOCTYPE html>
<html>
<head>
    <title><?php echo $title ?></title>
    <meta charset="utf-8">
    <link type="text/css" href="<?php echo DX_ROOT_URL . 'styles/style.css'; ?>" rel="stylesheet" />
    <script type="text/javascript" src="<?php echo DX_ROOT_URL . 'js/jquery.js' ?>" defer></script>
    <script type="text/javascript" src="<?php echo DX_ROOT_URL . 'js/js.js' ?>" defer></script>
</head>
<body>
    <div id="container">
        <header>
            <div id="header-wrapper">
                <div id="header-image">
                    <img src="<?php echo DX_ROOT_URL . "resources/images/header.png" ?>" alt="Header image">
                </div>
                <div id="header-menu">
                    <nav id="top-menu">
                        <ul>
                            <li><a href="index.php"><div>Forum</div></a></li>
                            <li><a href="members.php"><div>Members</div></a></li>
                            <?php if ( empty ($loggedUser) ): ?>
                                <li><a href="login.php"><div>Login</div></a></li>
                                <li><a href="register.php"><div>Register</div></a></li>
                            <?php else: ?>
                                <li><a href="<?php echo DX_ROOT_URL . 'profile.php?mid=' . $_SESSION['user_id'] ?>">Profile</a></li>
                                <?php if($loggedUser['role_id'] === 1): ?>
                                    <li><a href="<?php echo DX_ROOT_URL . 'admin.php' ?>">Admin</a></li>
                                <?php endif; ?>
                                <li><a href="<?php echo DX_ROOT_URL; ?>index.php?logout=1">Logout</a></li>
                            <?php endif; ?>



<!--                            <input type="button" id="search-toggle" value="">-->



                        </ul>

                        <button id="search-toggle">
                            <svg id="search-toggle-show" width="34" height="34" xmlns="http://www.w3.org/2000/svg">
                                <!-- Created with SVG-edit - http://svg-edit.googlecode.com/ -->
                                <g>
                                    <path id="svg_5" d="m33.76561,29.28834l-9.02999,-9.02999c1.2165,-2.00596 1.92993,-4.3528 1.9312,-6.86943c-0.00128,-7.34083 -5.94565,-13.28648 -13.28269,-13.28901c-7.33828,0.00253 -13.28519,5.94818 -13.28519,13.28774c0,7.33576 5.94692,13.2814 13.28521,13.2814c2.51791,0 4.86474,-0.71343 6.8707,-1.92993l9.03252,9.03126l4.47823,-4.48205zm-28.59919,-15.90069c0.0076,-4.53907 3.67865,-8.20886 8.21645,-8.21899c4.53527,0.01014 8.20886,3.67992 8.21645,8.21899c-0.00887,4.53654 -3.68118,8.20632 -8.21645,8.21645c-4.53781,-0.01015 -8.20885,-3.67993 -8.21645,-8.21645z" stroke-linecap="square" stroke-linejoin="bevel" stroke-width="0" stroke="#000000" fill="#ffffff"></path>
                                </g>
                            </svg>

                            <svg id="search-toggle-hide" width="34" height="34" xmlns="http://www.w3.org/2000/svg">
                                <!-- Created with SVG-edit - http://svg-edit.googlecode.com/ -->
                                <g>
                                    <path transform="rotate(-90 16.9705924987793,16.75757598876953) " id="svg_6" d="m13.06599,33.06723c-0.92033,-0.90709 -0.79983,-1.45632 1.43788,-6.54112c1.12978,-2.56725 2.05409,-4.74275 2.05409,-4.83386c0,-0.09112 -3.11979,-0.1657 -6.93315,-0.1657l-6.93313,0l0,-4.80875l0,-4.80831l6.98805,0c5.38837,0 6.92818,-0.14485 6.72569,-0.63294c-0.1446,-0.34793 -1.13014,-2.657 -2.19036,-5.13157c-1.9985,-4.66409 -1.99789,-5.91481 0.00317,-6.30263c0.99566,-0.19293 16.49852,14.63179 17.0313,16.28669c-5.16374,5.9082 -11.33636,12.09264 -17.0224,17.54562c-0.29963,0 -0.82232,-0.27354 -1.16112,-0.60744z" stroke-linecap="square" stroke-linejoin="bevel" stroke-width="0" stroke="#000000" fill="#ffffff"></path>
                                </g>
                            </svg>
                        </button>

                        <?php if( ! empty ($loggedUser)): ?>
                            <div id="user-center">
                                <p>
                                    Welcome, <?php echo $loggedUser['username']; ?>!
                                </p>
                            </div>
                        <?php endif; ?>
                        
                    </nav>
                </div>
                <div id="header-search">
                    <form method="get" action="<?php echo DX_ROOT_URL . 'search.php' ; ?>" id="search-form" class="hide" >
                        <div>
                            <input type="text" name="search" id="search-text" placeholder="Search..."/>
                            <input type="submit" id="search-submit" value=""/>
                        </div>
                    </form>
                    <?php if(! empty($loggedUser)): ?>
                </div>
                <div id="navigation-bar">
                    <div id="topic-button" >
                        <input type="button" class="button" value="Add Question" onclick="location.href='<?php echo DX_ROOT_URL . 'addTopic.php'?>'"/>
                    </div>
                </div>
                <?php endif; ?>
            </div>
        </header>
        <div id="main">
            <div id="main-wrapper">
