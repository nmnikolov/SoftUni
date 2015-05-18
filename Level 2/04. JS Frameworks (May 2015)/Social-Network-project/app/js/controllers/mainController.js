app.controller('mainController', function ($scope, $location, $resource, $log, $routeParams, userService, authentication, DEFAULT_PROFILE_IMAGE, Offset, notifyService) {
    $scope.isLogged = function(){
        return authentication.isLogged();
    };

    $scope.username = authentication.getUsername();
    $scope.defaultImage = DEFAULT_PROFILE_IMAGE;

    $scope.showUserPreview = function(username, event, type){
        if (authentication.isLogged()){
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
                },
                function(error){
                    notifyService.showError("Unsuccessful register!", error);
                }
            );

            var offset = Offset.getOffset(event.target);

            angular.element('#user-preview-box').show();
            angular.element('#user-preview-box').css({
                left: offset.left,
                top: offset.top
            });
        }
    };

    $scope.hideUserPreview = function(){
        $scope.previewData = undefined;
        angular.element('#user-preview-box').hide();
    };
});