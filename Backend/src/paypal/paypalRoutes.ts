import { Router } from 'express';

const router = Router();

router.post('/api/paypal/create-order', (_req, res) => {
  res.json({
    ok: true,
    orderId: 'PAYPAL-ORDER-DEMO',
    approvalUrl: 'https://www.paypal.com/checkoutnow?token=DEMO'
  });
});

router.post('/api/paypal/webhook', (req, res) => {
  const event = req.body;
  console.log('PayPal webhook received', event?.event_type ?? 'unknown');
  res.status(200).json({ ok: true, received: true });
});

export default router;
