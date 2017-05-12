angular.module('swd').directive('cardBrowser', [
    function () {
        'use strict';

        return {
            restrict: 'E',
            replace: true,
            scope: {
                cards: '=',
                onSelected: '&'
            },
            templateUrl: "/templates/cardBrowser.html",
            link: function (scope, element, attrs) {

            }
        };
    }
]);
