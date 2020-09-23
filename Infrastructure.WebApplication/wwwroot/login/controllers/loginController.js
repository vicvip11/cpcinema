var App = angular.module('loginModule', []);

App.service('postService', ['$http', function ($http) {
    this.post = function (data) {
        var fd = new FormData();
        for (var key in data)
            fd.append(key, data[key]);
        $http.post("Authentication", fd);
    }
}]);

App.controller('loginController', ['postService', '$scope', function (multipartForm, $scope) {

    $scope.loginClick = function ()
    {
        var user = {};
        user.bu = btoa(toByteArray($scope.username));
        user.bp = btoa(toByteArray($scope.password));
        postService.post(user);
    }; 

    function toByteArray(str) {
        var utf8 = [];
        for (var i = 0; i < str.length; i++) {
            var charcode = str.charCodeAt(i);
            if (charcode < 0x80) {
                utf8.push(charcode)
            }
            else if (charcode < 0x800) {
                utf8.push(0xc0 | (charcode >> 6), 0x80 | (charcode & 0x3f));
            }
            else if (charcode < 0xd800 || charcode >= 0xe000) {
                utf8.push(0xe0 | (charcode >> 12), 0x80 | ((charcode >> 6) & 0x3f), 0x80 | (charcode & 0x3f));
            }
        }
        return utf8;
    }
}]);