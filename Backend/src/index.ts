import express from 'express';
import licensingRoutes from './licensingRoutes.js';
import paypalRoutes from './paypal/paypalRoutes.js';

const app = express();
app.use(express.json());

app.get('/health', (_req, res) => {
  res.json({ status: 'ok', service: 'Ark Suite Backend' });
});

app.use(licensingRoutes);
app.use(paypalRoutes);

app.listen(3000, () => {
  console.log('Ark Suite backend listening on port 3000');
});
