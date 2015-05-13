app.factory('userService', function($http, $q, $resource, BASE_URL, authentication){
    return function(token){
        $http.defaults.headers.common['Authorization'] = 'Bearer ' + token;

        var user = {},
            resource = $resource(
                BASE_URL + 'users/:action',
                { action: '@action' },
                {
                    update: {
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

        user.edit = function(){

        };

        user.logout = function(){
            return resource.save({action: 'logout'});
        };

        user.me = function(){
            return resource.get({action: 'me'});
        };

        user.isLogged = function(){
            return authentication.isLogged();
        };

        return user;
    }
});

//headers: { 'Authorization': 'Bearer' + user.isLogged()},
