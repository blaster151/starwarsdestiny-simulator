angular.module('swd').controller('deckBuilderController', ['$scope', '$timeout', function($scope, $timeout) {
    $scope.onCardSelected = function(val) {
        $scope.deck.addCard(val.card);
    };
}]);