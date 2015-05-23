app.controller('commentController', function ($scope,authentication, commentService, notifyService, usSpinnerService) {

    $scope.addComment = function(post){
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

    $scope.getPostComments = function(post){
        if(authentication.isLogged()) {
            usSpinnerService.spin('spinner-1');

            commentService(authentication.getAccessToken()).getPostComments(post.id).$promise.then(
                function(data){
                    post.comments = data;
                    usSpinnerService.stop('spinner-1');
                },
                function(error){
                    usSpinnerService.stop('spinner-1');
                    notifyService.showError("Unable to retrieve comments!", error);
                }
            );
        }
    };

    $scope.likeComment= function(post, comment){
        if(authentication.isLogged()) {
            usSpinnerService.spin('spinner-1');
            commentService(authentication.getAccessToken()).like(post.id, comment.id).$promise.then(
                function(){
                    notifyService.showInfo("Comment successfuly liked.");
                    usSpinnerService.stop('spinner-1');
                    comment.liked = true;
                    comment.likesCount++;
                },
                function(error){
                    usSpinnerService.stop('spinner-1');
                    notifyService.showError("Unsuccessful like!", error);
                }
            );
        }
    };

    $scope.unlikeComment = function(post, comment){
        if(authentication.isLogged()) {
            usSpinnerService.spin('spinner-1');
            commentService(authentication.getAccessToken()).unlike(post.id, comment.id).$promise.then(
                function(){
                    notifyService.showInfo("Comment successfuly unliked.");
                    usSpinnerService.stop('spinner-1');
                    comment.liked = false;
                    comment.likesCount--;
                },
                function(error){
                    notifyService.showError("Unsuccessful unlike!", error);
                    usSpinnerService.stop('spinner-1');
                }
            );
        }
    };

    $scope.editComment = function(post, comment){
        if(authentication.isLogged()) {
            usSpinnerService.spin('spinner-1');
            commentService(authentication.getAccessToken()).editComment(post.id, comment.id, comment.newCommentContent).$promise.then(
                function(){
                    usSpinnerService.stop('spinner-1');
                    notifyService.showInfo("Comment successfuly edited.");
                    comment.commentContent = comment.newCommentContent;
                },
                function(error){
                    notifyService.showError("Unsuccessful comment edit!", error);
                    usSpinnerService.stop('spinner-1');
                }
            );
        }
    };

    $scope.deleteComment = function(post, comment){
        if(authentication.isLogged()) {
            usSpinnerService.spin('spinner-1');
            commentService(authentication.getAccessToken()).removeComment(post.id, comment.id).$promise.then(
                function(){
                    var index =  post.comments.indexOf(comment);
                    post.comments.splice(index, 1);
                    post.totalCommentsCount--;
                    usSpinnerService.stop('spinner-1');
                    notifyService.showInfo("Comment successfuly removed.");
                },
                function(error){
                    notifyService.showError("Unsuccessful comment edit!", error);
                    usSpinnerService.stop('spinner-1');
                }
            );
        }
    };
});