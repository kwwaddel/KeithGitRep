(function () {
    'use strict';

    angular.module('NewsApp').controller("BingController", BingController);

    function BingController($http) {
        $http({
            url: "/Bing/Get",
            method: "GET",
            data: {}
        }).success(function (data) {
            console.log("success");
            console.log(data);
        }).error(function (data) {
            
            console.log("failed get ");
        });
    }
})();