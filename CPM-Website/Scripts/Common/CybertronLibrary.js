var getFormAsJson = function(formId){
    var data = {};
    $('#' + formId + ' input[type=text]').each(function (x, y) {
        data[y.name] = y.value;
    });

    $('#' + formId + ' input[type=radio]').each(function (x, y) {
        if (y.checked) {
            data[y.name] = y.value;
        }
    });
    return data;
}