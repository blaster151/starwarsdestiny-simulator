angular.module('swd').service('selectorService', ['$http', '$q', function($http, $q) {
    var self = this;
    var deferred;

    self.items = [];
    self.selectFrom = function (items) {
        deferred = $q.defer();

        self.items = items;
        items.forEach(function(item) {
            item.isSelectableTarget = true;
        });

        return deferred.promise;
    };

    self.multiSelect = function (items) {
        // TODO
        return self.selectFrom(items).then(function(result) { return [result]; });
    };

    self.notifySelected = function (item) {
        console.log("in notifyselected");
        deferred.resolve(item);
        deferred = null;

        self.items.forEach(function (item) {
            item.isSelectableTarget = false;
        });
    };

    return self;
}]);