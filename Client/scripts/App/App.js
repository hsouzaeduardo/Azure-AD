/// <reference path="../angular.min.js" />

var cidadesApp = angular.module('cidadesApp', ['AdalAngular']);

cidadesApp.config(['$httpProvider'
        , 'adalAuthenticationServiceProvider'
        , function ($httpProvider, adalProvider) {
            var endPoints = { "http://localhost:52706/"
                           : "5b1febf4-6863-49d4-9e67-b691b519d52e"
            }

            adalProvider.init({
                instance: 'https://login.microsoftonline.com/',
                tenant: '5b1febf4-6863-49d4-9e67-b691b519d52e',
                clientId: '9d76aca0-2b5f-4341-8cb7-97b624065ce5',
                endpoints: endPoints
            }, null);
        }]);

var cidadesController = cidadesApp.controller('cidadesController', [
    '$scope', '$http', 'adalAuthenticationService'
    , function ($scope, $http, adalService) {
        $scope.cidades = '';

        $scope.getCidade = function () {
            $http.get('http://localhost:52706/api/cidades?nomeCidade=Capivari').then(function (cidade) {
                
                $scope.cidades = cidade.data;
            });
        }

        $scope.login = function () {
             adalService.login();
        }

        $scope.logout = function () {
            adalService.logout();
        }
    }]);