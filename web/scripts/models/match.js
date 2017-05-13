function Match(player1, player2) {
    var self = this;

    var isFunction = function(thing) {
        return typeof thing === "Function";
    };

    var isObject = function (thing) {
        return (typeof thing === "object") && (thing !== null);
    };

    var optimizeCb = function(func, context, argCount) {
        if (context === void 0) return func;
        switch (argCount == null ? 3 : argCount) {
        case 1: return function(value) {
            return func.call(context, value);
        };
        case 2: return function(value, other) {
            return func.call(context, value, other);
        };
        case 3: return function(value, index, collection) {
            return func.call(context, value, index, collection);
        };
        case 4: return function(accumulator, value, index, collection) {
            return func.call(context, accumulator, value, index, collection);
        };
        }
        return function() {
            return func.apply(context, arguments);
        };
    };

    var property = function (key) {
        return function (obj) {
            return obj == null ? void 0 : obj[key];
        };
    };

    var cb = function (value, context, argCount) {
        if (value == null) return _.identity;
        if (isFunction(value)) return optimizeCb(value, context, argCount);
        if (isObject(value)) return _.matcher(value);
        return property(value);
    };
    var iteratee = function (value, context) {
        return cb(value, context, Infinity);
    };

    var each = function (obj, iteratee, context) {
        iteratee = optimizeCb(iteratee, context);
        var i, length;
        if (isArrayLike(obj)) {
            for (i = 0, length = obj.length; i < length; i++) {
                iteratee(obj[i], i, obj);
            }
        } else {
            var keys = _.keys(obj);
            for (i = 0, length = keys.length; i < length; i++) {
                iteratee(obj[keys[i]], keys[i], obj);
            }
        }
        return obj;
    };

    var MAX_ARRAY_INDEX = Math.pow(2, 53) - 1;
    var getLength = property('length');
    var isArrayLike = function (collection) {
        var length = getLength(collection);
        return typeof length == 'number' && length >= 0 && length <= MAX_ARRAY_INDEX;
    };

    var group = function (behavior) {
        return function (obj, iteratee, context) {
            var result = {};
            iteratee = cb(iteratee, context);
            each(obj, function (value, index) {
                var key = iteratee(value, index, obj);
                behavior(result, value, key);
            });
            return result;
        };
    };

    var has = function (obj, key) {
        return obj != null && hasOwnProperty.call(obj, key);
    };

    var groupBy = group(function (result, value, key) {
        if (has(result, key)) result[key].push(value); else result[key] = [value];
    });


    self.player1 = player1;
    self.player2 = player2;
    self.turns = [];


    function determineAvailableActions(player) {
        self.availableActions = [
            { description: "Claim the Battlefield", action: function () { console.log("Claiming battlefield"); self.endTurn(); player.hasClaimed = true; } },
            { description: "Pass", action: function () { self.endTurn(); } }
        ];

        if (player.dicePool.length > 0 && player.hand.length > 0) {
            self.availableActions.push({
                description: "Discard to Reroll",
                action: function () {
                    self.selectorService.selectFrom(player.hand).then(function (cardToDiscard) {
                        console.log("Discarding ", cardToDiscard.name);

                        var index = player.hand.indexOf(cardToDiscard);
                        if (index > -1) {
                            player.hand.splice(index, 1);
                        }

                        self.selectorService.multiSelect(player.dicePool).then(function (dieToReroll) {
                            console.log("After multiselection");
                            console.log(dieToReroll);

                            dieToReroll.forEach(function (die) {
                                die.roll();
                            });
                        });
                    });

                    self.endTurn();
                }
            });
        }

        console.log("chars length", player.deck.getCharacters().length);
        player.deck.getCharacters().forEach(function (character) {
            console.log(" die", character.dice.length);

            if (character.dice.length > 0 && !character.isActivated)
                self.availableActions.push(
                    {
                        description: "Roll out " + character.name,
                        action: function() {
                            console.log("Rolling out " + character.name);
                            character.dice.forEach(function(die) {
                                die.roll();
                                player.dicePool.push(die);
                            });
                            character.unrolledDice = [];
                            character.isActivated = true;
                            self.endTurn();
                        }
                    }
                );
        });

        var diceGroupings = groupBy(player.dicePool, "rolledValueType");
        Object.keys(diceGroupings).forEach(function (key) {
            console.log("dice group", key);
            console.log(diceGroupings[key]);

            if (key !== "Blank")
                self.availableActions.push({
                    description: "Resolve die " + key + " (" + diceGroupings[key].length + " die) (" + diceGroupings[key].map(function(d) { return d.rolledPointValue; }).reduce(function(a,b) { return a+b; }) + " points)",
                    action: function() {
                        console.log("Resolving die ", key);

                        diceGroupings[key].forEach(function (die) {
                            console.log("  in loop");
                            var index = player.dicePool.indexOf(die);
                            if (index > -1) {
                                console.log("removing from dice pool");
                                player.dicePool.splice(index, 1);
                            }

                            if (key === "Resource")
                                player.resources += die.rolledPointValue;
                            if (key === "Shield")
                                self.selectorService.selectFrom(player.deck.getCharacters())
                                    .then(function (friendlyCharacter) {
                                        console.log("attacking ");
                                        console.log(friendlyCharacter);

                                        diceGroupings[key].forEach(function (die) {
                                            friendlyCharacter.shields += die.rolledPointValue;
                                        });
                                    });
                            if (key === "Disrupt") {
                                var otherPlayer;
                                if (self.player1 === player)
                                    otherPlayer = self.player2;
                                else if (self.player2 === player)
                                    otherPlayer = self.player1;

                                diceGroupings[key].forEach(function(die) {
                                    otherPlayer.resources -= die.rolledPointValue;
                                });
                            }
                            if (key === "Melee" || key === "Ranged") {
                                var otherPlayer;
                                if (self.player1 === player)
                                    otherPlayer = self.player2;
                                else if (self.player2 === player)
                                    otherPlayer = self.player1;

                                self.selectorService.selectFrom(otherPlayer.deck.getCharacters())
                                    .then(function(opponentCharacter) {
                                        console.log("attacking ");
                                        console.log(opponentCharacter);

                                        diceGroupings[key].forEach(function (die) {
                                            opponentCharacter.damage += die.rolledPointValue;
                                        });
                                    });
                            }

                            die.resolve();
                        });

                        self.endTurn();
                    }
                });
        });

        player.hand.forEach(function (card) {
            if (card.cost <= player.resources) {
                self.availableActions.push({ description: "Play card " + card.type_code + " - " + card.name, action: function() {
                    console.log("Playing card");
                    player.resources -= card.cost;

                    if (card.type_code === "event")
                        player.discardPile.push(card);

                    if (card.type_code === "upgrade") {
                        self.selectorService.selectFrom(player.deck.getCharacters())
                            .then(function (character) {
                                console.log("Played upgrade on ", character.name);
                                character.upgrades.push(card);
                            });
                    }

                    // Remove from hand
                    var index = player.hand.indexOf(card);
                    if (index > -1) {
                        player.hand.splice(index, 1);
                    }

                    // Check for ambush
                    self.endTurn();
                } });
            }
        });
    };

    self.endTurn = function () {
        var playerWaitingForTurn;
        var playingPlayer;
        if (self.player1.isTurn) {
            playingPlayer = self.player1;
            playerWaitingForTurn = self.player2;
        } else if (self.player2.isTurn) {
            playingPlayer = self.player2;
            playerWaitingForTurn = self.player1;
        }

        if (!playerWaitingForTurn.hasClaimed)
            self.setTurn(playerWaitingForTurn);
        else
            self.setTurn(playingPlayer);
    };

    self.setTurn = function(player) {
        self.turns.push(new Turn(player));
        player.isTurn = true;

        if (self.player1 !== player) self.player1.isTurn = false;
        if (self.player2 !== player) self.player2.isTurn = false;

        determineAvailableActions(player);

        console.log("Turn ", player.name);
    };

    return self;
}