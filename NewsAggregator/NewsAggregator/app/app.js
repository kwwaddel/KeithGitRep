(function () {
    'use strict';

    angular.module('NewsApp', ["ngRoute"]).config(Config);

function Config($routeProvider, $httpProvider) {
    $routeProvider.when('/', {
        templateUrl: '/app/views/home.html',
        controller: 'BingController',
        controllerAs: 'vm'
    });

    //$httpProvider.interceptors.push('authService');
}
})();