# Developer Guide

## Prerequisites
- .NET 8 SDK
- Node.js 20+
- Go 1.22+
- Rust toolchain (recommended)

## Build the shared SDK and desktop apps
```bash
dotnet build ArkSuite.sln
```

## Run the backend
```bash
cd Backend
npm install
npm run dev
```

## Run the licensing service
```bash
go run ./Licensing
```
