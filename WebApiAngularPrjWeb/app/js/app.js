var diegoApp = angular.module('diegoApp', [
  'ngRoute',
  'controllerPadrao'
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
       when('/Login', {
           templateUrl: 'partials/Login.htm',
           controller: 'LoginCtrl'
       }).
      otherwise({
          redirectTo: '/Usuario'
      });
  } ]);