angular.module('MasterTipos.service', [])
    .factory('MasterTiposService', [
        '$http',
        function ($http) {
            return {
                getInitMasterTipos: function () {
                    return $http({
                        method: 'Get',
                        url: '/MasterTipos/GetInit'
                    });
                },
                saveTipoMoneda: function (TipoMoneda) {
                    return $http({
                        method: 'Post',
                        url: '/MasterTipos/SaveTipoMoneda',
                        data: { TipoMoneda: TipoMoneda }
                    });
                },
                editTipoMoneda: function (TipoMoneda) {
                    return $http({
                        method: 'Post',
                        url: '/MasterTipos/EditTipoMoneda',
                        data: { TipoMoneda: TipoMoneda }
                    });
                },
                deleteTipoMoneda: function (TipoMoneda) {
                    return $http({
                        method: 'Post',
                        url: '/MasterTipos/DeleteTipoMoneda',
                        data: { IdTipoMoneda: TipoMoneda }
                    });
                }
            }
                       }]);
