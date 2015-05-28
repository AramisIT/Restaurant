(function () {

    function AcceptanceBL() {
        var _this = this;

        var updateTotalSum = function (table) {
            var totalSum = 0.0;
            table.find('tbody').find('tr:not(:last-child)').each(function (index, _row) {
                totalSum += $(_row).tableField("Sum");
            });
            $.aramisProperty('Sum', totalSum);
        }

        this.WaresChanged = function (fieldName, row, table) {
            if (!fieldName || fieldName === "Price" || fieldName === "Quantity") {
                row.tableField("Sum", row.tableField("Price") * row.tableField("Quantity"));

                updateTotalSum(table);
            }
        }

        this.WaresRowDeleted = function (table, row) {
            updateTotalSum(table);
        }

        this.OriginalWaresChanged = function (fieldName, row, table) {
            if (fieldName === "Price" || fieldName === "Quantity") {
                row.tableField("Sum", row.tableField("Price") * row.tableField("Quantity"));

                var totalSum = 0.0;
                table.find('tbody').find('tr:not(:last-child)').each(function (index, _row) {
                    totalSum += $(_row).tableField("Sum");
                });
                $.aramisProperty('Sum', totalSum);
            }
        }
    }

    $A.handleTableValueChanged.AcceptanceBL = new AcceptanceBL();

    $A.handleOnEditStart = function (tableName, $row, propertyName) {
        if (tableName === "GoodsAcceptance" && propertyName === "BoxesTotal") {
            var maxToAccept = $row.tableField("BoxesTotal") - $row.tableField("BoxesAcceptedAnotherSalePoints");
            $row.tableField("BoxesAcceptedCurrentSalePoint", maxToAccept);
        }
    }
})();