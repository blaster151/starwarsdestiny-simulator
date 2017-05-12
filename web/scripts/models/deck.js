function Deck() {
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

    return self;
}