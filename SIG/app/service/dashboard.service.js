(function () {
    'use strict';

    angular.module('sig.app')
        .service('Dashboardervice', mainService);
    mainService.$inject = ['$http'];

    function mainService($http) {
        var service = this;

        service.buscar = function () {
            return $http.get(__path + 'Dashboard/ObtemInfo').then(handleSuccess, handleError);
        }

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

            var tenMinutes = 60 * 30,
                display = document.querySelector('#time');
            startTimer(tenMinutes, display);

            if (res.data.element != 'nodata') {
                var objectUrl = __path + res.data.element;
                window.open(objectUrl);

                return {
                    success: true,
                    data: res.data
                };
            }
            else {
                return {
                    success: true,
                    data: 'nodata'
                };
            }
        }

        function handleSuccess(res) {

            var tenMinutes = 60 * 30,
                display = document.querySelector('#time');
            startTimer(tenMinutes, display);

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