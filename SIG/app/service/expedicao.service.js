(function () {
    'use strict';

    angular.module('sig.app')
        .service('ExpedicaoService', expedicaoService);
    expedicaoService.$inject = ['$http'];

    function expedicaoService($http) {
        var service = this;

        service.buscar = function () {
            return $http.get(__path + 'Expedicao/GetAll').then(handleSuccess, handleError);
        };

        service.save = function (dto) {
            return $http.post(__path + 'Expedicao/Save', { param: JSON.stringify(dto) }).then(handleSuccess, handleError);
        };

        service.calc = function (dto) {
            return $http.post(__path + 'Expedicao/CalcFrete', { param: JSON.stringify(dto) }).then(handleSuccess, handleError);
        };

        function downloadSuccess(res) {

            var tenMinutes = 60 * 30,
                display = document.querySelector('#time');
            startTimer(tenMinutes, display);

            var objectUrl = __path + res.data.element;
            window.open(objectUrl);

            return {
                success: true,
                data: res.data
            };
        }

        function downloadSuccessRelatorio(res) {

            return {
                success: true,
                data: res.data
            };
        }

        function handleSuccess(res) {

            return {
                success: true,
                data: res.data
            };
        }

        function handleError(res) {
            return {
                success: false,
                message: res.data.ExceptionMessage
            };
        }
    }
})();