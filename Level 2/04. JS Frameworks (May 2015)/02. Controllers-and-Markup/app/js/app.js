var app = angular.module('VideoSystemApp', ['ngRoute', 'angular.filter']);

app.constant('PARSE', {
    "BASE_URL": 'https://api.parse.com/1/',
    "HEADERS": {
        'X-Parse-Application-Id': 'mQnsaifCLvttSd8aMjKtQDm5Dl6ee8l8I5bjYdpf',
        'X-Parse-REST-API-Key': 'IDpEIDhljrNinGt70K0Pw87eqE3H7txP0cVjfpU3',
        'Content-Type': 'application/json'
    }
});

app.config(function ($routeProvider) {
    $routeProvider
        .when('/', {
            templateUrl:'templates/all-videos.html',
            controller:'VideoController'
        })
        .when('/add/video/', {
            templateUrl:'templates/add-video.html',
            controller:'VideoController'
        })
        .when('/video/:videoId/', {
            templateUrl:'templates/video.html',
            controller:'VideoController'
        })
        .otherwise({redirectTo: '/'})

});

app.directive('customOnChange', function() {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            var onChangeFunc = scope.$eval(attrs.customOnChange);
            element.bind('change', onChangeFunc);
        }
    };
});