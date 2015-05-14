app.controller('userController', function userController($scope, $location, $http, $resource, $log, $routeParams, userService, authentication) {
    $scope.login = function(){
        if(!authentication.isLogged()){
            userService().login($scope.loginData).$promise.then(
                function(data){
                    authentication.setCredentials(data);
                    //$scope.isLogged();
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
            authentication.me().$promise.then(
                function (data) {
                    console.log(data);
                },
                function (error, status) {
                    $log.warn(status, error);
                }
            );
        }
    };

    $scope.isLogged = function(){
        return authentication.isLogged();

    };
    $scope.changePassword = function(){
        if(authentication.isLogged()){
            userService(authentication.getAccessToken()).edit($scope.passwordUpdate).$promise.then(
                function(data){
                    //authentication.clearCredentials();
                    console.log(data);
                    $location.path('/');
                },
                function(error, status){
                    $log.warn(status, error);
                }
            );
        }
    };
});