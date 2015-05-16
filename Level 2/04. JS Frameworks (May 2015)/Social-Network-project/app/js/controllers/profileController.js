app.controller('profileController', function ($scope, $location, $resource, $log, $routeParams, profileService, authentication, notifyService, PAGE_SIZE) {
    var feedStartPostId;
    $scope.posts = [];
    $scope.busy = false;

    $scope.getUserDetails = function(){
        if(authentication.isLogged()) {
            profileService(authentication.getAccessToken()).me().$promise.then(
                function (data) {
                    $scope.me = data;
                },
                function (error) {
                    notifyService.showError("Unsuccessful Connection to Database!", error)
                }
            );
        }
    };

    $scope.editDetails = function(){
        if(authentication.isLogged()) {
            profileService(authentication.getAccessToken()).update($scope.me).$promise.then(
                function () {
                    notifyService.showInfo('Profile successfully edited.');
                },
                function (error) {
                    notifyService.showError('Unsuccessful update!', error);
                }
            );
        }
    };

    $scope.editPassword = function(){
        if(authentication.isLogged()) {
            profileService(authentication.getAccessToken()).update($scope.passwordUpdate, 'changepassword').$promise.then(
                function () {
                    notifyService.showInfo('Password successfully changed.');
                    $location.path('/');
                },
                function (error) {
                    notifyService.showError('Unsuccessful password change!', error);
                }
            );
        }
    };

    $scope.loadNewsFeed = function(){
        if(authentication.isLogged()) {
            if ($scope.busy){
                return;
            }
            $scope.busy = true;

            profileService(authentication.getAccessToken()).getNewsFeed(PAGE_SIZE, feedStartPostId).$promise.then(
                function (data) {
                    $scope.posts = $scope.posts.concat(data);
                    if($scope.posts.length > 0){
                        feedStartPostId = $scope.posts[$scope.posts.length - 1].id;
                    }
                    $scope.busy = false;
                },
                function (error, status) {
                    $log.warn(status, error);
                }
            );
        }
    };

    $scope.getOwnFiendsList = function(){
        if(authentication.isLogged()) {
            profileService(authentication.getAccessToken()).getFriendsList().$promise.then(
                function (data) {
                    $scope.friendsList = data;
                },
                function (error, status) {
                    $log.warn(status, error);
                }
            );
        }
    };

    $scope.uploadProfileImage = function(event){
        var file = event.target.files[0],
            reader;

        if(!file.type.match(/image\/.*/)){
            $('.picture-preview').attr('src', '');
            $scope.me.profileImageData = undefined;
            notifyService.showError("Invalid file format.");
        } else if(file.size > 131072) {
            $('.picture-preview').attr('src', '');
            $scope.me.profileImageData = undefined;
            notifyService.showError("File size limit exceeded.");
        } else {
            reader = new FileReader();
            reader.onload = function() {
                $('.picture-preview').attr('src', reader.result);
                $('#profile-image').attr('data-picture-data', reader.result);
                $scope.me.profileImageData = reader.result;
            };
            reader.readAsDataURL(file);
        }
    };

    $scope.clickUpload = function(){
        angular.element('#profile-image').trigger('click');
    };

    if($location.path() === '/friends/'){
        $scope.getOwnFiendsList();
    }

    if($location.path() === '/settings/edit/details/'){
        $scope.getUserDetails();
    }
});