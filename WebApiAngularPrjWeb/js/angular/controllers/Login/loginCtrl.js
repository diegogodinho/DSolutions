var controllerLogin = angular.module('controllerLogin', []);

controllerLogin.controller('LoginCtrl', ['$scope', '$location', '$routeParams', '$http',
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