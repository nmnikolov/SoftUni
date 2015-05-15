app.factory('profileService', function($http, $q, $resource, BASE_URL){    return function(token){        $http.defaults.headers.common['Authorization'] = 'Bearer ' + token;        var profile = {},            resource = $resource(                BASE_URL + 'me/:option1/:option2',                { action1: '@option1', action2: '@option2' },                {                    edit: {                        method: 'PUT'                    }                }            );        profile.me = function(){            return resource.get();        };        profile.update = function(data, action1){            return resource.edit({action1: action1}, data);        };        profile.getNewsFeed = function(pageSize, startPostId){            var option1 = 'feed?StartPostId' + (startPostId ? "=" + startPostId : "") + "&PageSize=" + pageSize;            return resource.query({ option1: option1});        };        return profile;    }});