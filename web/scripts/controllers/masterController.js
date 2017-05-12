angular.module('swd').controller('masterController', ['$scope', '$timeout', 'cardsService', function($scope, $timeout, cardsService) {
    $scope.cards = [];
    $scope.deck = new Deck();

    cardsService.getCards().then(function(cards) {
        $scope.cards = cards.data;
    });
}]);