(function ($) {
    $.fn.tableField = function (fieldName, fieldValue) {
        if (!this.is('tr')) return null;
        var $tr = this;

        var $theadRow = $tr.closest('table').find('thead tr');

        var $th = $theadRow.find('th[data-field-name="' + fieldName + '"]');
        if (!$th.length) return null;

        var typeDescription = $th.attr('data-t');
        if (!typeDescription) return null;

        var columnIndex = $theadRow.find('th').index($th[0]);
        var $td = $tr.find('td').eq(columnIndex);

        if (typeDescription === WebConsts.NUMBER_TYPE_DESCRIPTOR) {
            var decimalPoints = $th.attr(WebConsts.DECIMAL_POINTS_ATTR_NAME);
            decimalPoints = decimalPoints ? 1 * decimalPoints : 0;

            if (fieldValue != undefined) {
                $td.text($.toStringForView(Number(fieldValue).toFixed(decimalPoints)));
            } else {
                return $.toNumber($td.text(), decimalPoints);
            }
        } else if (typeDescription === WebConsts.CATALOG_TYPE_DESCRIPTOR) {
            if (fieldValue !== undefined) {
                if (fieldValue === null) {
                    $td.text('');
                    $td.attr(WebConsts.ID_ATTR_NAME, '0');
                }
                else if (fieldValue.description && (typeof fieldValue.id) !== "undefined") {
                    $td.text(fieldValue.description);
                    $td.attr(WebConsts.ID_ATTR_NAME, fieldValue.id.toString());
                }
            } else {
                return {
                    id: parseFloat(($td.attr(WebConsts.ID_ATTR_NAME) | 0).toString()),
                    description: $td.text()
                };
            }
        }
        return null;
    }

    $.fn.addNewRowToTable = function () {
        if (!this.is('table[data-aramis-name]')) return null;
        var $table = this;
        var $hiddenRow = $table.find('tbody tr:last');
        if (!$hiddenRow.length) return;

        var $newRow = $hiddenRow.clone();
        var $lastRowWithData = $hiddenRow.prev();
        $newRow.children().eq(0).text($lastRowWithData.length === 0 ? 1 : parseInt($lastRowWithData.children().eq(0).text()) + 1);

        $hiddenRow.before($newRow);
        return $newRow;
    }

    $.extend({
        aramisProperty: function (propertyName, propertyValue) {
            var $control = $("#" + propertyName);
            var typeName = $control.attr("data-t");

            if (!$control.length) return;
            if (propertyValue === undefined) {
                if ($control.is('input[type="number"]')) {
                    return parseFloat($control.val());
                }
                else if ($control.is('input[type="date"]')) {
                    var dateParts = $control.val().split("-");
                    return new Date(Number(dateParts[0]), Number(dateParts[1]) - 1, Number(dateParts[2]), 0, 0, 0, 0);
                }
                else if ($control.is('input[type="checkbox"]')) {
                    return $control.is(':checked');
                }
                else if ($control.is('input[type="hidden"]')) {
                    if (!typeName) {
                        return $control.val();
                    }
                    if (typeName == WebConsts.BOOL_TYPE_DESCRIPTOR) {
                        return $control.val().toLowerCase() === 'true';
                    }
                    else if (typeName == WebConsts.NUMBER_TYPE_DESCRIPTOR) {
                        return $.toNumber($control.val());
                    }
                    else if (typeName == WebConsts.CATALOG_TYPE_DESCRIPTOR) {
                        return {
                            id: (+$control.attr('data-value-id')),
                            description: $control.val()
                        }
                    }
                }
                else if ($control.is('select')) {
                    var choosedOption = $control.find(":selected");
                    if (!choosedOption) {
                        return { id: 0, description: "" };
                    }

                    return { id: Number(choosedOption.val()), description: choosedOption.text() };
                }
                else if ($control.is('p')) {
                    if (typeName === WebConsts.NUMBER_TYPE_DESCRIPTOR) {
                        return $.toNumber($control.text());
                    }
                    return parseFloat($control.text());
                }
                return "This control type is not supported yet";
            }

            var decimalPoints = $control.attr(WebConsts.DECIMAL_POINTS_ATTR_NAME);
            decimalPoints = decimalPoints ? 1 * decimalPoints : 0;

            var newValueStr = Number(Number(propertyValue).toFixed(decimalPoints))
                .toString();

            if ($control.is('input[type="number"]')) {
                $control.val(newValueStr);
            }
            else if ($control.is('input[type="date"]')) {
                $control.val(newValueStr);
            } else if ($control.is('p')) {
                if (typeName === WebConsts.NUMBER_TYPE_DESCRIPTOR) {
                    return $control.text($.toStringForView(newValueStr));
                } else {
                    $control.text(newValueStr);
                }
            }
            else if ($control.is('input[type="checkbox"]')) {
                var isChecked = $control.is(':checked');
                if (propertyValue !== isChecked) {
                    $control.prop('checked', propertyValue ? "true" : "false");
                }
            }
            else if ($control.is('input[type="hidden"]')) {
                $control.val((propertyValue == null) ? "" : propertyValue.toString());
            }

            return null;
        },
        itemId: function () {
            var $control = $("#" + WebConsts.ITEM_ID_NAME);
            if (!$control.length) return 0;

            return parseFloat($control.val());
        },
        toNumber: function (value, decimalPoints) {
            var valueStr = value.toString().replace(",", ".").replace(/\u00A0/g, "");
            if (valueStr.length === 0) {
                valueStr = "0";
            }

            valueStr = parseFloat(valueStr);
            if (decimalPoints !== undefined) {
                valueStr = Number(valueStr.toFixed(decimalPoints));
            }

            return valueStr;
        },
        toStringForView: function (number, decimalPoints) {
            var numberValue = parseFloat(number.toString().replace(',', '.'));
            if (isNaN(numberValue)) {
                return "0";
            }

            if (decimalPoints !== undefined) {
                numberValue = Number(numberValue.toFixed(decimalPoints));
            }

            var str = numberValue.toString();
            var parts = (str + "").split(".");
            var main = parts[0];
            var len = main.length;
            var output = "";
            var i = len - 1;

            while (i >= 0) {
                output = main.charAt(i) + output;
                if ((len - i) % 3 === 0 && i > 0) {
                    output = "\u00A0" + output;
                }
                --i;
            }
            // put decimal part back
            if (parts.length > 1) {
                output += "." + parts[1];
            }
            return output;
        },
        isToday: function (dateValue) {
            var today = new Date();
            today.setHours(0, 0, 0, 0);
            dateValue.setHours(0, 0, 0, 0);

            return today.getTime() === dateValue.getTime();
        },
        iPhoneIsUsing: function () {
            return /iphone/i.test(navigator.userAgent.toLowerCase());
        },
        iPadIsUsing: function () {
            return /ipad/i.test(navigator.userAgent.toLowerCase());
        }
    });

})(jQuery);

function Aramis(jq) {
    // "use strict";

    var synchronizedEventsSet = {};

    this.updateButtons = function () {
        if ($.iPhoneIsUsing()) {
            $('button.btn-lg').removeClass('btn-lg').addClass('btn-md');
        }
    }

    this.handleTableValueChanged = function (objectName, subtableName, _fieldName, _row, _table) {

        var bl = _this.handleTableValueChanged[objectName + "BL"];
        if (bl) {
            var tableChangedFunc = bl[subtableName + "Changed"];
            if (tableChangedFunc && typeof (tableChangedFunc) === "function") {
                tableChangedFunc(_fieldName, _row, _table);
            }
        }
    }

    this.registerSynchronizedEvent = function (eventName, method, requaredEvents) {
        if (typeof (method) === 'function') {
            synchronizedEventsSet[eventName] = {
                method: method,
                requaredEvents: requaredEvents
            }
        }
    }

    this.notifyAsyncTaskAccomplished = function (eventName, subEventName) {
        var syncEvent = synchronizedEventsSet[eventName];
        if (syncEvent && syncEvent.requaredEvents && typeof (syncEvent.requaredEvents[subEventName]) !== 'undefined') {
            delete syncEvent.requaredEvents[subEventName];

            if (Object.keys(syncEvent.requaredEvents).length === 0) {
                syncEvent.method();
            }
        }
    }

    this.itemData = {};

    this.toAramisString = function (value) {
        if (value instanceof Date) {
            var day = value.getDate();
            var month = 1 + value.getMonth();
            return (day < 10 ? "0" : "") + day + "." + (month < 10 ? "0" : "") + month + "." + value.getFullYear();
        }
    };

    var _this = this;

    var $ = jq;
    this.aramisItems = [];

    this.AramisItem = function () {
        this.onPageLoad = null;
    }

    this.registerAramisItem = function (aramisItem) {
        _this.aramisItems.push(aramisItem);
    }

    this.getSavedLocalyItems = function (tableName) {
        if (!Modernizr.localstorage) return undefined;

        var savedItemsKeys = [];
        var pattern = new RegExp('^(ATS_' + tableName + ')');
        for (var existsKey in localStorage) {
            if (pattern.test(existsKey)) {
                savedItemsKeys.push(existsKey);
            }
        }

        if (!savedItemsKeys.length) return undefined;

        if (!mainFields) {
            initMainFields();
        }

        var TableColumn = function (_fieldName, _fieldDescription, _type) {
            this.fieldName = _fieldName;
            this.description = _fieldDescription;
            this.typeDescriptor = _type;
            this.tableName = "";
            this.dataAttr = "",
            this.isReadonly = true;
            this.values = [];
            this.valuesDescriptions = [];
        };

        var idColumn = new TableColumn("Id", "Id", "");
        var savedItems = {
            readOnly: true,
            data: [idColumn]
        };

        for (var i = 0; i < mainFields.length; i++) {
            var fieldInfo = mainFields[i];
            var columnInfo = new TableColumn(fieldInfo.name, fieldInfo.description,
                (fieldInfo.type === WebConsts.BOOL_TYPE_DESCRIPTOR) ? fieldInfo.type : "");
            savedItems.data.push(columnInfo);
        }

        for (var savedItemIndex = 0; savedItemIndex < savedItemsKeys.length; savedItemIndex++) {
            var storageKey = savedItemsKeys[savedItemIndex];
            var itemData = storageKey.split("_");

            idColumn.valuesDescriptions.push(itemData[2]);

            for (var columnIndex = 1; columnIndex < savedItems.data.length; columnIndex++) {
                var columnsValues = localStorage.getItem(storageKey).split("|||$|||")[0].split("$?$");
                savedItems.data[columnIndex].valuesDescriptions.push(columnsValues[columnIndex - 1]);
            }
        }

        return savedItems;
    }

    var invokeOnPageLoaded = function () {
        if ($A.aramisItems && $A.aramisItems.length) {

            for (var i = 0; i < $A.aramisItems.length; i++) {
                var item = $A.aramisItems[i];
                if (typeof item.onPageLoad === "function") {
                    item.onPageLoad();
                }
            }

        }
    }
    var uploadDocuments = function (itemsSet) {
        if (!itemsSet.length) {
            invokeOnPageLoaded();
            return;
        }

        var tasksToSave = itemsSet.pop();

        var data = localStorage.getItem(tasksToSave).split("__form-data__");

        if (!data.length || data.length < 2) {
            localStorage.removeItem(tasksToSave);
            uploadDocuments(itemsSet);
        } else {
            $.post(data[0], data[1], function (result) {
                if (result.message) {
                    localStorage.removeItem(tasksToSave);
                    localStorage.removeItem(tasksToSave.replace("ATSD_", "ATS_"));
                }
            }).fail(function (xhr, textStatus, errorThrown) {
                invokeOnPageLoaded();
            });
        }
    }

    this.checkUnsavedItems = function () {
        if (!Modernizr.localstorage) return;

        var itemsToSave = [];
        for (var existsKey in localStorage) {
            if (/^(ATSD_)/.test(existsKey)) {
                itemsToSave.push(existsKey);
            }
        }
        uploadDocuments(itemsToSave);
    };

    this.addNewItem = function () {
        var $form = $('#itemForm');
        $form.each(function (index, form) {
            $(form)[0].reset();
        });

        $('table[data-aramis-name]').each(function (index, table) {
            $(table).find('tbody tr:not(tbody tr:last)').remove();
        });

        var $itemDiv = $('#itemDiv');
        if (WebConsts.DOCUMENT_TYPE_DESCRIPTOR === $itemDiv.attr('item-aramis-type')) {
            $('#Number').text('0');
        }

        var $idHiddenField = $('#' + WebConsts.ITEM_ID_NAME);
        $idHiddenField.val('0');
        $idHiddenField.removeAttr('data-cache-id');
        $('div.page-header small').text($itemDiv.attr('data-new-item-caption').replace(/\^/g, '"'));

        $form.find('select').each(function (index, item) {
            $(item).find('option').each(function (optIndex, optItem) {
                $(optItem).removeAttr('selected');
            });
        });

        _this.setFormChangedStatus(false);

        if (typeof (_this.onNewItemAdded) === 'function') {
            _this.onNewItemAdded();
        }
    }

    this.clearCache = function () {
        if (Modernizr.sessionstorage) {
            sessionStorage.clear();
        }

        if (Modernizr.localstorage) {
            localStorage.clear();
        }
    };

    this.Consts = {
        DESCRIPTION_ATTR_NAME: "data-value-description"
    };

    var addTableToDialog = function ($table, complateItemChoosingFunc) {
        $table.on('click', function (e) {
            var $sender = $(e.target);

            if ($sender.is("td")) {
                var $tr = $sender.parent();
                var itemId = $tr.attr(WebConsts.ID_ATTR_NAME);
                var itemDescription = $tr.attr(_this.Consts.DESCRIPTION_ATTR_NAME);
                if (itemDescription === undefined) {
                    var $theadRow = $tr.closest('table').find('thead tr');
                    var $th = $theadRow.find('th[data-field-name="Description"]');
                    if ($th.length) {
                        var columnIndex = $theadRow.find('th').index($th[0]);
                        var $tdWithDescription = $tr.find('td').eq(columnIndex);
                        itemDescription = $tdWithDescription.text();
                    }
                }
                complateItemChoosingFunc(itemId, itemDescription);
            }
        });

        var $modalContent = $('div.modalDialog > div');

        var caption = $table.find('thead').attr("data-caption");
        $modalContent.find('h2').text(caption);

        $modalContent.append($table);

        $table.dataTable(
        {
            paging: false,
            scrollY: ($(window).height() - 180) * 0.8,
            searching: false,
            sScrollX: "auto",
            autoWidth: false,
            info: false,
            ordering: true
        });

        var $modalDialog = $(".modalDialog > div");
        $modalDialog.css("top", ($(window).height() - $modalDialog.height() - 10) * 0.5);
    }

    var buildItemsListTable = function ($newTable, tableName, selectorName, currentId) {
        var cacheName = tableName + ":" + selectorName;
        var savedTable;
        if (Modernizr.sessionstorage) {
            savedTable = localStorage.getItem(cacheName);
        }
        if (savedTable != null) {
            $newTable.html(savedTable);
            $newTable.find('tr[' + WebConsts.ID_ATTR_NAME + '="' + currentId.toString() + '"]').addClass('success');
            addTableToDialog($newTable, _this.complateItemChoosing);
        } else {
            $.post(ClientConsts.GET_ITEMS_LIST_DATA_URL,
                JSON.stringify({ tableName: tableName, selectorName: selectorName }),
                function (tableData) {
                    _this.showItemsListInDialog($newTable, tableData, currentId, _this.complateItemChoosing, cacheName);
                });
        }
    }

    this.showItemsListInDialog = function ($newTable, tableData, currentId, complateItemChoosingFunc, cacheName) {
        _this.buildTable($newTable, tableData);
        $newTable.find('thead').attr("data-caption", tableData.caption);

        if (cacheName && Modernizr.sessionstorage) {
            localStorage.setItem(cacheName, $newTable.html());
        }

        $newTable.find('tr[' + WebConsts.ID_ATTR_NAME + '="' + currentId.toString() + '"]').addClass('success');
        addTableToDialog($newTable, complateItemChoosingFunc);
    }

    var numberInputOnChange = function (e) {
        var decimalPoints = 1 * $(this).attr(WebConsts.DECIMAL_POINTS_ATTR_NAME);
        this.value = parseFloat(parseFloat(this.value).toFixed(decimalPoints)).toString();
        _this.setFormChangedStatus(true);
    }

    var numberInputOnFocus = function (e) {
        if ($(this).val() === "0") {
            this.value = "";
        }
    }

    var numberInputOnBlur = function (e) {
        if ($(this).val() === "") {
            this.value = "0";
        }
    }

    this.setFormChangedStatus = function (isChanged) {
        var formChanged = isChanged !== false;
        $('form[' + WebConsts.ARAMIS_OBJECT_NAME + ']').attr("data-changed", formChanged);

        var saveButton = $("#saveButton");
        var savingLocally = saveButton.css("display") === "none";

        if (savingLocally) {
            saveButton = $('#saveLocallyButton');
        }

        saveButton.removeClass("btn-primary btn-warning btn-danger btn-success");
        saveButton.addClass(isChanged === "ERROR" ? "btn-danger" :
            (formChanged ? "btn-warning" :
            (savingLocally ? "btn-success" : "btn-primary")));
    }

    this.notifyObjectWriting = function (tableName) {
        if (_this.handleObjectWriting) {
            return _this.handleObjectWriting(tableName);
        }

        return true;
    }

    this.notifyValueChanged = function (propertyName) {
        if (_this.onValueChanged) {
            _this.onValueChanged(propertyName);
        }
    }

    this.addItemPropertyChangedListeners = function () {
        $('form select[id]').each(function (index, control) {
            $(control).change(function (e) {
                _this.notifyValueChanged($(e.target).attr("id"));
            });
        });

        $('form input[id]').each(function (index, control) {
            $(control).change(function (e) {
                _this.notifyValueChanged($(e.target).attr("id"));
            });
        });
    }

    this.notifyTableValueChanged = function ($td, _$table) {
        var $table = _$table ? _$table : $td.closest('table');
        var $th = getTableHeader($td, $table);

        if (_this.handleTableValueChanged) {
            var fieldName = $th.attr("data-field-name");
            var subtableName = $table.attr('id').substring(5, 100);
            var objectName = $table.attr(WebConsts.ARAMIS_OBJECT_NAME);

            _this.handleTableValueChanged(objectName, subtableName, fieldName, $td.parent(), $table);
        }

        if ($td.text() === "" && $th.attr("data-t") === WebConsts.NUMBER_TYPE_DESCRIPTOR) {
            $td.text("0");
        }
        _this.setFormChangedStatus(true);
    }

    this.allowToEditRowsSet = function () {
        var $targetTable = $("table.table").each(function (index, tableItem) {
            $(tableItem).on("swiperight", function (e) {
                e.stopImmediatePropagation();
                var $td = $(e.target);
                if ($td.is('TD')) {

                    var $table = $td.closest('table');
                    var $tr = $td.parent();
                    if ($tr.is(":last-child")) {
                        return;
                    }

                    if ($tr.hasClass('copy-row-mode')) {
                        _this.turnOffRowsSetEditMode($table);
                        return;
                    }

                    if (!($table).hasClass('edit-mode')) {
                        var $rows = $table.find('tbody tr');
                        var lastRowIndex = $rows.length - 1;
                        $rows.each(function (index, tr) {
                            if (index === lastRowIndex) return;

                            var $tr = $(tr);
                            $tr.find('td').eq(0).text(WebConsts.REMOVE_ROW_TEXT);
                        });
                        $table.addClass('edit-mode');
                    }

                    e.preventDefault();
                }
            });

            $(tableItem).on("swipeleft", function (e) {
                e.stopImmediatePropagation();
                var $target = $(e.target);
                var $table = $target.closest('table');

                if (($table).hasClass('edit-mode')) {
                    _this.turnOffRowsSetEditMode($table);
                    return;
                }

                if ($target.is('TD')) {
                    var $row = $target.parent();
                    if ($row.is(":last-child")) {
                        return;
                    }

                    if (!$row.hasClass('copy-row-mode')) {
                        if ($($row.children()[0]).text() === "") {
                            return;
                        }
                        _this.turnOffRowsSetEditMode($table);
                        $row.addClass('copy-row-mode');
                        $($row.children()[0]).text('Копировать');
                    }
                }
            });
        });
    }

    this.handleLineNumberClick = function ($td) {

        var $table = $td.closest('table');
        var $tr = $td.parent();

        if ($table.hasClass('edit-mode')) {
            $tr.remove();
            if ($table.find("tbody tr").length == 1) {
                _this.turnOffRowsSetEditMode($table);
            }

            var objectName = $table.attr('data-aramis-name');
            var subtableName = $table.attr('id').substr('table'.length);
            var bl = _this.handleTableValueChanged[objectName + "BL"];
            if (bl) {
                var tableChangedFunc = bl[subtableName + "RowDeleted"];
                if (tableChangedFunc && typeof (tableChangedFunc) === "function") {
                    tableChangedFunc($table, $tr);
                }
            }

        }
        else if ($tr.hasClass('copy-row-mode')) {
            _this.turnOffRowsSetEditMode($table);

            $tr.after($tr.clone());
            var $nextRow = $tr.next();
            while ($nextRow.length) {
                var $newRowLineNumberTd = $($nextRow.children()[0]);
                if ($newRowLineNumberTd.text() === "") break;
                $newRowLineNumberTd.text((parseInt($newRowLineNumberTd.text()) + 1).toString());

                $nextRow = $nextRow.next();
            }
            _this.notifyTableValueChanged($($tr.next().children()[0]));

            return;
        }
    }

    this.turnOffRowsSetEditMode = function ($table) {
        var $row = $('tr.copy-row-mode');
        if ($row.length) {
            $row.removeClass('copy-row-mode');
            var lineNumber = ($row.closest('tbody').find('tr').index($row[0]) + 1);
            $($row.children()[0]).text(lineNumber.toString());
        }

        if (!($table).hasClass('edit-mode')) return false;

        var $rows = $table.find('tbody tr');
        var lastRowIndex = $rows.length - 1;
        $rows.each(function (index, tr) {
            if (index === lastRowIndex) return;

            var $tr = $(tr);
            $tr.find('td').eq(0).text((1 + index).toString());
        });

        $table.removeClass('edit-mode');

        return true;
    }

    this.numberInputOnKeyDown = function (e) {
        if (e.keyCode == 189 // '-' (minus or hyphen)
            || e.keyCode == 188 // ',' (minus or hyphen)
            || e.keyCode == 190 // '.' (minus or hyphen)
            || e.keyCode == 46 || e.keyCode == 8 || e.keyCode == 9 || e.keyCode == 27 || e.keyCode == 13 ||

            // Allow: Ctrl+A
            (e.keyCode == 65 && e.ctrlKey === true) ||

            // Allow: Ctrl+X
            (e.keyCode == 88 && e.ctrlKey === true) ||

            // Allow: Ctrl+C
            (e.keyCode == 67 && e.ctrlKey === true) ||

            // Allow: Ctrl+V
            (e.keyCode == 86 && e.ctrlKey === true) ||

            // Allow: home, end, left, right
            (e.keyCode >= 35 && e.keyCode <= 39)) {
            // let it happen, don't do anything
            return;
        } else {
            // Ensure that it is a number and stop the keypress
            if (e.shiftKey || (e.keyCode < 48 || e.keyCode > 57) && (e.keyCode < 96 || e.keyCode > 105)) {
                e.preventDefault();
            }
        }
    }

    this.unbindNumberInput = function ($input) {
        $input.unbind("change", numberInputOnChange);

        $input.unbind("focus", numberInputOnFocus);

        $input.unbind("blur", numberInputOnBlur);

        //called when key is down
        $input.unbind("keydown", numberInputOnKeyDown);
    }

    this.bindNumberInput = function ($input) {
        $input.bind("change", numberInputOnChange);

        $input.bind("focus", numberInputOnFocus);

        $input.bind("blur", numberInputOnBlur);

        //called when key is down
        $input.bind("keydown", _this.numberInputOnKeyDown);
    }

    this.bindTextInput = function ($input) {
        $input.bind("keydown", function (e) {
            _this.setFormChangedStatus(true);
        });
    }

    this.bindSelect = function ($select) {
        $select.bind("change", function (e) {
            _this.setFormChangedStatus(true);
        });
    }

    this.bindDateInput = function ($input) {
        $input.bind("change", function (e) {
            _this.setFormChangedStatus(true);
        });
    }

    this.bindCheckboxInput = function ($input) {
        $input.bind("change", function (e) {
            _this.setFormChangedStatus(true);
        });
    }

    this.closeModalWindow = function () {
        $('div.modalDialog').removeClass("modalVisible");
        var targetItem = $("[data-current-item='true']").removeAttr("data-current-item");
        $("#page").removeClass("blured");
        $("body").removeClass("noScroll");
    }

    var last = "";
    this.chooseCatalog = function (tableInfo, currentId, selectorName, element, complateItemChoosingFunc) {
        var $modalWindow = $('div.modalDialog').empty();

        var idd = tableInfo + ":" + selectorName;
        if (idd === last) {
            console.log(last);
        }
        last = idd;
        var $modalContent = $('<div>').appendTo($modalWindow);

        $modalContent.append($('<button>').text("X").addClass("closeModal").on('click', _this.closeModalWindow));

        $modalContent.append($('<h2>'));

        var $newTable = $('<table>').addClass("table display table-bordered table-striped modal-window table-hover");

        if (typeof tableInfo === "string") {
            buildItemsListTable($newTable, tableInfo, selectorName, currentId);
        } else {
            _this.showItemsListInDialog($newTable, tableInfo, currentId, complateItemChoosingFunc, "");
        }

        $modalWindow.prependTo('body');

        $modalWindow.addClass("modalVisible");

        $(element).attr("data-current-item", "true");

        $("#page").addClass("blured");
        $("body").addClass("noScroll");
    }

    this.onEditStart = function ($elem) {
        if (!$elem || !($elem instanceof $) || !$elem.length) return;

        var $tr = $elem.closest('tr');
        var firstCell = $tr.find('td:first');
        if (!firstCell.length) return;

        var text = firstCell.text();
        if (!text) {
            text = "0";
        }
        var lineNumber = parseFloat(text);
        if (isNaN(lineNumber)) return;

        _this.lastLineNumber = lineNumber;

        if (_this.handleOnEditStart && $elem.is('TD')) {
            var $table = $elem.closest('table');
            var tableId = $table.attr('id');
            if (tableId) {
                tableId = tableId.substr('table'.length);
            }
            var $th = getTableHeader($elem, $table);
            _this.handleOnEditStart(tableId, $tr, $th.attr("data-field-name"));
        }
    }

    this.lastLineNumber = 0;

    this.complateSavedItemChoosing = function (id, description) {
        var $idControl = $('#' + WebConsts.ITEM_ID_NAME);
        var itemId = $idControl.attr('data-cache-id');
        if (itemId === id) return;

        var tableName = $("#itemForm").attr(WebConsts.ARAMIS_OBJECT_NAME);
        var formHtmlKey = "ATS_" + tableName + "_" + id;
        var data = localStorage.getItem(formHtmlKey).split("|||$|||");

        var capFieldsValues = data[1].split('$?$');
        for (var i = 0; i < capFieldsValues.length; i++) {
            capFields[i].restoreValue(capFieldsValues[i]);
        }
        $('#' + WebConsts.ITEM_ID_NAME).attr('data-cache-id', id);

        $("#subtables").html(data[2]);

        $("#subtables").find('table[data-aramis-name]').each(function (ind, table) {
            $(table).editableTableWidget(undefined, _this.chooseCatalog, _this.onEditStart);
        });

        _this.closeModalWindow();
    }

    this.complateItemChoosing = function (id, description) {
        var $targetItem = $("[data-current-item='true']");

        if ($targetItem.length) {
            if ($targetItem.is('td')) {
                $targetItem.text(description);
                $targetItem.attr(WebConsts.ID_ATTR_NAME, id.toString());

                var $tr = $targetItem.parent();
                var $lineNumberTd = $tr.children().eq(0);

                // is a new row?
                if ($lineNumberTd.text().length === 0) {
                    var $tbody = $tr.closest('tbody');
                    $lineNumberTd.text($tbody.find('tr').length.toString());
                    var $table = $tbody.closest('table');
                    $tbody.append(_this.addNewRow($table));
                }

                _this.notifyTableValueChanged($targetItem);
            }
        }
        _this.closeModalWindow();
    }

    var getTableHeader = function ($td, $table) {
        if (!$table) {
            $table = $td.closest();
        }

        var columnIndex = $td.parent().find('td').index($td[0]);
        return $table ?
            $table.find("tr th").eq(columnIndex) :
            $td.closest('table').find("tr th").eq(columnIndex);
    }

    this.buildTable = function ($table, table) {
        var tableData = table.data;
        var isReadOnly = table.readOnly === true;
        if (isReadOnly) {
            $table.attr("data-read-only", isReadOnly);
        } else {
            $table.removeAttr("data-read-only");
        }
        $table.empty();

        var columnsCount = tableData.length;

        var $headRow = jq('<tr>');

        for (var columnIndex = -1; columnIndex < columnsCount; columnIndex++) {
            var columnHeader = tableData[columnIndex];
            if (columnHeader && (columnHeader.fieldName === "Id" || columnHeader.fieldName === "MarkForDeleting")) {
                continue;
            }

            var $th = jq("<th>");
            $th.text(columnIndex !== -1 ? columnHeader.description : "№");

            var isLineNumberColumn = columnIndex === -1;
            if (!isLineNumberColumn) {
                $th.attr("data-field-name", columnHeader.fieldName);
                if (columnHeader.typeDescriptor) {
                    $th.attr("data-t", columnHeader.typeDescriptor);
                }
                if (columnHeader.isReadonly) {
                    $th.attr("data-readonly", "1");
                }
                if (columnHeader.tableName) {
                    $th.attr("data-table-name", columnHeader.tableName);
                }
                if (columnHeader.dataAttr) {
                    var attrArray = columnHeader.dataAttr.split("^");
                    for (var attrIndex = 0; attrIndex < attrArray.length; attrIndex++) {
                        var kvp = attrArray[attrIndex].split("=");
                        if (kvp.length === 2 && kvp[0].length) {
                            $th.attr(kvp[0], kvp[1]);
                        }
                    }
                    $th.attr("data-table-name", columnHeader.tableName);
                }
            } else {
                $th.attr("data-readonly", "1");
            }

            $headRow.append($th);
        }

        var rowCount = tableData[0].valuesDescriptions.length;
        var $body = jq("<tbody>");

        for (var rowIndex = 0; rowIndex < rowCount; rowIndex++) {
            var $tr = jq('<tr class="info">');

            var $tdLineNumber = jq("<td>");
            $tdLineNumber.text((rowIndex + 1));
            $tr.append($tdLineNumber);

            for (columnIndex = 0; columnIndex < columnsCount; columnIndex++) {
                var column = tableData[columnIndex];
                if (column.fieldName === "Id") {
                    $tr.attr(WebConsts.ID_ATTR_NAME, column.valuesDescriptions[rowIndex].toString());
                    continue;
                }
                else if (column.fieldName === "MarkForDeleting") {
                    if (parseFloat(column.valuesDescriptions[rowIndex])) {
                        $tr.addClass('marked-for-deleting');
                    }
                    continue;
                }

                var $td = jq("<td>");

                if (column.typeDescriptor === WebConsts.BOOL_TYPE_DESCRIPTOR) {
                    var $checkBox = jq("<input>");
                    $checkBox.attr('type', 'checkbox');
                    if (column.valuesDescriptions[rowIndex] === "1") {
                        $checkBox.attr('checked', '1');
                    }
                    if (table.readOnly) {
                        $checkBox.on("click", function (e) {
                            $(this).closest('td').trigger('click');
                            return false;
                        });
                    }
                    $td.append($checkBox);
                }
                else {
                    var description = column.valuesDescriptions[rowIndex];
                    if (column.typeDescriptor === WebConsts.CATALOG_TYPE_DESCRIPTOR) {
                        $td.attr(WebConsts.ID_ATTR_NAME, column.values[rowIndex].toString());
                    } else if (column.typeDescriptor === WebConsts.NUMBER_TYPE_DESCRIPTOR) {
                        $td.addClass("num");
                        description = $.toStringForView(description);
                    } else if (column.typeDescriptor === WebConsts.ID_TYPE_DESCRIPTOR) {
                        var rowIdStr = column.values[rowIndex].toString();
                        $tr.attr(WebConsts.ID_ATTR_NAME, rowIdStr);
                        $tr.attr(_this.Consts.DESCRIPTION_ATTR_NAME, description);
                    }

                    $td.text(description);
                }

                $tr.append($td);
            }

            $body.append($tr);
        }

        var $head = jq("<thead>");
        $head.append($headRow);

        $table.append($head);
        $table.append($body);
    }

    this.handleOpenItemFromListClick = function (e) {
        $tr = $(e.target).parent();
        if (!$tr.is('tr')) return;

        var aramisItemName = $tr.closest('table').attr(WebConsts.ARAMIS_OBJECT_NAME).replace(/ItemsList$/, "");
        var id = $tr.attr(WebConsts.ID_ATTR_NAME);
        var newURL = "/ItemView/" + aramisItemName + "/" + id;

        $(location).attr('href', newURL);
    }

    this.toggleMarkForDeleting = function (e) {
        var $table = $("#listTable");

        var markForDeleting = function (e) {
            $tr = $(e.target).parent();
            if (!$tr.is('tr')) return;

            var id = $tr.attr(WebConsts.ID_ATTR_NAME);
            var tableName = $table.attr(WebConsts.ARAMIS_OBJECT_NAME);
            jQuery.post(ClientConsts.TOGGLE_MARK_FOR_DELETION,
                JSON.stringify({ tableName: tableName, id: id }),
                function (result) {
                    if (result.success) {
                        $tr.toggleClass('marked-for-deleting');
                    }
                });
        };

        var button = $('button[data-remove-item-button]');
        var activeState = button.hasClass('btn-danger');

        if (activeState) {
            button.addClass('btn-primary');
            button.removeClass('btn-danger');
            $table.bind('click', _this.handleOpenItemFromListClick);
            $table.unbind('click', markForDeleting);
        } else {
            button.addClass('btn-danger');
            button.removeClass('btn-primary');
            $table.unbind('click', _this.handleOpenItemFromListClick);
            $table.bind('click', markForDeleting);
        }
    }

    var handleOnTableRetrieved = function (tableId, $table) {
        if (_this.onTableRetrieved) {
            _this.onTableRetrieved(tableId, $table);
        }
    }

    this.loadTable = function (tableId, getTableUrl) {

        var $tableInput = $('#' + tableId);
        var tableParameters = $tableInput.attr("table-parameters");
        if (tableParameters) {
            getTableUrl += "/" + tableParameters;
        }

        jq.post(getTableUrl, function (data) {
            if (data.isError === false) {
                var $table = jq("#table" + tableId);

                _this.buildTable($table, data);
                $tableInput.removeAttr('disabled');

                if (!data.readOnly) {
                    $table.find('tbody').append(_this.addNewRow($table));
                    $table.editableTableWidget(undefined, _this.chooseCatalog, _this.onEditStart);
                    handleOnTableRetrieved(tableId, $table);
                } else {
                    var allowOpenItem = $table.find('tr[' + WebConsts.ID_ATTR_NAME + ']').length > 0;
                    if (allowOpenItem) {
                        $table.bind('click', handleOpenItemFromListClick);
                    }
                }
            }
        });
    }

    var mainFields = null;
    var capFields = null;

    var initMainFields = function () {

        var getFieldInfo = function ($item) {
            var fieldName = $item.attr("id");
            var fieldDescription = $item.closest('div.form-group').find('label').text();
            var getValueFunc = null;
            var restoreValueFunc = null;
            var dataType = "";

            var isIdField = fieldName === WebConsts.ITEM_ID_NAME;
            if (isIdField) {
                fieldDescription = "Id";
                getValueFunc = function ($bindedControl) {
                    return $bindedControl.val();
                };
                restoreValueFunc = function ($bindedControl, value) {
                    $bindedControl.attr('value', value);
                };

            } else {
                restoreValueFunc = function ($bindedControl, value) {
                    $bindedControl.val(value);
                };

                if ($item.is('select')) {
                    dataType = $item.attr('data-type');
                    getValueFunc = function ($bindedControl) {
                        return $bindedControl.find(":selected");
                    }
                } else if ($item.is('input[type=checkbox]')) {
                    dataType = WebConsts.BOOL_TYPE_DESCRIPTOR;
                    getValueFunc = function ($bindedControl) {
                        return $bindedControl.is(":checked");
                    }
                    restoreValueFunc = function ($bindedControl, value) {
                        /*$bindedControl.removeAttr('checked');
                        if (value === 1) {
                            
                        }*/
                        $bindedControl.prop('checked', value === "1");
                    };
                } else if ($item.is('input[type=number]')) {
                    dataType = WebConsts.NUMBER_TYPE_DESCRIPTOR;
                    getValueFunc = function ($bindedControl) {
                        return $bindedControl.val();
                    }
                } else if ($item.is('input[type=date]')) {
                    dataType = WebConsts.DATETIME_TYPE_DESCRIPTOR;
                    getValueFunc = function ($bindedControl) {
                        return $bindedControl.val();
                    }
                } else if ($item.is('input[type=text]')) {
                    getValueFunc = function ($bindedControl) {
                        return $bindedControl.val();
                    }
                }
            }

            if (!fieldName || !fieldDescription || !getValueFunc || !restoreValueFunc) {
                return null;
            }

            var FieldInfo = function (fieldNameValue, fieldDescriptionValue, dataTypeValue, getControlValueFunc, restoreControlValueFunc) {

                var _this = this;

                this.type = dataTypeValue;
                this.name = fieldNameValue;
                this.description = fieldDescriptionValue;
                this.restoreValue = function (val) {
                    restoreControlValue($('#' + _this.name), val.toString());
                };

                var getControlValue = getControlValueFunc;
                var restoreControlValue = restoreControlValueFunc;

                this.getValue = function () {
                    if (getControlValue) {
                        return getControlValue($('#' + _this.name));
                    }
                    return null;
                }

                this.getStringValue = function () {
                    var val = _this.getValue();
                    if ($(val).is('option')) {
                        return val.text();
                    }
                    if (_this.type === WebConsts.BOOL_TYPE_DESCRIPTOR) {
                        return val ? "1" : "0";
                    }

                    return val.toString();
                }

                this.getValueForStoring = function () {
                    var val = _this.getValue();
                    if (_this.type === WebConsts.BOOL_TYPE_DESCRIPTOR) {
                        return val ? "1" : "0";
                    }

                    if ($(val).is('option')) {
                        return val.val();
                    }

                    return val.toString();
                }

            };

            return new FieldInfo(fieldName, fieldDescription, dataType, getValueFunc, restoreValueFunc);
        }

        var $itemForm = $("#itemForm");

        var mainProperties = [];
        capFields = [];

        $itemForm.find('[id]').each(function (index, item) {
            var $item = $(item);
            if ($item.is('[data-main-field-index]')) {
                mainProperties.push($item);
            }
            var capFieldInfo = getFieldInfo($item);
            if (capFieldInfo) {
                capFields.push(capFieldInfo);
            }
        });

        function compare(a, b) {
            var aIndex = Number(a.attr('data-main-field-index'));
            var bIndex = Number(b.attr('data-main-field-index'));

            if (aIndex < bIndex)
                return -1;
            if (aIndex > bIndex)
                return 1;
            return 0;
        }
        mainProperties.sort(compare);

        mainFields = [];
        for (var i = 0; i < mainProperties.length; i++) {
            var newFieldInfo = getFieldInfo(mainProperties[i]);
            if (newFieldInfo) {
                mainFields.push(newFieldInfo);
            }
        }
    }

    var getMainFieldsPrefix = function () {
        if (!mainFields) {
            initMainFields();
        }

        var result = "";
        for (var i = 0; i < mainFields.length; i++) {
            var fieldValue = mainFields[i].getStringValue();
            if (!fieldValue) {
                fieldValue = " ";
            }
            result += ((result) ? "$?$" : "") + fieldValue;
        }
        return result;
    }

    var getCapFieldsValues = function () {
        if (!mainFields) {
            initMainFields();
        }

        var result = "";
        for (var i = 0; i < capFields.length; i++) {
            var fieldValue = capFields[i].getValueForStoring();
            if (!fieldValue) {
                fieldValue = " ";
            }
            result += ((result) ? "$?$" : "") + fieldValue;
        }
        return result;
    }

    this.tryToSaveLocally = function ($saveButton) {
        if (!Modernizr.localstorage) {
            $saveButton.addClass("btn-danger");
            return;
        }

        $('#cancelButton').hide();
        var $itemForm = $("#itemForm");
        var tableName = $itemForm.attr(WebConsts.ARAMIS_OBJECT_NAME);

        var $idControl = $('#' + WebConsts.ITEM_ID_NAME);
        var itemId = $idControl.attr('data-cache-id');
        if (!itemId) {
            itemId = new Date().getTime().toString();
            $idControl.attr('data-cache-id', itemId);
        }

        $("[data-table-id]").each(function (i, item) {
            var $item = $(item);
            $item.attr("value", $A.serializeTable($item.attr("data-table-id")));
        });

        var formDataKey = "ATSD_" + tableName + "_" + itemId; // Aramis Task-Save Data
        var formData = $itemForm.serialize();
        var saveUrl = $itemForm.attr('action');

        localStorage.setItem(formDataKey, saveUrl + "__form-data__" + formData);

        var formHtmlKey = "ATS_" + tableName + "_" + itemId;
        var subtables = $("#subtables").html();
        var complexFormData = getMainFieldsPrefix() + "|||$|||" + getCapFieldsValues() + "|||$|||" + subtables;
        localStorage.setItem(formHtmlKey, complexFormData);

        if (localStorage.getItem(formHtmlKey) === complexFormData) {
            _this.setFormChangedStatus(false);
            $('#myNavbar').addClass('off-line-mode');
        } else {
            $saveButton.addClass("btn-danger");
        }
    }

    this.addNewRow = function ($table) {
        var $newRow = $('<tr>');

        $thCollection = $table.find('tr th');
        $newRow.append('<td>');
        for (var columnIndex = 1; columnIndex < $thCollection.length; columnIndex++) {
            var $td = $('<td>');
            var $columnHeader = $thCollection.eq(columnIndex);
            var typeDescription = $columnHeader.attr('data-t');
            if (typeDescription) {
                if (typeDescription === WebConsts.CATALOG_TYPE_DESCRIPTOR) {
                    $td.attr(WebConsts.ID_ATTR_NAME, '0');
                } else if (typeDescription === WebConsts.NUMBER_TYPE_DESCRIPTOR) {
                    $td.addClass('num');
                    $td.text('0');
                } else if (typeDescription === WebConsts.BOOL_TYPE_DESCRIPTOR) {
                    $('<input>').attr('type', 'checkbox').appendTo($td);
                }
            }
            $newRow.append($td);
        }
        return $newRow;
    }

    this.serializeTable = function (tableId) {
        var $table = jq("#" + tableId);

        var $columns = $table.find("th[data-field-name]");
        var result = new Object();
        var fieldsNames = [WebConsts.LINE_NUMBER_FIELD_NAME];
        var fieldsTypes = [WebConsts.NUMBER_TYPE_DESCRIPTOR];
        result[fieldsNames[0]] = [];
        $columns.each(function (index, item) {
            var fieldName = jq(item).data("field-name");
            fieldsNames.push(fieldName);
            result[fieldName] = [];
            fieldsTypes.push(jq(item).data("t"));
        });

        var $rows = $table.find("tbody tr");
        var rowsCount = $rows.length + ($table.attr("data-read-only") ? 0 : -1);

        for (var rowIndex = 0; rowIndex < rowsCount; rowIndex++) {
            var $tds = jq($rows[rowIndex]).find("td");

            for (var columnIndex = 0; columnIndex < $tds.length; columnIndex++) {
                var $td = jq($tds[columnIndex]);
                var attrValue = $td.attr(WebConsts.ID_ATTR_NAME);
                var tdValue;
                if (fieldsTypes[columnIndex] === WebConsts.NUMBER_TYPE_DESCRIPTOR) {
                    tdValue = $.toNumber($td.text()).toString();
                } else if (fieldsTypes[columnIndex] === WebConsts.BOOL_TYPE_DESCRIPTOR) {
                    tdValue = $td.children().eq(0).prop("checked") ? "1" : "0";
                } else {
                    tdValue = attrValue == undefined ? $td.text() : attrValue;

                    if (columnIndex === 0 && tdValue === WebConsts.REMOVE_ROW_TEXT) { // lineNumber
                        tdValue = (rowIndex + 1).toString();
                    }
                }
                result[fieldsNames[columnIndex]].push(tdValue);
            }
        }

        return JSON.stringify(result);
    }

    this.saveItem = function (saveLocally) {
        $A.turnOffRowsSetEditMode($('table[' + WebConsts.ARAMIS_OBJECT_NAME + ']'));

        var $button = $(this);
        $button.prop("disabled", true);
        var saveLocallyButton = $('#saveLocallyButton');
        saveLocallyButton.css('display', 'inline-block');

        var $itemForm = $("#itemForm");
        var tableName = $itemForm.attr(WebConsts.ARAMIS_OBJECT_NAME);
        $A.notifyObjectWriting(tableName);

        $("[data-table-id]").each(function (index, item) {
            var $item = $(item);
            if (!$item.is('[disabled]')) {
                $item.attr("value", $A.serializeTable($item.attr("data-table-id")));
            }
        });

        var formData = $itemForm.serialize();

        if (saveLocally === true) {
            var saveButton = $("#saveButton");
            if (saveButton.css("display") !== "none") {
                saveLocallyButton.remove();
                saveButton.css("display", "none")
                    .after(saveLocallyButton);

                saveLocallyButton.on('click', function () {
                    _this.saveItem(true);
                });
            }

            $A.tryToSaveLocally($button);
            $button.prop("disabled", false);
            return;
        }

        $.post($itemForm.attr("action"), formData, function (result) {
            var itemId = 1 * result.message;
            $('#' + WebConsts.ITEM_ID_NAME).val(itemId.toString());
            $A.setFormChangedStatus(itemId === 0);
        }).error(function () {
            $A.saveItem(true);
        }).always(function () {
            $button.prop("disabled", false);
            if ($button.css("display") !== "none") {
                saveLocallyButton.css('display', 'none');
            }
        });
    }

    this.updateReportFunction = function () {
        var $form = $('#ReportFilters');
        var $button = $('#buildReportButton');
        $button.prop("disabled", true);

        var $adaptersSelectControl = $('#reportAdaptersSelect');
        if ($adaptersSelectControl.length) {
            $('#' + WebConsts.REPORT_ADAPTER_ID_PARAMETER).attr("value", $adaptersSelectControl.val());
        }

        var formData = $form.serialize();

        $.post($form.attr("action"), formData, function (result) {

            // add html
            var $container = $('#matrixReportData');
            $container.empty();
            $container.html(result.html);

            // remove old styles
            $('#matrixReportStyle').remove();

            // add new css
            $('head').prepend($('<style>')
                .attr("type", "text/css")
                .attr("id", "matrixReportStyle")
                .text(result.css));

            bindReportTables();

            $button.prop("disabled", false);
        });
    };

    var bindReportTables = function () {
        function changeIconOfAllRowsInCollapsibleGroup($originalRow, $leftFixedRow, src) {
            var rows = findAllRowsInCollapsibleGroup($originalRow);

            for (var i = 0; i < rows.length; i++) {
                rows[i].find('.expand-collapse').attr('src', src);
            }

            if ($leftFixedRow != null) {
                rows = findAllRowsInCollapsibleGroup($leftFixedRow);

                for (var i = 0; i < rows.length; i++) {
                    rows[i].find('.expand-collapse').attr('src', src);
                }
            }
        }

        function findAllRowsInCollapsibleGroup($row) {
            var rows = [];

            // current one
            rows.push($row);

            var skipRowsQuantity = 0;
            if (typeof $row.attr('data-mt-collapsible-rows-skip') != 'undefined') {
                skipRowsQuantity = parseInt($row.attr('data-mt-collapsible-rows-skip'), 10);
            };

            // previous rows
            var prevRow = $row.prev();
            while (parseInt(prevRow.attr('data-mt-collapsible-rows-skip'), 10) > 0) {
                rows.push(prevRow);
                prevRow = prevRow.prev();
            }

            // next rows
            if (skipRowsQuantity > 0) {
                var nextRow = $row.next();
                while (parseInt(nextRow.attr('data-mt-collapsible-rows-skip'), 10) > 0) {
                    rows.push(nextRow);
                    nextRow = nextRow.next();
                }
            }

            return rows;
        }

        function getScrollBarWidth() {
            if (!this.isScrollbarElementsCreated) {
                var inner = document.createElement('p');
                inner.style.width = "100%";
                inner.style.height = "200px";

                var outer = document.createElement('div');
                outer.style.position = "absolute";
                outer.style.top = "0px";
                outer.style.left = "0px";
                outer.style.visibility = "hidden";
                outer.style.width = "200px";
                outer.style.height = "150px";
                outer.style.overflow = "hidden";

                outer.appendChild(inner);
                document.body.appendChild(outer);

                var w1 = inner.offsetWidth;
                outer.style.overflow = 'scroll';
                var w2 = inner.offsetWidth;
                if (w1 == w2) w2 = outer.clientWidth;

                this.isScrollbarElementsCreated = true;
                this.scrollbarWidth = w1 - w2;

                document.body.removeChild(outer);
            }

            return this.scrollbarWidth;
        }

        $('table[data-mt-enabled="1"]').each(function () {
            var table = $(this);

            var allowResizeColumns = false;
            var freezeHeader;
            var scrollableBodyWidth;
            var scrollableBodyHeight;
            var quantityOfLeftFixedColumns = 0;

            //if (typeof table.data('mt-allowcolumnresize') != 'undefined' && table.data('mt-allowcolumnresize') == '1') {
            //    allowResizeColumns = true;
            //} else {
            //    allowResizeColumns = false;
            //}

            if (typeof table.data('mt-freezeheader') != 'undefined' && table.data('mt-freezeheader') == '1') {
                freezeHeader = true;
            } else {
                freezeHeader = false;
            }

            if (typeof table.data('mt-scrollablebodywidth') != 'undefined') {
                scrollableBodyWidth = table.data('mt-scrollablebodywidth');
            } else {
                scrollableBodyWidth = table.parent().width() + getScrollBarWidth();
            }

            if (typeof table.data('mt-scrollablebodyheight') != 'undefined') {
                scrollableBodyHeight = table.data('mt-scrollablebodyheight');
            } else {
                scrollableBodyHeight = $(window).height() - 200;
            }

            if (typeof table.data('mt-quantityofleftfixedcolumns') != 'undefined') {
                quantityOfLeftFixedColumns = table.data('mt-quantityofleftfixedcolumns');
            }

            table.mainTable({
                allowResizeColumns: allowResizeColumns,
                freezeHeader: freezeHeader,
                scrollableBodyWidth: scrollableBodyWidth,
                scrollableBodyHeight: scrollableBodyHeight,
                quantityOfLeftFixedColumns: quantityOfLeftFixedColumns,
                onRowsExpanded: function (args) {
                    changeIconOfAllRowsInCollapsibleGroup(args.rows.original, args.rows.leftFixed, '/Content/Images/ToCollapse.png');
                },
                onRowsCollapsed: function (args) {
                    changeIconOfAllRowsInCollapsibleGroup(args.rows.original, args.rows.leftFixed, '/Content/Images/ToExpand.png');
                }
            });

        });
    }

    this.refreshItemsList = function () {
        var startDateControl = $('#StartDate');

        var dateValueRaw = startDateControl.val();
        if (!dateValueRaw) {
            dateValueRaw = "0001-01-01";
        }

        var url = startDateControl.attr('data-url') + "/" + dateValueRaw;
        $(location).attr('href', url);
    }

    this.saveDocumentsListSettings = function (e) {
        e.preventDefault();

        var $a = $(this);

        var periodType = $a.attr('data-period-type');
        if (!periodType) return;

        var daysCount = $a.attr('data-days-count');
        if (!daysCount) {
            daysCount = 0;
        }

        var url = $a.closest('ul').attr('data-url');

        $.post(url,
               JSON.stringify({ DaysCount: daysCount.toString(), IntervalType: periodType }),
               function (data) {
                   if (data.result == true) {
                       $(location).attr('href', $('#StartDate').attr('data-url'));
                   }
               });
    }
}

$A = new Aramis(jQuery);

$(document).ready(function () {

    $A.updateButtons();

    $A.checkUnsavedItems();

    var $itemForm = $("#itemForm");

    if ($itemForm.length) {
        $('#saveLocallyButton').on('click', function () {
            $A.saveItem(true);
        });

        $("#saveButton").on('click', $A.saveItem);

        $('#showItemsList').on('click', function () {
            var $form = $('form[data-aramis-name]');
            var savedItems = $A.getSavedLocalyItems($form.attr('data-aramis-name'));
            if (!savedItems) {
                window.location.href = $(this).attr('data-action');
            }

            savedItems.caption = $form.attr('data-item-description').replace(/\^/g, '"');

            var currentId = $('#' + WebConsts.ITEM_ID_NAME).attr('data-cache-id') || "0";
            $A.chooseCatalog(savedItems, currentId, "", null, $A.complateSavedItemChoosing);
        });

        $('#addNewItem').on('click', $A.addNewItem);

        $("#cancelButton").on('click', function (e) {
            $itemForm.removeAttr("data-changed");
            history.back();
        });
    }

    $('a[data-table-id]').on('click', function (e) {
        e.preventDefault();
        e.stopPropagation();

        var self = $(this);
        var tableId = self.attr('data-table-id');

        var getTableUrl = self.attr('data-get-url');
        if (getTableUrl) {
            var tableWasFilled = $('#' + tableId).find('thead').length > 0;
            if (tableWasFilled) {
                self.removeAttr('data-get-url');
            } else {
                $A.loadTable(self.attr('data-table-name'), getTableUrl);
            }
        }

        var $ulRoot = self.closest("ul.nav-tabs");
        $ulRoot.find("li.active").removeClass("active");
        self.closest("li").addClass("active");

        $ulRoot.next().find("div.active").removeClass("in").removeClass("active");
        $('#div' + tableId).addClass("in").addClass("active");
    });

    $('a[data-download-type]').on('click', function (e) {
        e.preventDefault();
        e.stopPropagation();

        var self = $(this);
        var baseUrl = self.attr('href');
        if (/^.?(PrintForm)/.test(baseUrl)) {
            baseUrl += $('#' + WebConsts.ITEM_ID_NAME).val();
        }

        var url = baseUrl + '?' + self.closest('form').find(':input').not('[name="__RequestVerificationToken"]').serialize();
        var newWindow = window.open(url, '_blank');
        newWindow.print();
    });

    $A.bindNumberInput($('form input[type="number"]'));
    $A.bindCheckboxInput($('form input[type="checkbox"]'));
    $A.bindTextInput($('form input[type="text"]'));
    $A.bindDateInput($('form input[type="date"]'));

    $A.bindSelect($("form select"));

    //$(window).on('beforeunload', function () {
    //    if ($('form[data-changed="true"]').length) {
    //        return 'Вы не сохранили выполненные изменения.';
    //    }
    //});
});


