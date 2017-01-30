module CustomEvents {

    export class CEvent {
        private handlers: (() => void)[] = [];

        public addHandler(handler: () => void): void {
            this.handlers.push(handler);
        }

        public trigger(): void {
            this.handlers.forEach(handler => handler());
        }
    }

}