'use strict';

angular.module('sig.app')
    .controller('ExpedicaoCtrl', ['$scope', 'ExpedicaoService', 
        function ($scope, service) {
            var vm = this;
            vm.lista = [];
            vm.loading = false;

            vm.expedicao = {
                id: '',
                status: '',
                solicitante: '',
                tempo: ''
            };

            vm.initial = function () {

                service.buscar().then(function (result) {
                    vm.expedicao = result.data.element;
                });
            };


            vm.initial();
        }
    ]);