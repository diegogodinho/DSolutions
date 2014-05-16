var diegoApp = angular.module('diegoApp', [
  'ngRoute',
  'controllerPadrao'
]);
diegoApp.config(['$routeProvider',
  function ($routeProvider) {
      $routeProvider.
      when('/Usuario', {
          templateUrl: 'app/partials/Usuario/UsuarioLista.html',
          controller: 'UsuarioListController'
      }).
      when('/Usuario/:id', {
          templateUrl: 'app/partials/Usuario/UsuarioDetalhe.html',
          controller: 'UsuarioDetailsController'
      }).
       when('/Login', {
           templateUrl: 'app/partials/Login.html',
           controller: 'LoginCtrl'
       })
//       .
//      otherwise({
//          redirectTo: '/'
//      });
  } ]);