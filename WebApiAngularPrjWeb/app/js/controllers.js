var diegoController = angular.module('diegoController', []);
diegoController.controller('UsuarioListController', ['$scope', '$http',
  function ($scope, $http) {
      $http.get('api/Usuario').success(function (data) {
          $scope.usuarios = data;
      }).error(function (data) {
          alert('Falha ao buscar Usuarios.');
          console.log(data);
      });
  } ]);

diegoController.controller('UsuarioDetailsController', ['$scope', '$routeParams', '$http',
 function ($scope, $routeParams, $http) {
     $http.get('api/Usuario/' + $routeParams.id).success(function (data) {
         $scope.usuario = data;
     }).error(function (data) {
         alert('Falha ao buscar Usuarios.');
         console.log(data);
     });
 } ]);