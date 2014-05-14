var controllerPadrao = angular.module('controllerPadrao', []);

controllerPadrao.controller('PrincipalCtrl', ['$scope', '$location', '$http',
  function ($scope, $location, $http) {
      $scope.CaminhoListaUsuario = '/Usuario';
      $scope.CaminhoCadastroCategoriaPrd = '/Usuario';
      $scope.CaminhoCadastroPrd = '/Usuario';
  } ]);


controllerPadrao.controller('UsuarioListController', ['$scope', '$location', '$http',
  function ($scope, $location, $http) {
      $http.get('api/Usuario').success(function (data) {
          $scope.usuarios = data;
      }).error(function (data) {
          alert('Falha ao buscar Usuarios.');
          console.log(data);
      });
      $scope.IrParaLogin = function () {
          $location.path("/Login");
      };
  } ]);

controllerPadrao.controller('UsuarioDetailsController', ['$scope', '$location', '$routeParams', '$http',
 function ($scope, $location, $routeParams, $http) {
     $http.get('api/Usuario/' + $routeParams.id).success(function (data) {
         $scope.usuario = data;
     }).error(function (data) {
         alert('Falha ao buscar Usuarios.');
         console.log(data);
     });
     $scope.Voltar = function () {
         $location.path("/Usuario");
     };
 } ]);

controllerPadrao.controller('LoginCtrl', ['$scope', '$location', '$routeParams', '$http',
 function ($scope, $location, $routeParams, $http) {
     $scope.Login = '';
     $scope.Senha = '';

     $scope.LogarUsuario = function () {
         var Login = {
             'Login': $scope.Login,
             'Senha': $scope.Senha
         };
         $http.post('api/Login', Login).success(function (data) {
             $location.path("/Usuario");
         }).error(function (data) {
             alert('Falha ao buscar Usuarios.');
             console.log(data);
         });
     };
     $scope.Voltar = function () {
         $location.path("/Usuario");
     };

 } ]);