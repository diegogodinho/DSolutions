var controllerUsuario = angular.module('controllerUsuario', []);

controllerUsuario.controller('UsuarioListaCtrl', ['$scope', '$location', '$http',
  function ($scope, $location, $http) {
      $http.get('api/Usuario').success(function (data) {
          $scope.usuarios = data;
      }).error(function (data) {
          alert('Falha ao buscar Usuarios.');
      });      
      $scope.IrParaLogin = function () {
          $location.path("/Login");
      };
      $('.form-control').tooltip();
      LoadBootstrapValidatorScript(DemoFormValidator);
  } ]);

controllerUsuario.controller('UsuarioDetalheCtrl', ['$scope', '$location', '$routeParams', '$http',
 function ($scope, $location, $routeParams, $http) {
     $http.get('api/Usuario/' + $routeParams.id).success(function (data) {
         $scope.usuario = data;
     }).error(function (data) {
         alert('Falha ao buscar Usuarios.');         
     });
     $scope.Voltar = function () {
         $location.path("/Usuario");
     };
 } ]);