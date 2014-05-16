var controllerPadrao = angular.module('controllerPadrao', []);

controllerPadrao.controller('PrincipalCtrl', ['$scope', '$location', '$http',
  function ($scope, $location, $http) {
      $scope.CaminhoListaUsuario = '/Usuario';
      $scope.CaminhoCadastroCategoriaPrd = '/Usuario';
      $scope.CaminhoCadastroPrd = '/Usuario';
  } ]);

