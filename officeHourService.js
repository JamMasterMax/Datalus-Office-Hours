(function () {
    "use strict";

    angular.module("datalusApp", [])
        .factory('$officeHourService', OfficeHourServiceFactory);

    OfficeHourServiceFactory.$inject = ['$baseService', '$datalus'];

    function OfficeHourServiceFactory($baseService, $datalus) {
        var serviceObject = datalus.services.officeHours;
        var newService = $baseService.merge(true, {}, serviceObject, $baseService);

        return newService;
    }

})();
