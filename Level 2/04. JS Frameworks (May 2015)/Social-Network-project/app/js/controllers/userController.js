app.controller('userController', function userController($scope, $location, $http, $resource, $log, $routeParams, userService, authentication, profileService) {
    $scope.login = function(){
        if(!authentication.isLogged()){
            userService().login($scope.loginData).$promise.then(
                function(data){
                    authentication.setCredentials(data);
                    $location.path('/');
                },
                function(error, status){
                    $log.warn(status, error);
                }
            );
        }
    };

    $scope.register = function(){
        if(!authentication.isLogged()){
            userService().register($scope.registerData).$promise.then(
                function(data){
                    authentication.setCredentials(data);
                    $location.path('/');
                },
                function(error, status){
                    $log.warn(status, error);
                }
            );
        }
    };

    $scope.logout = function(){
        if(authentication.isLogged()){
            userService(authentication.getAccessToken()).logout().$promise.then(
                function(){
                    authentication.clearCredentials();
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

    $scope.getUserWall = function(){
        if(authentication.isLogged()) {
            userService(authentication.getAccessToken()).getUserWall(authentication.getUsername(), 5).$promise.then(
                function(data){
                    $scope.posts = data;
                },
                function(error, status){
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
        $scope.getUserWall($routeParams['username']);
    }
});