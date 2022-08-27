"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.NavigateGuard = void 0;
var NavigateGuard = /** @class */ (function () {
    function NavigateGuard(globalAppService) {
        this.globalAppService = globalAppService;
    }
    NavigateGuard.prototype.canActivate = function (route, state) {
        if (this.globalAppService.isUserAuthenticated) {
            alert("Need to login first!");
            return false;
        }
        return true;
    };
    return NavigateGuard;
}());
exports.NavigateGuard = NavigateGuard;
//# sourceMappingURL=navigate-guard.js.map