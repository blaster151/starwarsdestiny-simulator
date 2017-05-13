angular.module('swd').directive('playerView', [
    function () {
        'use strict';

        return {
            restrict: 'E',
            replace: false,
            scope: {
                match: '=',
                player: '='
            },
            templateUrl: "/templates/playerView.html",
            link: function (scope) {
                scope.range = function (count) {
                    var start = 1;
                    var end = count;
                    var step = 1;
                    var offset = 0;

                    var len = (Math.abs(end - start) + ((offset || 0) * 2)) / (step || 1) + 1;
                    var direction = start < end ? 1 : -1;
                    var startingPoint = start - (direction * (offset || 0));
                    var stepSize = direction * (step || 1);

                    return Array(len).fill(0).map(function (_, index) {
                        return startingPoint + (stepSize * index);
                    });

                };
            }
        };
    }
]);
