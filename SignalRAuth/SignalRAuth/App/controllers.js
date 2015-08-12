(function () {
    angular.module("HubApp")
        .controller("HubController", HubController)
        .controller("LoginViewController", LoginViewController)
        .controller("ViewBController", ViewBController);

    function HubController($http, Hub, $location, $q) {
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

                $location.path("/viewB");
                var name;
                //start hub connection
                var hub = $.hubConnection();
                //var hub2 = $.connection.hubConn;
                //hub2.server.addUser();
                var proxy = hub.createHubProxy('HubConn');
                
                //set callback on proxy-->
                //function invoked when server calls the client-->
                //proxy.on('connect', function () {
                //    vm.loginMessage = "connected";
                //});

                proxy.on('startGame', function () {
                    console.log("NAME: " + name);
                    var gHub = $.hubConnection();
                    var gProxy = gHub.createHubProxy("GameHub");

                    gProxy.on("showPlayer", function (player) {
                        $("#test").append("<li>" + player.Name + "</li>");
                    });

                    gProxy.on("showGame", function () {
                        $("#test").append("<li>Show Game</li>");
                        console.log("showGame");
                        gProxy.invoke("getPlayerData");
                    });
                    
                    hub.stop();
                    
                    gHub.start().done(function () {
                        console.log("in new hub");
                        gProxy.invoke("makeGame");
                    });
                });
                
                hub.start().done(function () {
                    //var id = hub.id;
                    
                    proxy.invoke('addUser');
                    proxy.invoke("test").done(function (val) {
                        //$("#test").append("<li>" + val + "</li>");
                        console.log(val + " HERERER");
                        name = val;
                    });
                    //proxy.invoke("findGame", hub.id);
                    
                });

                //proxy.server.addUser();
                //console.log("id: " + id);
                
                var deferred = $q.defer();
                $http({
                    url: "/api/Hub/GetPlayers",
                    method: "GET",
                    data: {}
                }).success(function (data) {
                    deferred.resolve(data);
                    console.log("success get players" + data);
                }).error(function (data) {
                    deferred.reject();
                    console.log("failed get players");
                });
                console.log(hub);
                console.log(proxy);
                $http({
                    url: "/api/Game/AddPlayer",
                    method: "POST",
                    data: {}
                }).success(function (data) {
                    deferred.resolve(data);
                    console.log("success " + data);
                }).error(function (data) {
                    deferred.reject();
                    console.log("failed");
                });
                //$location.path("/viewB"); works
                
            }).error(function () {
                vm.loginMessage = 'Invalid user name/password';
            });
        }
    }

    function LoginViewController($location) {
        var vm = this;

        vm.move = move;

        function move() {
            $location.path('/viewB/');
        }
    }

    function ViewBController($location) {
        var vm = this;

        vm.move = move;

        function move() {
            $location.path('/viewB/');
        }
    }
})();