angular.module('swd').directive('die', ['selectorService',
    function (selectorService) {
        'use strict';

        return {
            restrict: 'E',
            replace: false,
            scope: {
                die: '='
            },
            templateUrl: "/templates/die.html",
            link: function (scope, element, attrs) {
                scope.onSelected = function (item) {
                    console.log("in onsd");
                    console.log(item.die);
                    if (item.die.isSelectableTarget) {
                        console.log("here");
                        selectorService.notifySelected(item.die);
                    }
                };

                scope.getDieTypeImage = function() {
                    return "/images/melee.png";
                };
            }
        };
    }
]);
