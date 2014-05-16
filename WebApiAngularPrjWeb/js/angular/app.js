var DSolutions = angular.module('DSolutions', [
  'ngRoute',
  'controllerPadrao',
  'controllerUsuario',
  'controllerLogin',
  'customDirectives'
]);
DSolutions.config(['$routeProvider',
  function ($routeProvider) {
      $routeProvider.
      when('/Usuario', {
          templateUrl: 'Partials/Usuario/UsuarioLista.html',
          controller: 'UsuarioListaCtrl'
      }).
      when('/Usuario/:id', {
          templateUrl: 'Partials/Usuario/UsuarioDetalhe.html',
          controller: 'UsuarioDetalheCtrl'
      }).
       when('/Login', {
           templateUrl: 'Views/Login/Login.html',
           controller: 'LoginCtrl'
       })
       .
      otherwise({
          redirectTo: '/Usuario'
      });
  } ]);