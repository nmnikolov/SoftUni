var app = angular.module('SocialNetworkApp', ['ngRoute', 'ngResource']);

app.constant('BASE_URL','http://softuni-social-network.azurewebsites.net/api/');

app.config(function ($routeProvider) {
    $routeProvider
        .when('/login/', {
            templateUrl:'templates/login.html',
            controller:'userController',
            resolve:{
                isLogged: function($location){
                    if(localStorage.getItem('accessToken')){
                        $location.path('/');
                    }
                }
            }
        })
        .when('/register/', {
            templateUrl: 'templates/register.html',
            controller:'userController',
            resolve:{
                isLogged: function($location){
                    if(localStorage.getItem('accessToken')){
                        $location.path('/');
                    }
                }
            }
        })
        .when('/profile/edit/details/', {
            templateUrl: 'templates/profile-details.html',
            controller:'profileController',
            resolve:{
                isLogged: function($location){
                    if(!localStorage.getItem('accessToken')){
                        $location.path('/');
                    }
                }
            }
        })
        .when('/profile/edit/password/', {
            templateUrl: 'templates/profile-password.html',
            controller:'profileController',
            resolve:{
                isLogged: function($location){
                    if(!localStorage.getItem('accessToken')){
                        $location.path('/');
                    }
                }
            }
        })
        .when('/', {
            templateUrl: 'templates/home.html',
            controller:'userController'
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