angular.module('swd').directive('cardsDisplay', [
    function () {
        'use strict';

        return {
            restrict: 'E',
            replace: true,
            scope: {
                cards: '='
            },
            templateUrl: "/templates/cardsDisplay.html",
            link: function (scope, element, attrs) {

            }
        };
    }
]);
