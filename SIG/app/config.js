function config($stateProvider, $urlRouterProvider, $ocLazyLoadProvider) {
    
    $urlRouterProvider.otherwise("index/main");

    $ocLazyLoadProvider.config({
        // Set to true if you want to see what and when is dynamically loaded
        debug: false
    });

    $stateProvider
        .state('index', {
            abstract: true,
            url: "/index",
            templateUrl: __path + "app/views/common/content.html",
        })
        .state('index.main', {
            url: "/main",
            templateUrl: __path + "app/views/main.html",
            data: { pageTitle: 'Dashboard' }
        })
        .state('usuario', {
            abstract: true,
            url: "/usuario",
            templateUrl: __path + "app/views/common/content.html"
        })
        .state('usuario.usuarios', {
            url: "/lista",
            templateUrl: __path + "app/views/usuario/usuario.html",
            data: { pageTitle: 'Lista de Usuarios' }
        })
        .state('frete', {
            abstract: true,
            url: "/frete",
            templateUrl: __path + "app/views/common/content.html"
        })
        .state('frete.fretes', {
            url: "/lista",
            templateUrl: __path + "app/views/frete/frete.html",
            data: { pageTitle: 'Lista de Fretes' }
        })
        .state('frete.add', {
            url: "/add/:codigo",
            templateUrl: __path + "app/views/frete/frete-register.html",
            data: { pageTitle: 'Cadsatro de Frete' },
            params: { codigo: 0 }
        })
        .state('frete.sim', {
            url: "/simular",
            templateUrl: __path + "app/views/frete/frete-simul.html",
            data: { pageTitle: 'Cadsatro de Frete' },
            params: { codigo: 0 }
        })
        .state('expedicao', {
            url: "/expedicao",
            templateUrl: __path + "app/views/common/content.html"
        })
        .state('expedicao.list', {
            url: "/lista",
            templateUrl: __path + "app/views/expedicao/expedicao-list.html",
            data: { pageTitle: 'Expdição dos Pedidos' }
        });
}
angular
    .module('sig.app')
    .config(config)
    .run(function ($rootScope, $state) {
        $rootScope.$state = $state;
    });