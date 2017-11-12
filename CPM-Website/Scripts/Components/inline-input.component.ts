import { Component, Input } from '@angular/core';
import { InputModel } from '../Models/InputModel'

@Component({
    selector: 'inline-input',
    templateUrl: './inline-input.component.html'
})

export class InlineInputComponent {
    @Input() model: InputModel;
}