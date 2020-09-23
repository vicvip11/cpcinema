angular.module("cpcModule").factory("cpcServices", ['$http', function ($http) {
    var self = this;

    self.getMovies = function (args) {
        return $http({
            methood: 'GET',
            params: args,
            url: 'api/cpc/getMovies'
        });
    }

    self.getShows = function (args) {
        return $http({
            methood: 'GET',
            params: args,
            url: 'api/cpc/getShows'
        });
    }

    return self;
}]);
