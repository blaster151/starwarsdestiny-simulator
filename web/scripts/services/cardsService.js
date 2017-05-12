angular.module('swd').service('cardsService', ['$http', '$q', function($http, $q) {
    var self = this;

    self.getCards = function() {
        var deferred = $q.defer();

        return $http.get("/data/cards.json");
    };

    return self;
}]);