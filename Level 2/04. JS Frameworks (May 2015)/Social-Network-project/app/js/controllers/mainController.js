app.controller('mainController', function ($scope, $location, $resource, $log, $routeParams, userService, authentication, DEFAULT_PROFILE_IMAGE, Offset) {
    $scope.isLogged = function(){
        return authentication.isLogged();
    };

    $scope.username = authentication.getUsername();
    $scope.defaultImage = DEFAULT_PROFILE_IMAGE;

    $scope.showUserPreview = function(data, event, type){
        if(type === 'post'){
            $scope.previewData = {
                image: data.profileImageData ? data.profileImageData : DEFAULT_PROFILE_IMAGE,
                username: data.name
            };
        } else {
            $scope.previewData = {
                image: data.authorProfileImage ? data.profileImageData : DEFAULT_PROFILE_IMAGE,
                username: data.authorUsername
            };
        }

        var offset = Offset.getOffset(event.target);

        angular.element('#user-preview-box').show();
        angular.element('#user-preview-box').css({
            left: offset.left,
            top: offset.top
        });
    };

    $scope.hideUserPreview = function(){
        $scope.previewData = undefined;
        angular.element('#user-preview-box').hide();
    };


});