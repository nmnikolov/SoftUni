app.controller('commentController', function ($scope, $log, authentication, commentService, notifyService, usSpinnerService) {

    $scope.addComment = function(post){
        console.log(post);
        if(authentication.isLogged()) {
            usSpinnerService.spin('spinner-1');
            commentService(authentication.getAccessToken()).addComment(post.id, $scope.commentData).$promise.then(
                function(data){
                    $scope.commentData.commentContent = "";
                    post.comments.unshift(data);
                    post.totalCommentsCount++;
                    notifyService.showInfo("Comment successfuly added.");
                    usSpinnerService.stop('spinner-1');
                },
                function(error){
                    usSpinnerService.stop('spinner-1');
                    notifyService.showError("Unsuccessful comment add!", error);
                }
            );
        }
    };

    $scope.likeComment= function(post){
        if(authentication.isLogged()) {
            usSpinnerService.spin('spinner-1');
            commentService(authentication.getAccessToken()).like(post.id).$promise.then(
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
    //
    //$scope.unlikeComment = function(post){
    //    if(authentication.isLogged()) {
    //        usSpinnerService.spin('spinner-1');
    //        postService(authentication.getAccessToken()).unlike(post.id).$promise.then(
    //            function(){
    //                notifyService.showInfo("Post successfuly unliked.");
    //                usSpinnerService.stop('spinner-1');
    //                post.liked = false;
    //                post.likesCount--;
    //            },
    //            function(error){
    //                notifyService.showError("Unsuccessful unlike!", error);
    //                usSpinnerService.stop('spinner-1');
    //            }
    //        );
    //    }
    //};
});


