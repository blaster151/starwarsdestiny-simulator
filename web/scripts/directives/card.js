angular.module('swd').directive('card', ['selectorService',
    function (selectorService) {
        'use strict';

        return {
            restrict: 'E',
            replace: false,
            scope: {
                card: '='
            },
            templateUrl: "/templates/card.html",
            link: function (scope, element, attrs) {
                scope.onSelected = function(item) {
                    console.log("in ons");
                    console.log(item.card);
                    if (item.card.isSelectableTarget) {
                        console.log("here");
                        selectorService.notifySelected(item.card);
                    }
                };
            }
        };
    }
]);
