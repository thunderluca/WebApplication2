var homeController = function($scope, $http, blogService) {

    blogService.latest(function(articles) {
        $scope.blogs = articles;
    });
};