angular.module("loginModule", ["ngRoute"]).config(function ($routeProvider) {
    $routeProvider
        .when("/",
            {
                controller: "loginController"
            });
});