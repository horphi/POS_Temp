﻿import { BaseMvcPage } from "../../shared/base-page";

export class WebhookSubscriptionPage extends BaseMvcPage {

    async gotoPage() {
        await this.gotoUrl('/WebApp/WebhookSubscription');
    }
}