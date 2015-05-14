app.controller('profileController', function ($scope, $location, $resource, $log, $routeParams, profileService, authentication) {

    var getUserDetails = function(){
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

    getUserDetails();
    //
    //var getProfileInformation = function(){
    //    if(authentication.isLogged()) {
    //        profileService(authentication.getAccessToken()).me().$promise.then(
    //            function (data) {
    //                $scope.me = data;
    //                console.log($scope.me);
    //            },
    //            function (error, status) {
    //                $log.warn(status, error);
    //            }
    //        );
    //    }
    //};
    //
    //getProfileInformation();
});