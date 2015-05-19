app.controller('mainController', function ($scope, $log, $interval, userService, profileService, authentication, DEFAULT_PROFILE_IMAGE, notifyService, usSpinnerService) {
    $scope.isLogged = function(){
        return authentication.isLogged();
    };

    $scope.username = authentication.getUsername();
    $scope.defaultImage = DEFAULT_PROFILE_IMAGE;
    $scope.showPendingRequest = false;

    $scope.showUserPreview = function(username){
        $scope.previewData = {};
        if (authentication.isLogged()){
            usSpinnerService.spin('spinner-1');
            userService(authentication.getAccessToken()).getUserFullData(username).$promise.then(
                function(data){
                    $scope.previewData = {
                        image: data.profileImageData ? data.profileImageData : DEFAULT_PROFILE_IMAGE,
                        name: data.name,
                        username: data.username,
                        status: false
                    };

                    if(authentication.getUsername() !== data.username){
                        if(data.isFriend){
                            $scope.previewData.status = 'friend';
                        } else if(data.hasPendingRequest){
                            $scope.previewData.status = 'pending';
                        } else {
                            $scope.previewData.status = 'invite';
                        }
                    }
                    usSpinnerService.stop('spinner-1');
                },
                function(error){
                    usSpinnerService.stop('spinner-1');
                    notifyService.showError("Unsuccessful register!", error);
                }
            );
        }
    };

    $scope.hideUserPreview = function(){
        $scope.previewData = undefined;
        angular.element('#user-preview-box').hide();
    };

    function getFriendRequests(){
        if (authentication.isLogged()){
            profileService(authentication.getAccessToken()).getPendingRequests().$promise.then(
                function(data){
                    $scope.pendingRequests = data;
                }
            );
        }
    }

    $scope.acceptFriendRequest = function(request){
        if (authentication.isLogged()){
            usSpinnerService.spin('spinner-1');
            profileService(authentication.getAccessToken()).acceptRequest(request.id).$promise.then(
                function(){
                    usSpinnerService.stop('spinner-1');
                    notifyService.showInfo("Friend request successfully accepted.");
                }, function(error){
                    $log.warn(error);
                    usSpinnerService.stop('spinner-1');
                    notifyService.showError("Unsuccessful request accept!", error);
                }
            );
        }
    };

    $scope.rejectFriendRequest = function(request){
        if (authentication.isLogged()){
            usSpinnerService.spin('spinner-1');
            profileService(authentication.getAccessToken()).rejectRequest(request.id).$promise.then(
                function(){
                    usSpinnerService.stop('spinner-1');
                    notifyService.showInfo("Friend request successfully rejected.");
                }, function(error){
                    $log.warn(error);
                    usSpinnerService.stop('spinner-1');
                    notifyService.showError("Unsuccessful request reject!", error);
                }
            );
        }
    };

    getFriendRequests();
    var interval = $interval(getFriendRequests, 60000);

    $scope.$on('$destroy', function () { $interval.cancel(interval); });
});