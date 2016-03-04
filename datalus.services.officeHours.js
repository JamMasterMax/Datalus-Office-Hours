if (!datalus.services.officeHours) {
    datalus.services.officeHours = {};
}


datalus.services.officeHours.getAll = function (onSuccess, onError) {
    var url = "/api/officehours";
    var settings = {
        cache: false
        , success: onSuccess
        , error: onError
        , type: "GET"
    };
    $.ajax(url, settings);
}

datalus.services.officeHours.getById = function (id, onSuccess, onError) {
    var url = "/api/officehours/" + id;
    var settings = {
        cache: false
        , success: onSuccess
        , error: onError
        , type: "GET"
    };
    $.ajax(url, settings);
}

datalus.services.officeHours.post = function (formData, onSuccess, onError) {
    var url = "/api/officehours";
    var settings = {
        cache: false
        , contentType: "application/json; charset=UTF-8"
        , data: JSON.stringify(formData)
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "POST"
    };
    $.ajax(url, settings);
}

datalus.services.officeHours.put = function (id, formData, onSuccess, onError) {
    var url = "/api/officehours/" + id;
    var settings = {
        cache: false
        , contentType: "application/json; charset=UTF-8"
        , data: JSON.stringify(formData)
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "PUT"
    };
    $.ajax(url, settings);
}

datalus.services.officeHours.delete = function (id, onSuccess, onError) {
    var url = "/api/officehours/" + id;
    var settings = {
        cache: false
        , success: onSuccess
        , error: onError
        , type: "DELETE"
    };
    $.ajax(url, settings);
}
