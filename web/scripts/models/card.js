function Card(carddata) {
    var self = this;

    Object.assign(self, carddata);

    if (self.points)
        self.dice = self.points.split("/").map(function(pointsString) { return new Die(self); });
    else
        self.dice = [];

    self.unrolledDice = self.dice;
    self.resolvedDice = [];

    //if (self.typecode === "character") {
    self.damage = 0;
    self.shields = 0;
    self.upgrades = [];
    //}

    self.canBeActivated = self.typecode === "character" || self.typecode === "support";
    self.isActivated = false;

    return self;
}