app.factory('postService', function($http, $q, $resource, BASE_URL, authentication){
    return function(token){
        $http.defaults.headers.common['Authorization'] = 'Bearer ' + token;

        var post = {},
            resource = $resource(
                BASE_URL + 'Posts/:option1/:option2/:option3',
                {
                    option1: '@option1',
                    option2: '@option2',
                    option3: '@option3'
                }
            );

        post.add = function(postData){
            return resource.save(postData);
        };

        return post;
    }
});