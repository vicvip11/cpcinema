angular.module("cpcModule").controller("ssController", ['cpcServices', '$scope', '$routeParams', function (cpcServices, $scope, $routeParams)
{
    var movieId = $routeParams.idMovie;
    $scope.ssInit = function ()
    {
        cpcServices.getMovies({ movieId: movieId, userId: 0}).then(function (response) {
            var data = response.data;
            $scope.movie = data[0];
        });

        cpcServices.getShows({ movieId: movieId }).then(function (response) {
            var data = response.data;
            console.log(data);
        });
    }
}]);