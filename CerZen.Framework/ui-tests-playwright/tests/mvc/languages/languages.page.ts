﻿import { BaseMvcPage } from "../../shared/base-page";

export class LanguagesPage extends BaseMvcPage {

    async gotoPage() {
        await this.gotoUrl('/WebApp/Languages');
    }
}