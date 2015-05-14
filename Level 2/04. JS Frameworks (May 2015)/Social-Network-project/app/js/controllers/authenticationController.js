app.controller('authenticationController', function ($scope, $location, $resource, $log, $routeParams, authentication) {
    $scope.isLogged = function(){
        return authentication.isLogged();
    }
});