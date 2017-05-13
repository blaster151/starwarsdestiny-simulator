angular.module('swd').directive('match', [
    function () {
        'use strict';

        return {
            restrict: 'E',
            replace: true,
            scope: {
                match: '='
            },
            templateUrl: "/templates/match.html",
            link: function (scope, element, attrs) {

            }
        };
    }
]);
