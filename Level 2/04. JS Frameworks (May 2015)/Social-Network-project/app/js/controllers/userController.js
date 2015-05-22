app.controller('userController', function userController($scope, $location, $log, $routeParams, userService, authentication, profileService, notifyService, PAGE_SIZE, $timeout, usSpinnerService) {
    var feedStartPostId;
    $scope.posts = [];
    $scope.busy = false;

    $scope.login = function(){
        if(!authentication.isLogged()){
            usSpinnerService.spin('spinner-1');
            userService().login($scope.loginData).$promise.then(
                function(data){
                    usSpinnerService.stop('spinner-1');
                    authentication.setCredentials(data);
                    notifyService.showInfo("Welcome, " + data.userName + "!");
                    $location.path('/');
                },
                function(error){
                    usSpinnerService.stop('spinner-1');
                    notifyService.showError("Unsuccessful login!", error);
                }
            );
        }
    };

    $scope.register = function(){
        if(!authentication.isLogged()){
            usSpinnerService.spin('spinner-1');
            userService().register($scope.registerData).$promise.then(
                function(data){
                    usSpinnerService.stop('spinner-1');
                    authentication.setCredentials(data);
                    notifyService.showInfo("Welcome, " + data.userName + "!");
                    $location.path('/');
                },
                function(error){
                    usSpinnerService.stop('spinner-1');
                    notifyService.showError("Unsuccessful register!", error);
                }
            );
        }
    };

    $scope.logout = function(){
        if(authentication.isLogged()){
            usSpinnerService.spin('spinner-1');
            userService(authentication.getAccessToken()).logout().$promise.then(
                function(){
                    usSpinnerService.stop('spinner-1');
                    authentication.clearCredentials();
                    notifyService.showInfo("Good bye.");
                    $location.path('/');
                },
                function(error){
                    usSpinnerService.stop('spinner-1');
                    notifyService.showError("Unsuccessful logout!", error);
                }
            );
        }
    };

    $scope.me = function(){
        if(authentication.isLogged()) {
            profileService(authentication.getAccessToken()).me().$promise.then(
                function (data) {
                },
                function (error, status) {
                    $log.warn(status, error);
                }
            );
        }
    };

    $scope.loadUserWall = function(){
        if(authentication.isLogged()) {
            if ($scope.busy){
                return;
            }
            $scope.busy = true;
            usSpinnerService.spin('spinner-1');
            userService(authentication.getAccessToken()).getUserWall($routeParams['username'], PAGE_SIZE, feedStartPostId).$promise.then(
                function (data) {
                    $scope.posts = $scope.posts.concat(data);
                    if($scope.posts.length > 0){
                        feedStartPostId = $scope.posts[$scope.posts.length - 1].id;
                    }

                    $scope.busy = false;
                    usSpinnerService.stop('spinner-1');
                },
                function (error) {
                    usSpinnerService.stop('spinner-1');
                    notifyService.showError("Error loading user wall!", error);
                }
            );
        }
    };

    $scope.changePassword = function(){
        if(authentication.isLogged()){
            usSpinnerService.spin('spinner-1');
            userService(authentication.getAccessToken()).edit($scope.passwordUpdate).$promise.then(
                function(){
                    usSpinnerService.stop('spinner-1');
                    $location.path('/');
                },
                function(error){
                    usSpinnerService.stop('spinner-1');
                    notifyService.showError("Unsuccessful password change!", error);
                }
            );
        }
    };

    $scope.searchUser = function(){
        if(authentication.isLogged() && $scope.searchTerm.trim() !== ""){
            userService(authentication.getAccessToken()).searchUser($scope.searchTerm).$promise.then(
                function(data){
                    $scope.searchResults = data;
                },
                function(error, status){
                    $log.warn(status, error);
                }
            );
        } else {
            $scope.searchResults = undefined;
        }
    };

    $scope.getWallOwner = function(){
        if (authentication.isLogged()) {
            usSpinnerService.spin('spinner-1');
            userService(authentication.getAccessToken()).getUserFullData($routeParams['username']).$promise.then(
                function(data){
                    $scope.wallOwner = data;
                    if(authentication.getUsername() !== data.username){
                        if(data.isFriend){
                            $scope.wallOwner.status = 'friend';
                        } else if(data.hasPendingRequest){
                            $scope.wallOwner.status = 'pending';
                        } else {
                            $scope.wallOwner.status = 'invite';
                        }
                    }

                    if($scope.wallOwner.isFriend && $location.path() === '/user/' + $routeParams['username'] + '/wall/'){
                        $scope.getUserFriendsListPreview();
                    }
                },
                function(error){
                    usSpinnerService.stop('spinner-1');
                    notifyService.showError("Unsuccessful user load!", error);
                }
            );
        }
    };

    $scope.clearSearchResults = function(){
        $timeout(function() {
            $scope.searchResults = undefined;
            $scope.searchTerm = "";
        }, 300);
    };

    $scope.showUserPreview = function(username){
        $scope.previewData = {};
        if (authentication.isLogged()){
            usSpinnerService.spin('spinner-1');

            userService(authentication.getAccessToken()).getUserPreviewData(username).$promise.then(
                function(data){
                    $scope.previewData = {
                        image: data.profileImageData ? data.profileImageData : $scope.defaultImage,
                        name: data.name,
                        username: data.username,
                        status: false
                    };

                    if(authentication.getUsername() !== data.username){
                        if(data.isFriend){
                            $scope.previewData.status = 'friend';
                        } else if(data.hasPendingRequest){
                            $scope.previewData.status = 'pending';
                        } else {
                            $scope.previewData.status = 'invite';
                        }
                    }

                    usSpinnerService.stop('spinner-1');
                },
                function(error){
                    usSpinnerService.stop('spinner-1');
                    notifyService.showError("Unsuccessful register!", error);
                }
            );
        }
    };

    $scope.getUserFriendsListPreview = function(){
        if(authentication.isLogged()) {
            usSpinnerService.spin('spinner-1');
            userService(authentication.getAccessToken()).getUserFriendsPreview($routeParams['username']).$promise.then(
                function (data) {
                    data.userFriendsUrl = '#/friends/';
                    $scope.friendsListPreview = data;
                    usSpinnerService.stop('spinner-1');
                },
                function (error) {
                    usSpinnerService.stop('spinner-1');
                }
            );
        }
    };
});