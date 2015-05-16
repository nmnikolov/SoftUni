app.controller('userController', function userController($scope, $location, $http, $resource, $log, $routeParams, userService, authentication, profileService, notifyService, PAGE_SIZE) {
    var feedStartPostId;
    $scope.posts = [];
    $scope.busy = false;

    $scope.login = function(){
        if(!authentication.isLogged()){
            userService().login($scope.loginData).$promise.then(
                function(data){
                    authentication.setCredentials(data);
                    notifyService.showInfo("Welcome, " + data.userName + "!");
                    $location.path('/');
                },
                function(error){
                    notifyService.showError("Unsuccessful login!", error);
                }
            );
        }
    };

    $scope.register = function(){
        if(!authentication.isLogged()){
            userService().register($scope.registerData).$promise.then(
                function(data){
                    authentication.setCredentials(data);
                    notifyService.showInfo("Welcome, " + data.userName + "!");
                    $location.path('/');
                },
                function(error){
                    notifyService.showError("Unsuccessful register!", error);
                }
            );
        }
    };

    $scope.logout = function(){
        if(authentication.isLogged()){
            userService(authentication.getAccessToken()).logout().$promise.then(
                function(){
                    authentication.clearCredentials();
                    notifyService.showInfo("Good bye.");
                    $location.path('/');
                },
                function(error, status){
                    $log.warn(status, error);
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

            userService(authentication.getAccessToken()).getUserWall(authentication.getUsername(), PAGE_SIZE, feedStartPostId).$promise.then(
                function (data) {
                    $scope.posts = $scope.posts.concat(data);
                    if($scope.posts.length > 0){
                        feedStartPostId = $scope.posts[$scope.posts.length - 1].id;
                    }
                    $scope.busy = false;
                },
                function (error, status) {
                    $log.warn(status, error);
                }
            );
        }
    };

    $scope.changePassword = function(){
        if(authentication.isLogged()){
            userService(authentication.getAccessToken()).edit($scope.passwordUpdate).$promise.then(
                function(){
                    $location.path('/');
                },
                function(error, status){
                    $log.warn(status, error);
                }
            );
        }
    };

    if($routeParams['username'] && $location.path() === '/' + $routeParams['username'] +  '/wall/'){
        //$scope.getUserWall($routeParams['username']);
    }
});