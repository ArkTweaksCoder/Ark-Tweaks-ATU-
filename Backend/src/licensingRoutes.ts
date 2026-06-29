import { Router } from 'express';
import { demoLicenseStore } from './database.js';

const router = Router();

router.post('/api/licensing/validate', (req, res) => {
  const { licenseKey } = req.body as { licenseKey?: string };

  if (!licenseKey) {
    res.status(400).json({ ok: false, message: 'License key is required.' });
    return;
  }

  const record = demoLicenseStore.getByKey(licenseKey);

  if (!record) {
    res.status(404).json({ ok: false, message: 'License not found.' });
    return;
  }

  res.json({
    ok: true,
    tier: record.tier,
    message: 'License accepted in demo mode.',
    expiresAt: record.expiresAt
  });
});

router.post('/api/licensing/activate', (req, res) => {
  const { licenseKey, userEmail, machineFingerprint } = req.body as {
    licenseKey?: string;
    userEmail?: string;
    machineFingerprint?: string;
  };

  if (!licenseKey || !userEmail) {
    res.status(400).json({ ok: false, message: 'License key and email are required.' });
    return;
  }

  const record = demoLicenseStore.save({
    id: `license-${Date.now()}`,
    licenseKey,
    tier: 'Standard',
    userEmail,
    active: true,
    expiresAt: new Date(Date.now() + 14 * 24 * 60 * 60 * 1000).toISOString(),
    machineFingerprint,
    productName: 'Ark Optimize'
  });

  res.json({ ok: true, record });
});

export default router;
