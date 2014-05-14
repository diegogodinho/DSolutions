var diegoApp = angular.module('diegoApp', [
  'ngRoute',
  'controllerPadrao'
]);
diegoApp.config(['$routeProvider',
  function ($routeProvider) {
      $routeProvider.
      when('/Usuario', {
          templateUrl: 'partials/Usuario/UsuarioList.html',
          controller: 'UsuarioListController'
      }).
      when('/Usuario/:id', {
          templateUrl: 'partials/Usuario/UsuarioDetails.html',
          controller: 'UsuarioDetailsController'
      }).
       when('/Login', {
           templateUrl: 'partials/Login.html',
           controller: 'LoginCtrl'
       }).
      otherwise({
          redirectTo: '/'
      });
  } ]);