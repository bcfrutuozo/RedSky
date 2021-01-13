var ajax_windows_visible = false;
var isBlocking = false;
var comma = ',';
var dot = '.';

function xstooltip_show(tooltipId, parentId) {
    var it = document.getElementById(tooltipId);

    it.style.width = it.offsetWidth + 100 + "px";
    it.style.height = it.offsetHeight + "px";

    var parent = document.getElementById(parentId);
    var rect = parent.getBoundingClientRect();
    var posX = rect.left + window.scrollX;
    var posY = rect.top + window.scrollY;

    it.style.top = posY + "px";
    posX = posX - it.offsetWidth - 150;
    it.style.left = posX + "px";

    it.style.visibility = "visible";
}

function xstooltip_hide(id) {
    var it = document.getElementById(id);
    it.style.visibility = "hidden";
}

// Jquery blockUI
$(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);

function showProgress(msg) {
    var modalheader = document.getElementById("ajax_windows_msg");
    modalheader.innerHTML = msg;

    if (!isBlocking) {
        isBlocking = true;
        $.blockUI({
            css: {
                padding: "0",
                margin: "0",
                width: "30%",
                top: "40%",
                left: "35%",
                textAlign: "center",
                color: "#000",
                border: "0px solid #aaa", // Default CSS for blockUI with the borders removed
                backgroundColor: "#fff",
                cursor: "wait"
            },
            baseZ: 2000,
            message: $("#ajax_window")
        });
    }
};

function hideProgress() {
    if (isBlocking) {
        $.unblockUI();
        isBlocking = false;
    }
};

// Exibe e popula os dados do modal.
$(function () {
    $("body").on("click",
        ".modal-link",
        function (e) {
            e.preventDefault();
            $("#modal-container").remove();
            $.get($(this).data("targeturl"),
                function (data) {
                    $('<div id="modal-container" class="modal fade">' +
                        '<div id="container-resizer" class="modal-dialog modal-lg popup-modal">' +
                        '<div class="modal-content" id="modalbody" >' +
                            data +
                        "</div>" +
                        "</div>" +
                        "</div>").modal();
                });
        });
});

// Restricts input for each element in the set of matched elements to the given inputFilter.
(function ($) {
    $.fn.inputFilter = function (inputFilter) {
        return this.on("input keydown keyup mousedown mouseup select contextmenu drop",
            function () {
                if (inputFilter(this.value)) {
                    this.oldValue = this.value;
                    this.oldSelectionStart = this.selectionStart;
                    this.oldSelectionEnd = this.selectionEnd;
                } else if (this.hasOwnProperty("oldValue")) {
                    this.value = this.oldValue;
                    this.setSelectionRange(this.oldSelectionStart, this.oldSelectionEnd);
                }
            });
    };
}(jQuery));

// Restricts input for the given textbox to the given inputFilter.
function setInputFilter(textbox, inputFilter) {
    ["input", "keydown", "keyup", "mousedown", "mouseup", "select", "contextmenu", "drop"].forEach(function (event) {
        textbox.addEventListener(event,
            function () {
                if (inputFilter(this.value)) {
                    this.oldValue = this.value;
                    this.oldSelectionStart = this.selectionStart;
                    this.oldSelectionEnd = this.selectionEnd;
                } else if (this.hasOwnProperty("oldValue")) {
                    this.value = this.oldValue;
                    this.setSelectionRange(this.oldSelectionStart, this.oldSelectionEnd);
                }
            });
    });
}

function parseDecimal(value) {
    if (localeDecimal === comma && value.includes(comma)) {
        return parseFloat(value.replace(dot, ' ').replace(comma, dot).replace(' ', ','));
        } else {
        return parseFloat(value.replace(comma, ''));
    }
}