"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.UserRegistrationFormModel = void 0;
var forms_1 = require("@angular/forms");
var UserRegistrationFormModel = /** @class */ (function () {
    function UserRegistrationFormModel() {
        this.formBuilder = new forms_1.FormBuilder();
        this.createForm();
    }
    UserRegistrationFormModel.prototype.createForm = function () {
        this.model = this.formBuilder.group({
            Login: ['', forms_1.Validators.required],
            Email: ['', forms_1.Validators.required, forms_1.Validators.email],
            Password: ['', forms_1.Validators.required],
            ConfirmedPassword: ['', forms_1.Validators.required],
            PinnedFile: [null]
        });
    };
    return UserRegistrationFormModel;
}());
exports.UserRegistrationFormModel = UserRegistrationFormModel;
//# sourceMappingURL=form.models.js.map