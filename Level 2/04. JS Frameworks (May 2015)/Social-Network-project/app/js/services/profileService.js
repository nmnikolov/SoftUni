app.factory('profileService', function($http, $q, $resource, BASE_URL, authentication){
    return function(token){
        $http.defaults.headers.common['Authorization'] = 'Bearer ' + token;

        var profile = {},
            resource = $resource(
                BASE_URL + 'me/:action1/:action2',
                { action1: '@action1', action2: '@action2' },
                {
                    edit: {
                        method: 'PUT'
                    }
                }
            );

        profile.me = function(){
            return resource.get();
        };

        profile.update = function(data, action1){
            return resource.edit({action1: action1}, data);
        };

        return profile;
    }
});
