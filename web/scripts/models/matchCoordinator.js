function MatchCoordinator(match) {
    var self = this;

    self.match = match;

    self.begin = function () {
        self.match.player1.resources = 2;
        self.match.player2.resources = 2;

        var player1Roll = 0;
        var player2Roll = 0;

        do {
            player1Roll = self.match.player1.rollCharacterDie().totalPointValue;
            player2Roll = self.match.player2.rollCharacterDie().totalPointValue;
        } while (player1Roll === player2Roll);

        if (player1Roll > player2Roll) {
            self.match.setTurn(self.match.player1);
            self.match.battlefield = self.match.player1.deck.battlefield;
        }
        else if (player1Roll < player2Roll) {
            self.match.setTurn(self.match.player2);
            self.match.battlefield = self.match.player2.deck.battlefield;
        }

        resetActivatedCards();

        self.match.player1.field = self.match.player1.deck.getCharacters();
        self.match.player2.field = self.match.player2.deck.getCharacters();

        self.match.player1.drawHand();
        self.match.player2.drawHand();
    }

    function resetActivatedCards() {
        
    }

    return self;
}