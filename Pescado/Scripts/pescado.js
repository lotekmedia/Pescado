(function () {

    var app = angular.module('pescadoApp', []);

    var MainCtrl = function ($scope,$http) {

        $scope.message = 'hello angular';

        var onRestaurantComplete = function (response) {
            $scope.restaurants = response.data;
        }

        var onError = function (reason) {
            $scope.error = "Could not fetch data";
        }

        $http.get("http://localhost/api/restaurant")
              .then(onRestaurantComplete, onError);
    }

    app.controller("MainCtrl", ["$scope", "$http",MainCtrl]);
} ());