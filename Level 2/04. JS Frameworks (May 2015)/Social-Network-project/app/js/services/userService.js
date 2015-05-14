app.factory('userService', function($http, $q, $resource, BASE_URL, authentication){
    return function(token){
        $http.defaults.headers.common['Authorization'] = 'Bearer ' + token;

        var user = {},
            resource = $resource(
                BASE_URL + 'users/:action',
                { action: '@action' },
                {
                    edit: {
                        method: 'PUT'
                    }
                }
            );

        user.login = function(loginData){
            return resource.save({action: 'login'}, loginData);
        };

        user.register = function(registerData){
            return resource.save({action: 'register'}, registerData);
        };

        user.logout = function(){
            return resource.save({action: 'logout'});
        };

        user.isLogged = function(){
            return authentication.isLogged();
        };

        return user;
    }
});