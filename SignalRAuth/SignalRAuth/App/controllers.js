(function () {
    angular.module("HubApp")
        .controller("HubController", HubController);
        //.controller("LoginViewController", LoginViewController);

    function HubController($http, Hub) {
        var vm = this;
        vm.accessToken = null;

        vm.login = login;

        function login() {

            var data = "grant_type=password&username=" + vm.username + "&password=" + vm.password;

            $http.post('/Token', data,
            {
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            }).success(function (result) {
                vm.username = "";
                vm.password = "";
                vm.accessToken = result.access_token;
                vm.loginMessage = "login was successful";

                //start hub connection
                var hub = $.hubConnection();

                var proxy = hub.createHubProxy('HubConn');
                
                //set callback on proxy-->
                //function invoked when server calls the client-->
                //proxy.on('connect', function () {
                //    vm.loginMessage = "connected";
                //});
                proxy.on('connected', function () {
                });

                hub.start();
                //window.location.assign("viewB");// = "viewB";
                
            }).error(function () {
                vm.loginMessage = 'Invalid user name/password';
            });
        }
    }
    //function LoginViewController($location) {
    //    var vm = this;

    //    vm.move = move;

    //    function move() {
    //        $location.path('viewB/');
    //    }
    //}
})();