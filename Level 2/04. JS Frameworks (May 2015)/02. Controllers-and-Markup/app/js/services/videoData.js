app.factory('videoServices', function($http, PARSE){
    var videoService = {};

    videoService.getAllVideos = function(success, error){
        $http.get(PARSE.BASE_URL + 'classes/Video', {headers: PARSE.HEADERS})
            .success(function (data) {
                success(data);
            }).error(error);
    };

    videoService.getVideoById = function(id, success, error){
        $http.get(PARSE.BASE_URL + 'classes/Video/' + id, {headers: PARSE.HEADERS})
            .success(function (data) {
                success(data);
            }).error(error);
    };

    videoService.addVideo = function(data, success, error){
        $http.post(PARSE.BASE_URL + 'classes/Video', JSON.stringify(data), {headers: PARSE.HEADERS})
            .success(function (data) {
                success(data);
            }).error(error);
    };

    return videoService;
});
