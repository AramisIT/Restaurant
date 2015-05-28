/*global $, window*/
$.fn.editableTableWidget = function (options, onDBObjectEdit, onEditStart) {
    'use strict';

    return $(this).each(function () {
        var buildDefaultOptions = function () {
            var opts = $.extend({}, $.fn.editableTableWidget.defaultOptions);
            opts.editor = opts.editor.clone();
            return opts;
        },
			activeOptions = $.extend(buildDefaultOptions(), options),
			ARROW_LEFT = 37, ARROW_UP = 38, ARROW_RIGHT = 39, ARROW_DOWN = 40, ENTER = 13, ESC = 27, TAB = 9,
			element = $(this),
			editor = activeOptions.editor.css('position', 'absolute').hide().appendTo(element.parent()),
			active,
            isNumber,
			showEditor = function (param) {
			    active = element.find('td:focus');
			    isNumber = false;
			    var $target = (param.target != undefined) ? $(param.target) : undefined;
			    if (!active.length && $target.length && $target.is('td')) {
			        active = $target;
			    }

			    if ($target && $target.is('input[type="checkbox"]')) {
			        $A.turnOffRowsSetEditMode($target.closest('table'));
			        $A.notifyTableValueChanged($target.closest("td"));
			        if (onEditStart) onEditStart(active);

			    } else if (active.length) {
			        var columnIndex = active.parent().find('td').index(active[0]);
			        var columnType = "str";
			        var $columnHeader;
			        if (onEditStart) onEditStart(active);

			        if (columnIndex >= 0) {
			            if (columnIndex === 0) {
			                $A.handleLineNumberClick(active);
			                param.stopImmediatePropagation();
			                return;
			            }

			            if ($A.turnOffRowsSetEditMode(active.closest('table'))) return;

			            $columnHeader = active.closest('table').find("tr th").eq(columnIndex);
			            if ($columnHeader.data('readonly') !== undefined) return;

			            var type = $columnHeader.data("t");
			            if (type != undefined) {
			                columnType = type;
			            }

			            if (columnType === WebConsts.BOOL_TYPE_DESCRIPTOR) return;

			            if (columnType === WebConsts.CATALOG_TYPE_DESCRIPTOR) {
			                if (onDBObjectEdit !== undefined) {
			                    var selectorName = $columnHeader.attr(WebConsts.SELECTOR_NAME_ATTR);
			                    onDBObjectEdit($columnHeader.data('table-name'), active.attr(WebConsts.ID_ATTR_NAME),
			                        selectorName, active[0]);
			                }
			                return;
			            }
			        } else {
			            $columnHeader = active.closest('table').find("tr th").first();
			        }

			        editor.attr("type", (columnType === WebConsts.NUMBER_TYPE_DESCRIPTOR) ? "number" : "text");

			        var activeText = active.text();

			        if (columnType === WebConsts.NUMBER_TYPE_DESCRIPTOR) {
			            isNumber = true;
			            activeText = $.toNumber(activeText).toString();
			            editor.attr('step', $columnHeader.attr("step"));
			            editor.attr(WebConsts.DECIMAL_POINTS_ATTR_NAME, $columnHeader.attr(WebConsts.DECIMAL_POINTS_ATTR_NAME));
			            if (activeText === "0") {
			                activeText = "";
			            }
			        }

			        editor.val(activeText)
			            .removeClass('error')
			            .show()
			            .offset(active.offset())
			            .css(active.css(activeOptions.cloneProperties))
			            .width(active.width())
			            .height(active.height())
			            .focus();

			        if (param.constructor === Boolean && param) {
			            editor.param();
			        }

			        if (columnType === WebConsts.NUMBER_TYPE_DESCRIPTOR) {
			            $A.bindNumberInput(editor);
			        }
			    }
			},
			setActiveText = function () {
			    var text = editor.val(),
					evt = $.Event('change'),
					originalContent;
			    if (active.text() === text || editor.hasClass('error')) {
			        return true;
			    }
			    originalContent = active.html();
			    active.text(isNumber ? $.toStringForView(text) : text).trigger(evt, text);
			    if (evt.result === false) {
			        active.html(originalContent);
			    } else {
			        var checkResult = $A.notifyTableValueChanged(active);
			        if (checkResult instanceof String) {
			            active.text(checkResult);
			        }
			    }
			},
			movement = function (element, keycode) {
			    if (keycode === ARROW_RIGHT) {
			        return element.next('td');
			    } else if (keycode === ARROW_LEFT) {
			        return element.prev('td');
			    } else if (keycode === ARROW_UP) {
			        return element.parent().prev().children().eq(element.index());
			    } else if (keycode === ARROW_DOWN) {
			        return element.parent().next().children().eq(element.index());
			    }
			    return [];
			};
        editor.blur(function () {
            setActiveText();
            editor.hide();
        }).keydown(function (e) {
            if (e.which === ENTER) {
                setActiveText();
                editor.hide();
                active.focus();
                e.preventDefault();
                e.stopPropagation();
            } else if (e.which === ESC) {
                editor.val(active.text());
                e.preventDefault();
                e.stopPropagation();
                editor.hide();
                active.focus();
            } else if (e.which === TAB) {
                active.focus();
            } else if (editor.attr('type') === 'number') {
                $A.numberInputOnKeyDown(e);
            } else if (this.selectionEnd - this.selectionStart === this.value.length) {
                var possibleMove = movement(active, e.which);
                if (possibleMove.length > 0) {
                    possibleMove.focus();
                    e.preventDefault();
                    e.stopPropagation();
                }
            }
        })
		.on('input paste', function () {
		    var evt = $.Event('validate');
		    active.trigger(evt, editor.val());
		    if (evt.result === false) {
		        editor.addClass('error');
		    } else {
		        editor.removeClass('error');
		    }
		});
        element.on('click keypress dblclick', showEditor)
		.css('cursor', 'pointer')
		.keydown(function (e) {
		    var prevent = true,
				possibleMove = movement($(e.target), e.which);
		    if (possibleMove.length > 0) {
		        possibleMove.focus();
		    } else if (e.which === ENTER) {
		        showEditor(false);
		    } else if (e.which === 17 || e.which === 91 || e.which === 93) {
		        showEditor(true);
		        prevent = false;
		    } else {
		        prevent = false;
		    }
		    if (prevent) {
		        e.stopPropagation();
		        e.preventDefault();
		    }
		});

        element.find('td').prop('tabindex', 1);

        $(window).on('resize', function () {
            if (editor.is(':visible')) {
                editor.offset(active.offset())
				.width(active.width())
				.height(active.height());
            }
        });
    });

};

$.fn.editableTableWidget.defaultOptions = {
    cloneProperties: ['padding', 'padding-top', 'padding-bottom', 'padding-left', 'padding-right',
					  'text-align', 'font', 'font-size', 'font-family', 'font-weight',
					  'border', 'border-top', 'border-bottom', 'border-left', 'border-right'],
    editor: $('<input>')
};