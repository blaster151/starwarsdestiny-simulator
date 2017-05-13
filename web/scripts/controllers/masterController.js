angular.module('swd').controller('masterController', ['$scope', '$timeout', 'cardsService', 'selectorService', function ($scope, $timeout, cardsService, selectorService) {
    // All available cards
    $scope.cards = [];

    cardsService.getCards().then(function(cards) {
        $scope.cards = cards.data.map(function(carddata) { return new Card(carddata); });

        createSampleMatch();
    });

    function createSampleMatch() {
        var quiGon = $scope.cards.find(function (c) { return c.code === "01037"; });
        var rey = $scope.cards.find(function (c) { return c.code === "01038"; });
        var kylo = $scope.cards.find(function (c) { return c.code === "01011"; });
        var stormtrooper = $scope.cards.find(function (c) { return c.code === "01002"; });

        var echoBase = $scope.cards.find(function (c) { return c.code === "01166"; });
        var starkillerBase = $scope.cards.find(function (c) { return c.code === "01168"; });;

        var heroDeck = new Deck([quiGon, rey], echoBase);
        var villainDeck = new Deck([kylo, stormtrooper], starkillerBase);

        heroDeck.autofill($scope.cards.filter(function (c) { return c.affiliation_code !== "villain" && c.type_code !== 'character' && c.type_code !== 'battlefield'; }));
        villainDeck.autofill($scope.cards.filter(function (c) { return c.affiliation_code !== "hero" && c.type_code !== 'character' && c.type_code !== 'battlefield'; }));

        $scope.match = new Match(new Player("Jeff", heroDeck), new Player("Koz", villainDeck));
        $scope.match.selectorService = selectorService; // Hack

        new MatchCoordinator($scope.match).begin();
    }
}]);