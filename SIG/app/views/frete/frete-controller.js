'use strict';

angular.module('sig.app')
    .controller('FreteCtrl', ['$scope','FreteService',
        function ($scope, service) {
            var vm = this;
            vm.lista = [];
            vm.loading = false;

            vm.fretes = {
                id: '',
                preco: ''
            };

            vm.initial = function () {

                service.buscar().then(function (result) {
                    vm.fretes = result.data.element;
                });
            };


            vm.initial();
        }
    ])
    .controller('FreteEdtCtrl', ['$scope', '$stateParams', 'FreteService',
        function ($scope, $stateParams, service) {
            var vm = this;

            vm.perfil = "";
            vm.nome = "";
            vm.fretes = [];
            vm.loading = false;

            vm.frete = {
                Codigo: $stateParams.codigo,
                id: '',
                preco: ''
            };
            
            vm.initial = function () {

                if (vm.frete.Codigo > 0) {
                    service.buscarId(vm.imovel.Codigo).then(function (result) {                        
                    });
                }
            };

            vm.salvar = function () {

                if (vm.frete.id === "") {
                    swal({
                        title: "Atenção!",
                        text: "Favor informar um Id!",
                        type: "warning"
                    });
                    return;
                }

                if (vm.frete.preco === "") {
                    swal({
                        title: "Atenção!",
                        text: "Favor informar um preço!",
                        type: "warning"
                    });
                    return;
                }
                
                vm.loading = true;

                service.save(vm.frete).then(function (result) {
                    vm.loading = false;

                    if (result.data.status === 400) {
                        swal({
                            title: "Atenção!",
                            text: result.data.message,
                            type: "info"
                        });
                    };

                    swal({
                        title: "Sucesso!",
                        text: "Frete Cadastrado com Sucesso!",
                        type: "success",
                        showCancelButton: true,
                        cancelButtonText: "Não!",
                        confirmButtonColor: "green",
                        confirmButtonText: "Sim!",
                        showLoaderOnConfirm: true
                    }).then(function () { }).catch(swal.noop);

                    location = __path + '#/frete/lista';
                    
                    vm.frete = result.data.element;
                });

            };

            vm.return = function (callback) {
                location = __path + '#/frete/lista';
            };

            vm.initial();
        }
    ])
    .controller('FreteSimCtrl', ['$scope', '$stateParams', 'FreteService',
        function ($scope, $stateParams, service) {
            var vm = this;

            vm.perfil = "";
            vm.nome = "";
            vm.fretes = [];
            vm.freteSel = '';
            vm.loading = false;

            vm.frete = {
                id: 0,
                preco: 0,
                origem: '',
                destino: '',
                valior: ''
            };

            vm.initial = function () {
                service.buscar().then(function (result) {
                    vm.fretes = result.data.element;
                });
            };

            vm.calc = function () {

                if (vm.frete.origem === "") {
                    swal({
                        title: "Atenção!",
                        text: "Favor informar uma origem!",
                        type: "warning"
                    });
                    return;
                }

                if (vm.frete.destino === "") {
                    swal({
                        title: "Atenção!",
                        text: "Favor informar um destino!",
                        type: "warning"
                    });
                    return;
                }

                if (vm.frete.valor === "") {
                    swal({
                        title: "Atenção!",
                        text: "Favor selecionar um preço!",
                        type: "warning"
                    });
                    return;
                }

                vm.loading = true;

                service.calc(vm.frete).then(function (result) {
                    vm.loading = false;

                    if (result.data.status === 400) {
                        swal({
                            title: "Atenção!",
                            text: result.data.message,
                            type: "info"
                        });
                    };

                    vm.value = result.data.element;

                    swal({
                        title: "Sucesso!",
                        text: "O valor aproximado do frete para esse destino é " + vm.value + " km",
                        type: "success",
                        showCancelButton: true,
                        cancelButtonText: "Não!",
                        confirmButtonColor: "green",
                        confirmButtonText: "Sim!",
                        showLoaderOnConfirm: true
                    }).then(function () { }).catch(swal.noop);
                });

            };

            vm.return = function (callback) {
                location = __path + '#/frete/lista';
            };

            vm.initial();
        }
    ]);