app.factory('userService', function($http, $q, $resource, BASE_URL, authentication){
    return function(token){
        $http.defaults.headers.common['Authorization'] = 'Bearer ' + token;

        var user = {},
            resource = $resource(
                BASE_URL + 'users/:action1/:action2',
                {
                    action1: '@action1',
                    action2: '@action2'
                },
                {
                    edit: {
                        method: 'PUT'
                    }
                }
            );

        user.login = function(loginData){
            return resource.save({action1: 'login'}, loginData);
        };

        user.register = function(registerData){
            return resource.save({action1: 'register'}, registerData);
        };

        user.logout = function(){
            return resource.save({action1: 'logout'});
        };

        user.getUserWall = function(username, pageSize, startPostId){
            var action2 = 'wall?StartPostId' + (startPostId ? "=" + startPostId : "") + "&PageSize=" + pageSize;

            return resource.query({ action1: username, action2: action2});
        };

        user.searchUser = function(searchTerm){
            var action1 = "search?searchTerm=" + searchTerm;

            return resource.query({ action1: action1 });
        };

        user.getUserFullData = function(username){
            var action1 = username;

            return resource.get({ action1: username });
        };

        user.isLogged = function(){
            return authentication.isLogged();
        };

        return user;
    }
});