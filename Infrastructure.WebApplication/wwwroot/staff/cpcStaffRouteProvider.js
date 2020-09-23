angular.module("cpcStaffModule", ["ngRoute"]).config(function ($routeProvider)
{
    $routeProvider
        .when("/",
            {
                templateUrl: "/staff/templates/cpcStaffLayout.html",
                controller: "cpcStaffController"
            })
        .when("/addMovie",
            {
                templateUrl: "/staff/templates/addMovie.html"
            })
        .when("/addShow",
            {
                templateUrl: "/staff/templates/addShow.html"
            });
});