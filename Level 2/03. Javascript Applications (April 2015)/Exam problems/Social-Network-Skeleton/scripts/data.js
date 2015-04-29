var app = app || {};

app.data = (function(){
    function Data(ajaxRequester){
        this.users = new Users.get(ajaxRequester);
        this.posts = new Posts.get(ajaxRequester);
    }

    var credentials = (function(ajaxRequester){
        function getHeaders(){
            var PARSE_APP_ID = '0iXP7n8Fyza24DE7rGAwiDpNN1w4X7Zy0TN6OVzh';
            var PARSE_REST_API_KEY = 'wvf0rKjAq14NtmwGRHmbN1FB21lzmbS9cxVZQB2y';

            var headers = {
                'X-Parse-Application-Id': PARSE_APP_ID,
                'X-Parse-REST-API-Key': PARSE_REST_API_KEY,
                'Content-Type': 'application/json'
                },

                sessionToken = this.getSessionToken();


            if (sessionToken) {
                headers['X-Parse-Session-Token'] = sessionToken;
            }

            return headers;
        }

        function getSessionToken(){
               return sessionStorage['sessionToken'] ? sessionStorage['sessionToken'] : undefined;
        }

        function setSessionToken(sessionToken){
            sessionStorage['sessionToken'] = sessionToken;
        }

        function getUserId(){
            return sessionStorage['userId'] ? sessionStorage['userId'] : undefined;
        }

        function setUserId(userId){
            sessionStorage['userId'] = userId;
        }

        function getUsername(){
            return sessionStorage['username'] ? sessionStorage['username'] : undefined;
        }

        function setUsername(username){
            sessionStorage['username'] = username;
        }

        function clearStorage(){
            sessionStorage.clear();
        }

        return {
            getHeaders: getHeaders,
            getSessionToken: getSessionToken,
            setSessionToken: setSessionToken,
            getUserId: getUserId,
            setUserId: setUserId,
            getUsername: getUsername,
            setUsername: setUsername,
            clearStorage: clearStorage
        }

    }());

    var Users = (function(ajaxRequester){
        function Users(ajaxRequester) {
            this._requester = ajaxRequester;
        }

        Users.prototype.login = function(username, password){
            var defer = Q.defer();
            this._requester.get('login?username=' + username + '&password=' + password, credentials.getHeaders())
                .then(function (data) {
                    credentials.setSessionToken(data.sessionToken);
                    credentials.setUserId(data.objectId);
                    credentials.setUsername(data.username);

                    defer.resolve(data);
                }, function (error) {
                    defer.reject(error);
                });

            return defer.promise;
        };

        Users.prototype.register = function(userData){
            var defer = Q.defer();

            this._requester.post('users', credentials.getHeaders(), userData)
                .then(function(data){
                    credentials.setSessionToken(data.sessionToken);
                    credentials.setUserId(data.objectId);
                    credentials.setUsername(userData.username);
                    defer.resolve(data);
                },function(error){
                    defer.reject(error);
                });

            return defer.promise;
        };

        Users.prototype.editProfile = function(userId, userData){
            var defer = Q.defer();

            this._requester.put('users/', userId, userData, this.credentials.getHeaders())
                .then(function (data) {
                    credentials.clearStorage();

                    defer.resolve(data);
                }, function (error) {
                    defer.reject(error);
                });

            return defer.promise;
        };

        Users.prototype.getById = function(id){
            var defer = Q.defer();

            this._requester.get('users/' + id, credentials.getHeaders())
                .then(function (data) {
                    defer.resolve(data);
                }, function (error) {
                    defer.reject(error);
                });

            return defer.promise;
        };

        Users.prototype.getCurrentUserData = function(){
            var defer = Q.defer(),
                userData = {
                    userId: credentials.getUserId(),
                    username: credentials.getUsername(),
                    sessionToken: credentials.getSessionToken()
                };

            defer.resolve(userData);

            return defer.promise;
        };

        Users.prototype.logout = function(){
            var defer = Q.defer();
            this._requester.post('logout', credentials.getHeaders())
                .then(function (data) {
                    credentials.clearStorage();
                    defer.resolve(data);
                }, function (error) {
                    defer.reject(error);
                });

            return defer.promise;
        };

        Users.prototype.isLogged = function(){
            return credentials.getSessionToken();
        };

        Users.prototype.validateToken = function (sessionToken) {
            var defer = Q.defer();
            var _this = this;

            this._requester.get('users/me', credentials.getHeaders())
                .then(function(data){
                    defer.resolve(data === sessionToken);
                }, function(error){
                    defer.reject(error);
                });

            return defer.promise;
        };

        return {
            get: function (ajaxRequester) {
                return new Users(ajaxRequester);
            }
        }
    }());

    var Posts = (function(ajaxRequester){
        var SERVICE_URL = 'classes/Post';

        function Posts(ajaxRequester) {
            this._requester = ajaxRequester;
        }

        return {
            get: function (ajaxRequester) {
                return new Posts(ajaxRequester);
            }
        }
    }());

    return {
        get: function (ajaxRequester) {
            return new Data(ajaxRequester);
        }
    }
}());