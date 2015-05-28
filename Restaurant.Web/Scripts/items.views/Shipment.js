(function () {

    function ShipmentBL() {
        this.WaresChanged = function (fieldName, row, table) {
            if (!fieldName || fieldName === "Price" || fieldName === "Quantity") {
                $A.itemData.updateRowSum(row);
                if (fieldName === "Price") {
                    var _wareKey = "w" + row.tableField("Ware").id.toString();
                    var _wareData = $A.itemData.waresAutoFillData[_wareKey];
                    if (_wareData) {
                        _wareData.price = $.toNumber(row.tableField("Price"));
                    }
                }
            }
            else if (fieldName === "Tare" || fieldName === "BoxesQuantity") {
                if ($('#computeNet').is(":checked") && $A.updateGrossForCurrentRow) {
                    $A.updateGrossForCurrentRow(row);
                }

                $A.itemData.updateSellingWeight(row);

                if (fieldName === "BoxesQuantity") {
                    $A.itemData.updateNetForSellingPerBoxes(row);
                }
            }
            else if (fieldName === "Ware") {
                $A.itemData.handleWareChanged(row);
            }
            else if (fieldName === "SellingWeight") {
                $A.itemData.updateNetForSellingPerBoxes(row);
            }
        }

        this.WaresRowDeleted = function (table, row) {
            $A.itemData.updateTotalSum(true);
        }
    }

    $A.handleTableValueChanged.ShipmentBL = new ShipmentBL();

    $A.itemData.addRowsToNewShipment = function () {
        var $table = $('#tableWares');
        if (!$A.itemData.waresAutoFillData || $.itemId() !== 0) return;

        for (var wareDataKey in $A.itemData.waresAutoFillData) {
            var wareData = $A.itemData.waresAutoFillData[wareDataKey];
            if (!wareData.ware.description.length) continue;

            var newRow = $table.addNewRowToTable();
            newRow.tableField("Ware", wareData.ware);
            $A.itemData.handleWareChanged(newRow);
        }
    }

    $A.itemData.updatePaid = function () {
        if ($.aramisProperty("Cash") && $.itemId() <= 0) {
            $.aramisProperty("Paid", $.aramisProperty("Sum"));
        }
    }

    $A.itemData.updateTotalSum = function (updateDiscount) {
        var totalSum = 0.0;
        $('#tableWares').find('tbody').find('tr:not(:last-child)').each(function (index, _row) {
            totalSum += $(_row).tableField("Sum");
        });
        if (updateDiscount) {
            var resultSum = Math.round(totalSum);
            var discount = totalSum - resultSum;
            $.aramisProperty('Sum', resultSum);
            $.aramisProperty('Discount', discount);
        } else {
            var discountValue = $.aramisProperty('Discount');
            $.aramisProperty('Sum', totalSum - discountValue);
        }
        $A.itemData.updatePaid();
    }

    $A.registerSynchronizedEvent("readyToCheckWares", $A.itemData.addRowsToNewShipment, { waresTableIsLoaded: false, waresInfoIsLoaded: false });

    var item = new $A.AramisItem();

    var onValueChanged = function (propertyName) {
        if (propertyName === "Contractor") {
            var id = Number($.aramisProperty('Contractor').id);
            var debit = 0;
            if (id > 0 && $A.debitsPerContractor) {
                var savedDebit = $A.debitsPerContractor["i" + id];
                if (savedDebit) {
                    debit = savedDebit;
                }
            }
            $.aramisProperty('Debt', debit);
        }
        else if (propertyName === "Discount") {
            $A.itemData.updateTotalSum(false);
        }
    }

    $A.printBill = function () {

        var dateStr = $A.toAramisString($.aramisProperty('Date'));
        var contractor = $.aramisProperty('Contractor');

        var billForm = window.open("", "bill " + new Date().getTime().toString().substring(5));

        var source = $('#tableWares tbody tr:not(:last-child)');
        var rows = "";

        var sum = $.aramisProperty('Sum');
        for (var i = 0; i < source.length; i++) {
            var row = $(source[i]);
            var net = row.tableField("Quantity");
            if (net === 0) continue;

            rows += "<tr><td>" + row.tableField("Ware").description + "</td>" +
                "<td>" + $.toStringForView(row.tableField("Price")) + "</td>" +
                "<td>" + $.toStringForView(net) + "</td>" +
                "<td>" + $.toStringForView(row.tableField("Sum")) + "</td>" +
                "</tr>";
        }

        var startDebit = $.aramisProperty('Debt');
        var paid = $.aramisProperty('Paid');

        var debtReturn = Math.max(0, paid - sum);

        var doc = "<html><head><style>" +
            "em { font-style: normal; font-weight: bold; }" +
            "table, th, td {border: 1px solid #bbbbbb; border-collapse: collapse; border-spacing:0px;}" +
            "th {background-color: #dddddd; padding: 5 20px;}" +
            "td {padding: 3 5px; text-align: right; }" +
            "td:first-child {text-align: left; }" +

            "</style></head>" +
            "<body>" +
            "<p>Відвантаження від <em>" + dateStr + "</em></p>" +
            "<p>Клієнт: <em>" + contractor.description + "</em></p>" +
            "<table><thead><tr><th>Продукція</th><th>Ціна, грн.</th><th>Кількість, кг</th><th>Сума, грн.</th></tr></thead>" +
            "<tbody>" + rows + "</tbody></table>" +
            "<p>Всього: <em>" + $.toStringForView(sum, 1) + "</em> грн.</p>" +
            "<p>борг старий: <em>" + $.toStringForView(startDebit, 0) + "</em> грн.</p>" +
            "<p>повернення старого боргу: <em>" + $.toStringForView(debtReturn, 0) + "</em> грн.</p>" +
            "<p>оплата відвантаження: <em>" + $.toStringForView(Math.min(sum, paid), 0) + "</em> грн.</p>" +
            "<p>заг. борг після відвантаження: <em>" + $.toStringForView((startDebit + sum - paid), 0) + "</em> грн.</p>" +

            "</body></html>";
        billForm.document.write(doc);
        billForm.print();
    }

    var loadWaresInfo = function () {
        $.post("/AddData/GetWaresAutoFillData", null, function (data) {
            var waresAutoFillData = {};

            var wares = data.Item1;
            var waresNames = data.Item2;
            var prices = data.Item3;
            for (var i = 0; i < wares.length; i++) {
                waresAutoFillData["w" + wares[i].toString()] = {
                    ware: { id: wares[i], description: waresNames[i] },
                    price: prices[i]
                };
            }

            $A.itemData.waresAutoFillData = waresAutoFillData;

            $A.notifyAsyncTaskAccomplished("readyToCheckWares", "waresInfoIsLoaded");

            loadDebitsPerContractor();
        });
    }

    var loadDebitsPerContractor = function () {
        $.post("/AddData/GetDebitsPerContractor", $.aramisProperty("Contractor").id.toString(), function (data) {
            var debitsPerContractor = {};
            for (var i = 0; i < data.length; i++) {
                var contractorInfo = data[i];
                debitsPerContractor["i" + contractorInfo[0].toString()] = Number(contractorInfo[1]);
            }
            $A.debitsPerContractor = debitsPerContractor;
        });
    }

    item.onPageLoad = function () {

        $A.onValueChanged = onValueChanged;

        $.post("/AddData/GetTarePerNomenclature", null, function (data) {
            var tareData = {};
            for (var i = 0; i < data.length; i++) {
                var wareInfo = data[i];
                tareData["w" + wareInfo.WareId.toString()] = wareInfo.TareList;
            }
            $A.tareData = tareData;

            loadWaresInfo();
        });

        var sellByBoxes = $.aramisProperty("SellByBoxes");

        if (!sellByBoxes && $.isToday($.aramisProperty("Date"))) {
            var $lastControl = $('#itemForm > div.form-group:last');
            $lastControl.after($('<div class="form-group">' +
                '<label style="margin-top: -7px;" class="col-sm-4 col-xs-4 col-md-5 col-lg-5 control-label">' +
                'Текущий брутто: <input step="0.1" type="number" id="gross" class="info-data" value="0" style="width: 60px; text-align: right;"></input> кг</label>' +
                '<div class="col-xs-7 col-sm-5 col-md-3 col-lg-3">' +
                '<div class="checkbox"><input class="checkbox" type="checkbox" name="computeNet" id="computeNet" checked/>' +
                '<label for="computeNet">Автоматический расчет нетто</label>' +
                '</div></div></div>'));

            $('#saveButton').after($('<button id="updateNet" class="btn btn-primary btn-lg">Обновить нетто</button>'));
            $('#updateNet').on('click', function () {
                if ($A.lastLineNumber <= 0) return;
                $A.updateGrossForCurrentRow($('#tableWares tbody tr:nth-child(' + $A.lastLineNumber.toString() + ')'));
            });


            var $grossContainer = $('#gross');
            window.setInterval(function () {
                if ($.aramisProperty("computeNet") === false) {
                    return;
                }

                $.ajax({
                    url: "http://" + ClientConsts.GET_WEIGHT_URL,
                    type: "GET",
                    dataType: 'json',
                    success: function (data) {
                        $grossContainer.val(data.gross.toString());
                    },
                });
            }, 1000);

            $A.updateGrossForCurrentRow = function ($row) {
                if (!$row.length) return;

                var gross = parseFloat($('#gross').val());
                if (isNaN(gross)) return;

                var boxes = $row.tableField("BoxesQuantity");
                var result = (/: (.*)г$/g).exec($row.tableField("Tare").description);
                if (!result || result.length < 2) return;

                var oneBoxWeight = parseFloat(result[1]);
                if (isNaN(oneBoxWeight)) return;

                $row.tableField("Quantity", gross - boxes * oneBoxWeight * 0.001);
                $A.itemData.updateRowSum($row);
            }
        }

        $('#additionalButtons').prepend($('<button class="btn btn-primary btn-lg" id="billButton">Чек</button>'));

        $A.updateButtons();

        $A.itemData.handleWareChanged = function ($row) {
            var wareKey = "w" + $row.tableField("Ware").id.toString();
            var wareData = $A.itemData.waresAutoFillData[wareKey];

            var newPrice = 0;
            if (wareData && wareData.price > 0) {
                newPrice = wareData.price;
            }
            $row.tableField("Price", newPrice);

            var appropriateTare = $A.tareData[wareKey];
            var tareInfo = null;
            if (appropriateTare && appropriateTare.length) {
                tareInfo = appropriateTare[0];
            }
            $row.tableField("Tare", tareInfo);
            $A.itemData.updateSellingWeight($row);
        }

        $A.itemData.updateSellingWeight = function ($row) {
            if (!$.aramisProperty("SellByBoxes")) return;

            var wareKey = "w" + $row.tableField("Ware").id.toString();
            var tareId = $row.tableField("Tare").id;

            var appropriateTare = $A.tareData[wareKey];
            var currentTareInfo = null;

            if (tareId !== 0 && appropriateTare !== undefined) {
                for (var tareInfoIndex = 0; tareInfoIndex < appropriateTare.length; tareInfoIndex++) {
                    var tareInfo = appropriateTare[tareInfoIndex];
                    if (tareInfo.id === tareId) {
                        currentTareInfo = tareInfo;
                        break;
                    }
                }
            }

            $row.tableField("SellingWeight", currentTareInfo === null ? 0 : currentTareInfo.sellingWeight);

            $A.itemData.updateNetForSellingPerBoxes($row);
        }

        $A.itemData.updateNetForSellingPerBoxes = function ($row) {
            if (!$.aramisProperty("SellByBoxes")) return;

            var net = $row.tableField("BoxesQuantity") * $row.tableField("SellingWeight");
            $row.tableField("Quantity", net);

            $A.itemData.updateRowSum($row);
        }

        $A.onNewItemAdded = function () {
            $A.itemData.addRowsToNewShipment();
        }

        $A.onTableRetrieved = function (tableId, $table) {
            if (tableId !== "Wares") return;

            $A.notifyAsyncTaskAccomplished("readyToCheckWares", "waresTableIsLoaded");

            if (!$("th:contains('Нетто отгружено')").length) {
                $("th:contains('Нетто продажи')").text('Нетто');
            }
        }

        $A.itemData.updateRowSum = function ($row) {
            $row.tableField("Sum", $row.tableField("Price") * $row.tableField("Quantity"));
            $A.itemData.updateTotalSum(true);
        }

        $('#billButton').on('click', $A.printBill);
    }

    $A.registerAramisItem(item);

})();