(function () {
    angular.module("HubApp", ["ngRoute", "SignalR"]).config(Config);

    function Config($routeProvider, $httpProvider) {
        $routeProvider.when('/', {
            templateUrl: '/App/Views/loginView.html',
            controller: 'LoginViewController',
            controllerAs: 'vm'
        })
        .when('/loginView', {
            templateUrl: '/App/Views/loginView.html',
            controller: 'LoginViewController',
            controllerAs: 'vm'
        })
        .when('/viewB', {
            templateUrl: '/App/Views/viewB.html',
            controller: 'ViewBController',
            controllerAs: 'vm'
        })
        .otherwise({
            templateUrl: '/App/Views/notfound.html'
        });

        //$httpProvider.interceptors.push('authService');
    }
})();