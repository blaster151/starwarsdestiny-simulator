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

    $scope.$watch("cards", function(newVal) {
        if (!newVal) return;
        if (newVal.length === 0) return;

        var result = newVal[1];
        result.isSelectableTarget = true;

        console.log("result", result);
        $scope.selectableCard = result;

        var selectableDie = newVal[2].dice[0];
        selectableDie.isSelectableTarget = true;
            
        $scope.selectableDie = selectableDie;

        $scope.rolledDice = [
            new Die(newVal[3]),
            new Die(newVal[3]),
            new Die(newVal[3]),
            new Die(newVal[3]),
            new Die(newVal[3]),
            new Die(newVal[3])
        ];
        $scope.rolledDice[0].rolledPointValue = 1;
        $scope.rolledDice[0].rolledValueType = "MD";
        $scope.rolledDice[0].rolledValue = "1MD";

        $scope.rolledDice[1].rolledPointValue = 1;
        $scope.rolledDice[1].rolledValueType = "RD";
        $scope.rolledDice[1].rolledValue = "1RD";

        $scope.rolledDice[2].rolledPointValue = 1;
        $scope.rolledDice[2].rolledValueType = "S";
        $scope.rolledDice[2].rolledValue = "1S";

        $scope.rolledDice[2].rolledPointValue = 1;
        $scope.rolledDice[2].rolledValueType = "Dr";
        $scope.rolledDice[2].rolledValue = "1Dr";

        $scope.rolledDice[3].rolledPointValue = 1;
        $scope.rolledDice[3].rolledValueType = "Dc";
        $scope.rolledDice[3].rolledValue = "1Dc";

        $scope.rolledDice[4].rolledPointValue = 1;
        $scope.rolledDice[4].rolledValueType = "F";
        $scope.rolledDice[4].rolledValue = "1F";

        $scope.rolledDice[5].rolledPointValue = 1;
        $scope.rolledDice[5].rolledValueType = "MD";
        $scope.rolledDice[5].rolledValue = "+1MD";

        //$scope.rolledDice[5].rolledPointValue = 1;
        //$scope.rolledDice[5].rolledValueType = "RD";
        //$scope.rolledDice[5].rolledValue = "3MD1";
    });
}]);