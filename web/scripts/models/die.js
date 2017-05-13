function Die(card) {
    var self = this;

    self.card = card;
    self.sides = card.sides;
    self.rolledValue = null;
    self.rolledValueType = null;
    self.isRolledPlus = false;
    self.resolve = function() {
        self.isResolved = false;
        self.card.resolvedDice.push(self);
    };

    self.roll = function () {
        var rand = self.sides[Math.floor(Math.random() * self.sides.length)];
        self.rolledValue = rand;
        self.rolledValueType = getType(self.rolledValue);
        self.rolledPointValue = getValue(self.rolledValue);

        return rand;
    };

    function getType(rolledValue) {
        if (rolledValue.indexOf("Sh") >= 0)
            return "Shield";
        if (rolledValue.indexOf("MD") >= 0)
            return "Melee";
        if (rolledValue.indexOf("RD") >= 0)
            return "Ranged";
        if (rolledValue.indexOf("F") >= 0)
            return "Focus";
        if (rolledValue.indexOf("R") >= 0)
            return "Resource";
        if (rolledValue.indexOf("D") >= 0)
            return "Disrupt";
        if (rolledValue.indexOf("-") >= 0)
            return "Blank";
        if (rolledValue.indexOf("Sp") >= 0)
            return "Special";
        else
            debugger;
    }

    function getValue(rolledValue) {
        if (rolledValue === "-")
            return 0;
        if (rolledValue.indexOf("Sp") >= 0)
            return 0;
        else
            if (rolledValue.indexOf("+") === 0) {
                self.isRolledPlus = true;
                return parseInt(rolledValue.substr(1, 1));
            } else {
                return parseInt(rolledValue.substr(0, 1));
            }
    }

    return self;
}