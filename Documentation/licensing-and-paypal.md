# Licensing and PayPal Integration

## Licensing flow
- The desktop client can activate a license key through the backend.
- The backend validates the request and returns activation status.
- The activation service is designed to support future database-backed persistence.

## PayPal scaffolding
- A create-order endpoint is available at `/api/paypal/create-order`.
- A webhook endpoint is available at `/api/paypal/webhook`.
- Environment variables can be supplied for sandbox or production credentials.
