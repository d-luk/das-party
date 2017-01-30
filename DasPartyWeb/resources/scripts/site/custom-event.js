var CustomEvents;
(function (CustomEvents) {
    var CEvent = (function () {
        function CEvent() {
            this.handlers = [];
        }
        CEvent.prototype.addHandler = function (handler) {
            this.handlers.push(handler);
        };
        CEvent.prototype.trigger = function () {
            this.handlers.forEach(function (handler) { return handler(); });
        };
        return CEvent;
    }());
    CustomEvents.CEvent = CEvent;
})(CustomEvents || (CustomEvents = {}));
//# sourceMappingURL=custom-event.js.map