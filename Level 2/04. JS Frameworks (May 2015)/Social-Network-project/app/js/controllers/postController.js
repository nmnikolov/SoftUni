app.controller('postController', function userController($scope, $location, $http, $resource, $log, $routeParams, userService, authentication, postService, notifyService, usSpinnerService) {

    $scope.addPost = function(){

    };

    $scope.likePost = function(postId){
        if(authentication.isLogged()) {
            usSpinnerService.spin('spinner-1');
            postService(authentication.getAccessToken()).like(postId).$promise.then(
                function(data){
                    notifyService.showInfo("Post successfuly liked.");
                    usSpinnerService.stop('spinner-1');
                    //$scope.posts = data;
                },
                function(error){
                    usSpinnerService.stop('spinner-1');
                    notifyService.showError("Unsuccessful like!", error);
                }
            );
        }
    };

    $scope.unlikePost = function(postId){
        if(authentication.isLogged()) {
            usSpinnerService.spin('spinner-1');
            postService(authentication.getAccessToken()).unlike(postId).$promise.then(
                function(data){
                    notifyService.showInfo("Post successfuly unliked.");
                    usSpinnerService.stop('spinner-1');
                    //$scope.posts = data;
                },
                function(error){
                    notifyService.showError("Unsuccessful unlike!", error);
                    usSpinnerService.stop('spinner-1');
                }
            );
        }
    };

});


