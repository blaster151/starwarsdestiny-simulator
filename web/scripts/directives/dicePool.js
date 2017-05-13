angular.module('swd').directive('dicePool', [
    function () {
        'use strict';

        return {
            restrict: 'E',
            replace: false,
            scope: {
                dice: '='
            },
            templateUrl: "/templates/dicePool.html",
            link: function (scope, element, attrs) {

            }
        };
    }
]);
