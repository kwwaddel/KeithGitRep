(function () {
    angular.module("HubApp", ["SignalR"]);//, "ngRoute"]).config(Config);

    //function Config($routeProvider, $locationProvider) {
    //    $routeProvider.when('/', {
    //        templateUrl: '/Views/App/loginView.html',
    //        controller: 'LoginViewController',
    //        controllerAs: 'vm'
    //    })
    //    .when('/loginView', {
    //        templateUrl: '/Views/App/loginView.html',
    //        controller: 'LoginViewController',
    //        controllerAs: 'vm'
    //    })
    //    .when('/viewB', {
    //        templateUrl: '/Views/App/viewB.html',
    //        controller: 'ViewBController',
    //        controllerAs: 'vm'
    //    })
    //    .otherwise({
    //        templateUrl: '/Views/App/notfound.html'
    //    });

    //    $locationProvider.html5Mode(true);
    //}
})();