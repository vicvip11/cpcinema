angular.module("cpcModule", ["ngRoute"]).config(function ($routeProvider)
{
    $routeProvider
        .when("/",
            {
                templateUrl: "/app/templates/cpcHomeLayout.html",
                controller: "cpcController"
            })
        .when("/showShows/:idMovie",
            {
                templateUrl: "/app/templates/ssLaout.html",
                controller: "ssController"
            });
});