export const paypalConfig = {
  clientId: process.env.PAYPAL_CLIENT_ID ?? 'demo-client-id',
  clientSecret: process.env.PAYPAL_CLIENT_SECRET ?? 'demo-client-secret',
  baseUrl: process.env.PAYPAL_BASE_URL ?? 'https://api-m.sandbox.paypal.com',
  webhookId: process.env.PAYPAL_WEBHOOK_ID ?? 'demo-webhook-id'
};
