function Player(name, deck) {
    var self = this;

    self.name = name;
    self.deck = deck;

    self.hand = [];
    self.drawPile = [];
    self.discardPile = [];
    self.dicePool = [];

    self.rollCharacterDie = function() {
        var pointValue = self.deck.getCharacters().map(function(c) { return Math.random(); }).reduce(function(a, b) { return a + b; });
        return { totalPointValue: pointValue };
    };

    self.drawHand = function () {
        for (var i = 0; i < 5; i++) {
            drawCard();
        }
    };

    function drawCard() {
        var eligibleCards = self.deck.cards.filter(function(c) { return c.type_code !== "character" && c.type_code !== "battlefield" });

        var rndIndex = Math.floor(Math.random() * eligibleCards.length);
        var random = eligibleCards[rndIndex];

        console.log("hand", random.name);
        self.hand.push(random);
        self.deck.cards.splice(rndIndex, 1);
    }

    return self;
}