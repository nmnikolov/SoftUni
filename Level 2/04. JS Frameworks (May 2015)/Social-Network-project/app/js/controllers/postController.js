app.controller('postController', function userController($scope, $location, $http, $resource, $log, $routeParams, userService, authentication, postService, notifyService) {

    $scope.addPost = function(){

    };

    $scope.likePost = function(postId){
        if(authentication.isLogged()) {
            postService(authentication.getAccessToken()).like(postId).$promise.then(
                function(data){
                    notifyService.showInfo("Post successfuly liked.");
                    //$scope.posts = data;
                },
                function(error, status){
                    $log.warn(status, error);
                    notifyService.showError("Unsuccessful like!", error);
                }
            );
        }
    };

    $scope.unlikePost = function(postId){
        if(authentication.isLogged()) {
            postService(authentication.getAccessToken()).unlike(postId).$promise.then(
                function(data){
                    notifyService.showInfo("Post successfuly unliked.");
                    //$scope.posts = data;
                },
                function(error, status){
                    $log.warn(status, error);
                    notifyService.showError("Unsuccessful unlike!", error);
                }
            );
        }
    };

});


