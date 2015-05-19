app.controller('profileController', function ($scope, $location, $resource, $log, $routeParams, profileService, authentication, notifyService, PAGE_SIZE, usSpinnerService) {
    var feedStartPostId;
    $scope.posts = [];
    $scope.busy = false;

    $scope.getUserDetails = function(){
        if(authentication.isLogged()) {
            usSpinnerService.spin('spinner-1');
            profileService(authentication.getAccessToken()).me().$promise.then(
                function (data) {
                    $scope.me = data;
                    usSpinnerService.stop('spinner-1');
                },
                function (error) {
                    usSpinnerService.stop('spinner-1');
                    notifyService.showError("Unsuccessful Connection to Database!", error)
                }
            );
        }
    };

    $scope.editDetails = function(){
        usSpinnerService.spin('spinner-1');
        if(authentication.isLogged()) {
            profileService(authentication.getAccessToken()).update($scope.me).$promise.then(
                function () {
                    usSpinnerService.stop('spinner-1');
                    notifyService.showInfo('Profile successfully edited.');
                },
                function (error) {
                    $log.warn(error);
                    usSpinnerService.stop('spinner-1');
                    notifyService.showError('Unsuccessful update!', error);
                }
            );
        }
    };

    $scope.editPassword = function(){
        if(authentication.isLogged()) {
            usSpinnerService.spin('spinner-1');
            profileService(authentication.getAccessToken()).update($scope.passwordUpdate, 'changepassword').$promise.then(
                function () {
                    usSpinnerService.stop('spinner-1');
                    notifyService.showInfo('Password successfully changed.');
                    $location.path('/');
                },
                function (error) {
                    usSpinnerService.stop('spinner-1');
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

            usSpinnerService.spin('spinner-1');

            profileService(authentication.getAccessToken()).getNewsFeed(PAGE_SIZE, feedStartPostId).$promise.then(
                function (data) {
                    $scope.posts = $scope.posts.concat(data);
                    if($scope.posts.length > 0){
                        feedStartPostId = $scope.posts[$scope.posts.length - 1].id;
                    }
                    $scope.busy = false;
                    usSpinnerService.stop('spinner-1');
                },
                function (error, status) {
                    $log.warn(status, error);
                    usSpinnerService.stop('spinner-1');
                }
            );
        }
    };

    $scope.getOwnFiendsList = function(){
        if(authentication.isLogged()) {
            usSpinnerService.spin('spinner-1');
            profileService(authentication.getAccessToken()).getFriendsList().$promise.then(
                function (data) {
                    $scope.friendsList = data;
                    usSpinnerService.stop('spinner-1');
                },
                function (error, status) {
                    $log.warn(status, error);
                    usSpinnerService.stop('spinner-1');
                }
            );
        }
    };

    $scope.getOwnFriendsListPreview = function(){
        if(authentication.isLogged()) {
            usSpinnerService.spin('spinner-1');
            profileService(authentication.getAccessToken()).getFriendsListPreview().$promise.then(
                function (data) {
                    data.userFriendsUrl = '#/friends/';
                    $scope.friendsListPreview = data;
                    usSpinnerService.stop('spinner-1');
                },
                function (error, status) {
                    usSpinnerService.stop('spinner-1');
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

    $('#sidebar').affix({
        offset: {
            top: $('header').height()
        }
    });

});