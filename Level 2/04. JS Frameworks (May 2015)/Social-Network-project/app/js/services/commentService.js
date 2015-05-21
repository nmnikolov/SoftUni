app.factory('commentService', function($http, $q, $resource, BASE_URL){
    return function(token){
        $http.defaults.headers.common['Authorization'] = 'Bearer ' + token;

        var comment = {},
            resource = $resource(
                BASE_URL + 'Posts/:option1/comments/:option2/:option3',
                {
                    option1: '@option1',
                    option2: '@option2',
                    option3: '@option3'
                }
            );

        comment.addComment = function(posttId, commentData){
            return resource.save({option1: posttId}, commentData);
        };

        comment.like = function(postId, commentId){
            return resource.save({option1: postId, option2: commentId, option3: "likes"})
        };

        comment.unlike = function(postId, commentId){
            return resource.remove({option1: postId, option2: commentId, option3: "likes"})
        };

        return comment;
    }
});