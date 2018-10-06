'use strict';

angular.module('sig.app')
    .controller('UsuarioCtrl', ['$scope',
        function ($scope) {
            var vm = this;
            vm.teste = "PATOO";
            vm.dashboard = [];
            vm.loading = false;

            vm.filtro = {
                DataInicio: '',
                DataFim: ''
            };

            //vm.initial();
        }
    ]);