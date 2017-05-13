function Deck(characters, battlefield) {
    var self = this;

    self.cards = [];

    self.addCard = function(card) {
        self.cards.push(card);
        self.validate();
    }

    self.validate = function(a, b) {
        self.isFull = self.cards.length == 30;
        self.isValid = true;
        self.characterPoints = self.cards.map(function(c) {
            if (!c.points) return 0;

            var pointsValues = c.points.split("/");

            // Simplicity - assume elite for now if two die
            return parseInt(pointsValues[pointsValues.length - 1]);
        }).reduce(function(a,b) { return a + b; });

        var rules = [ function() { return self.characterPoints <= 30 } ];

        self.isValid = rules.every(function(r) { return r(); });
    };

    self.autofill = function (availableCards) {
        if (availableCards.filter(function(c) {
            return c.type_code === "character";
        }).length > 0)
            debugger;
        while (self.cards.length < 30) {
            var random = availableCards[Math.floor(Math.random() * availableCards.length)];
            self.addCard(random);
        }
    };

    var characters;
    self.getCharacters = function () {
        if (!characters)
            characters = self.cards.filter(function (c) { return c.typecode === "character"; });

        console.log("characters", characters);
        return characters;
    };

    characters.forEach(function (c) { self.addCard(c); });
    self.battlefield = battlefield;

    return self;
}