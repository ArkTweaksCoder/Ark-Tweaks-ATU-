export interface LicenseRecord {
  id: string;
  licenseKey: string;
  tier: string;
  userEmail: string;
  active: boolean;
  expiresAt: string;
  machineFingerprint?: string;
  productName?: string;
}

export interface LicenseStore {
  list(): LicenseRecord[];
  getByKey(licenseKey: string): LicenseRecord | undefined;
  save(record: LicenseRecord): LicenseRecord;
}

export class InMemoryLicenseStore implements LicenseStore {
  private records: LicenseRecord[] = [];

  list(): LicenseRecord[] {
    return [...this.records];
  }

  getByKey(licenseKey: string): LicenseRecord | undefined {
    return this.records.find((record) => record.licenseKey === licenseKey);
  }

  save(record: LicenseRecord): LicenseRecord {
    const existingIndex = this.records.findIndex((item) => item.id === record.id);

    if (existingIndex >= 0) {
      this.records[existingIndex] = record;
      return record;
    }

    this.records.push(record);
    return record;
  }
}

export const demoLicenseStore = new InMemoryLicenseStore();
