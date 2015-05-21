app.controller('postController', function ($scope, $log, $routeParams, userService, authentication, postService, notifyService, usSpinnerService) {

    $scope.addPost = function(){
        $scope.postData.username = $routeParams['username'];
        if(authentication.isLogged()) {
            usSpinnerService.spin('spinner-1');
            postService(authentication.getAccessToken()).addPost($scope.postData).$promise.then(
                function(data){
                    $scope.postData.postContent = "";
                    $scope.posts.unshift(data);
                    notifyService.showInfo("Post successfuly added.");
                    usSpinnerService.stop('spinner-1');
                },
                function(error){
                    usSpinnerService.stop('spinner-1');
                    notifyService.showError("Unsuccessful post add!", error);
                }
            );
        }
    };

    $scope.likePost = function(post){
        if(authentication.isLogged()) {
            usSpinnerService.spin('spinner-1');
            postService(authentication.getAccessToken()).like(post.id).$promise.then(
                function(){
                    notifyService.showInfo("Post successfuly liked.");
                    usSpinnerService.stop('spinner-1');
                    post.liked = true;
                    post.likesCount++;
                },
                function(error){
                    usSpinnerService.stop('spinner-1');
                    notifyService.showError("Unsuccessful like!", error);
                }
            );
        }
    };

    $scope.unlikePost = function(post){
        if(authentication.isLogged()) {
            usSpinnerService.spin('spinner-1');
            postService(authentication.getAccessToken()).unlike(post.id).$promise.then(
                function(){
                    notifyService.showInfo("Post successfuly unliked.");
                    usSpinnerService.stop('spinner-1');
                    post.liked = false;
                    post.likesCount--;
                },
                function(error){
                    notifyService.showError("Unsuccessful unlike!", error);
                    usSpinnerService.stop('spinner-1');
                }
            );
        }
    };
});


