angular.module('swd').directive('actionMenu', [
    function () {
        'use strict';

        return {
            restrict: 'E',
            replace: true,
            scope: {
                actions: '='
            },
            templateUrl: "/templates/actionMenu.html",
            link: function (scope, element, attrs) {

            }
        };
    }
]);
