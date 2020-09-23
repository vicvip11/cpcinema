angular.module("cpcStaffModule").factory("cpcStaffServices", ['$http', function ($http) {
    var self = this;

    self.addMovie = function (args) {
        return $http({
            methood: 'POST',
            params: args,
            url: 'staff/addMovie'
        });
    }

    self.getMovies = function () {
        return $http({
            methood: 'GET',
            url: 'staff/getMovies'
        });
    }

    self.getHalls = function () {
        return $http({
            methood: 'GET',
            url: 'staff/getHalls'
        });
    }

    self.getShowsForHall = function (args) {
        return $http({
            methood: 'GET',
            params: args,
            url: 'staff/getShowsFH'
        });
    }

    self.addShow = function (args) {
        return $http({
            methood: 'GET',
            params: args,
            url: 'staff/addShow'
        });
    }

    return self;
}]);
