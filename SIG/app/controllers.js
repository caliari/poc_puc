function MainCtrl($http, $sce, $scope, $timeout) {

    $scope.init = function () {
        //$http.get(__path + "Home/Info").then(function (data) {
        //    $scope.menu = data.data;
        //});
    };

    //$http.get(__path + "Home/NomeUsuario").then(function (data) {
    //    $scope.userName = data.data.Nome;

    //    if (data.data.Perfil === "Unidade") {
    //        location = __path + '#/analise/analise';
    //    }
    //});

    $scope.openDialog = function () {
        if (angular.isUndefined($scope.dialogAlteraSenha)) $scope.dialogAlteraSenha = $('[data-remodal-id=modal]').remodal();

        $scope.novasenha = {
            senha: '',
            novasenha: ''
        };

        $scope.dialogAlteraSenha.open();
    };

    $scope.alteraSenha = function () {
        UsuarioService.alteraSenha($scope.novasenha).then(function (result) {
            swal({
                title: "Sucesso!",
                text: "Senha alterada!",
                type: "success"
            });
        });
    };

    $scope.init();

    this.helloText = 'Welcome in SeedProject';
    this.descriptionText = 'It is an application skeleton for a typical AngularJS web app. You can use it to quickly bootstrap your angular webapp projects and dev environment for these projects.';

};


angular
    .module('sig.app')
    .controller('MainCtrl', MainCtrl);