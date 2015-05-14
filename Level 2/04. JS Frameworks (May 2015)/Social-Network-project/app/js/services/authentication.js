app.factory('authentication', function($http, $q, $resource, BASE_URL){
    var authentication = {};

    authentication.isLogged = function(){
        return localStorage['accessToken'] !== undefined;
    };

    authentication.setCredentials = function (data) {
        localStorage.setItem('accessToken', data['access_token']);
        localStorage.setItem('username', data['userName']);
    };

    authentication.clearCredentials = function () {
        localStorage.removeItem('accessToken');
        localStorage.removeItem('username');
    };

    authentication.getAccessToken = function(){
        return localStorage.getItem('accessToken');
    };

    authentication.getUsername = function(){
        return localStorage.getItem('username');
    };

    return authentication;
});