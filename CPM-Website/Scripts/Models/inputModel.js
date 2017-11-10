"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var InputModel = (function () {
    function InputModel(display, value, type, id, name, placeholder) {
        if (display === void 0) { display = ''; }
        if (value === void 0) { value = ''; }
        if (type === void 0) { type = ''; }
        if (id === void 0) { id = ''; }
        if (name === void 0) { name = ''; }
        if (placeholder === void 0) { placeholder = ''; }
        this.display = display || '';
        this.value = value || '';
        this.id = id || name || '';
        this.name = name || id || '';
        this.type = type || 'text';
        this.placeholder = placeholder || '';
        this.disabled = false;
        this.readonly = false;
        this.inputClass = ['col-md-9', 'col-xs-12'];
        this.labelClass = ['control-label', 'col-md-3', 'col-xs-12'];
    }
    return InputModel;
}());
exports.InputModel = InputModel;
//# sourceMappingURL=inputModel.js.map