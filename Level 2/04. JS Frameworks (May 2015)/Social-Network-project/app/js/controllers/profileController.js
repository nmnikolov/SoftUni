app.controller('profileController', function ($scope, $location, $resource, $log, $routeParams, profileService, authentication) {

    var feedStartPostId;

    $scope.getUserDetails = function(){
        if(authentication.isLogged()) {
            profileService(authentication.getAccessToken()).me().$promise.then(
                function (data) {
                    $scope.me = data;
                },
                function (error, status) {
                    $log.warn(status, error);
                }
            );
        }
    };


    $scope.editDetails = function(){
        if(authentication.isLogged()) {
            profileService(authentication.getAccessToken()).update($scope.me).$promise.then(
                    function (data) {
                        //TODO: Noty message
                    },
                    function (error, status) {
                        $log.warn(status, error);
                    }
                );
        }
    };

    $scope.editPassword = function(){
        if(authentication.isLogged()) {
            profileService(authentication.getAccessToken()).update($scope.passwordUpdate, 'changepassword').$promise.then(
                function (data) {
                    //TODO: Noty message
                    $location.path('/');
                },
                function (error, status) {
                    $log.warn(status, error);
                }
            );
        }
    };

    $scope.getNewsFeed = function(){
        if(authentication.isLogged()) {
            profileService(authentication.getAccessToken()).getNewsFeed(5, feedStartPostId).$promise.then(
                function (data) {
                    $scope.posts = data;
                },
                function (error, status) {
                    $log.warn(status, error);
                }
            );
        }
    };

    if($location.path() === '/settings/edit/details/'){
        $scope.getUserDetails();
    }

    if($location.path() === '/'){
        $scope.getNewsFeed();
    }
});