app.controller('postController', function userController($scope, $location, $http, $resource, $log, $routeParams, userService, authentication) {

    $scope.addPost = function(){
        if(authentication.isLogged()) {
            userService(authentication.getAccessToken()).getUserWall(authentication.getUsername(), 5).$promise.then(
                function(data){
                    console.log(data);
                    $scope.posts = data;
                },
                function(error, status){
                    $log.warn(status, error);
                }
            );
        }
    };

    if($location.path() === '/me/'){

    }
});


