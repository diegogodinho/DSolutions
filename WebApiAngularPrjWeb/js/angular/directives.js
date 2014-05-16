var customDirectives = angular.module('customDirectives', []);

customDirectives.directive('customdatepicker', function () {
    return {
        restrict: 'A',        
        link: function (scope, element) {
            $(element).datepicker({ setDate: new Date() });
            
        }
    };
});