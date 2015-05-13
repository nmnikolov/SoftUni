app.factory('authentication', function($http, $q, $resource, BASE_URL){
    var authentication = {};

    var resource = $resource(
        BASE_URL + 'me',
        {},
        {
            get:{
                method: "Get",
                headers: { 'Authorization': ("Bearer " + localStorage.getItem('accessToken'))}
            }
        }
    );

    authentication.isLogged = function(){
        return localStorage['accessToken'];
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

    authentication.me = function(){
        if(this.isLogged()){
            return resource.get();
        }
    };

    return authentication;

});