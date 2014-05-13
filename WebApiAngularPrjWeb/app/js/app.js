var diegoApp = angular.module('diegoApp', [
  'ngRoute',
  'diegoController'
]);
diegoApp.config(['$routeProvider',
  function ($routeProvider) {
      $routeProvider.
      when('/Usuario', {
          templateUrl: 'partials/UsuarioList.htm',
          controller: 'UsuarioListController'
      }).
      when('/Usuario/:id', {
          templateUrl: 'partials/UsuarioDetails.htm',
          controller: 'UsuarioDetailsController'
      }).
      otherwise({
          redirectTo: '/Usuario'
      });
  } ]);