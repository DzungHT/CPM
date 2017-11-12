export class InputModel {
    value: any;
    id: string;
    name: string;
    type: string;
    display: string;
    placeholder: string;
    inputClass: string[];
    labelClass: string[];
    disabled: boolean;
    readonly: boolean;

    constructor(display: string = '', value: any = '', type:string ='', id: string ='', name: string = '', placeholder:string = '') {
        this.display = display || '';
        this.value = value || '';

        this.id = id || name ||'';
        this.name = name || id || '';
        this.type = type || 'text';
        this.placeholder = placeholder || '';
        this.disabled = false;
        this.readonly = false;
        this.inputClass = ['col-md-9', 'col-xs-12'];
        this.labelClass = ['control-label', 'col-md-3', 'col-xs-12'];
    }
}