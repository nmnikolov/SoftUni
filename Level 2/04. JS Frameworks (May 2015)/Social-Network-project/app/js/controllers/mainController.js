app.controller('mainController', function ($scope, $location, $resource, $log, $routeParams, userService, userController, authentication) {

    $scope.login = function(){
        if(!userService.isLogged()){
            userService.login($scope.loginData).$promise.then(
                function(data){
                    authentication.setCredentials(data);
                },
                function(error, status){
                    $log.warn(status, error);
                }
            );
        }
    };

    $scope.logout = function(){
        if(userService.isLogged()){
            userService.logout(a).$promise.then(
                function(){
                    authentication.clearCredentials();
                    $location.redirectTo('/');
                },
                function(error, status){
                    $log.warn(status, error);
                }
            );
        }
    };

    $scope.me = function(){
        authentication.me().$promise.then(
            function(data){
                console.log(data);
            },
            function(error, status){
                $log.warn(status, error);
            }
        );
    };
});