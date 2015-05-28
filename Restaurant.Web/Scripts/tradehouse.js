$A.displayCashboxInfo = function () {
    $.post("/AddData/GetCashboxPerDay", null, function (data) {

        for (var fieldName in data) {
            $('#' + fieldName).text($.toStringForView(data[fieldName]));
        }

        $('#cashBox').show();
    });
}

$A.handleObjectWriting = function (tableName) {
    if (tableName === "ActiveWares" && Modernizr.localstorage) {

        var keysToRemove = [];

        var pattern = new RegExp('^(Nomenclature:)');
        for (var existsKey in localStorage) {
            if (pattern.test(existsKey)) {
                keysToRemove.push(existsKey);
            }
        }

        for (var i = 0; i < keysToRemove.length; i++) {
            localStorage.removeItem(keysToRemove[i]);
        }

        $A.clearCache();
    }
}
