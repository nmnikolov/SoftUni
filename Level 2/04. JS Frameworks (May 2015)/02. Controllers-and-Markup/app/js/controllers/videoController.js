app.controller('VideoController', function AdsController($scope, $location, $routeParams, videoServices) {
    var getAllVideos = function(){
        videoServices.getAllVideos(
            function (data, status, headers, config) {
                $scope.videoData = data['results'];
            },
            function (error, status, headers, config) {
                console.log(status, error);
            });
    };

    var getVideoById = function(id){
        if(id !== undefined){
            videoServices.getVideoById(id,
            function(data, status, headers, config){
                $scope.video = data;
            }, function(error, status, headers, config){
                console.log(status, error);
            })
        }
    };

    var addVideo = function(){
        videoServices.addVideo($scope.newVideo,
            function(){
                $location.path('/');
            }, function(error){
                console.log(error);
            });
    };

    $scope.addVideo = function(){
        var picture = angular.element('.picture-preview').attr('src');
        $scope.newVideo.picture = picture ? picture : "";
        $scope.newVideo.haveSubtitles = $scope.newVideo.haveSubtitles === true ? $scope.newVideo.haveSubtitles : false;
        if($scope.newVideo.date.iso){
            var d = new Date($scope.newVideo.date.iso);
            $scope.newVideo.date['__type'] = "Date";
            $scope.newVideo.date.iso = new Date(Date.UTC(d.getFullYear(), d.getMonth(), d.getDate()));
        } else {
            delete $scope.newVideo.date;
        }

        addVideo($scope.newVideo);
    };

    $scope.uploadMoviePicture = function uploadMoviePicture($scope){
        var file = this.files[0],
            reader;

        if(!file.type.match(/image\/.*/)){
            console.error("Invalid file format.");
        } else if(file.size > 512000) {
            console.error("File size limit exceeded.");
        } else {
            reader = new FileReader();
            reader.onload = function() {
                angular.element('.picture-preview').attr('src', reader.result);
            };
            reader.readAsDataURL(file);
        }
    };

    $scope.clearFilter = function(){
        delete $scope.filter;
        delete $scope.filterBy;
    };

    $scope.clearFilterBy = function(){
        delete $scope.filterBy;
    };

    $scope.getDate = function(){
        var d = $("#inputDate").datepicker( "getDate");
        $scope.filterBy = {date: {}};
        $scope.filterBy.date.iso = new Date(Date.UTC(d.getFullYear(), d.getMonth(), d.getDate())).toISOString();
    };

    getVideoById($routeParams['videoId']);
    getAllVideos();

    $( "#inputDate" ).datepicker({
        dateFormat: "dd MM yy",
        changeMonth: true,
        changeYear: true,
        showAnim: "fade",
        yearRange: "c-150:c+5"
    });


    //$("#inputDate").kendoDatePicker({
    //    format: "dd MMMM yyyy"
    //});
});