angular.module('swd').directive('deckBuilder', [
    function () {
        'use strict';

        return {
            restrict: 'E',
            replace: true,
            scope: {
                deck: '=',
                cards: '='
            },
            templateUrl: "/templates/deckBuilder.html",
            controller: "deckBuilderController",
            link: function (scope, element, attrs) {

            }
        };
    }
]);
