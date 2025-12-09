# 📷 Webcam Barcode Reader

> Transform your webcam into a powerful EAN-13 barcode scanner with real-time detection, validation, and educational analysis.

![Language](https://img.shields.io/badge/C%23-239120?logo=c-sharp&logoColor=white)
![Framework](https://img.shields.io/badge/.NET%20Framework-4.7.2-512BD4)
![Platform](https://img.shields.io/badge/platform-Windows-0078D6?logo=windows)

---

## Features

- **Real-Time Scanning**: Live webcam preview with instant barcode detection
- **Smart Validation**: Automatic check digit verification and integrity checks
- **Visual Feedback**: Bounding box highlighting and audio confirmation
- **Structural Analysis**: Breaks down barcodes into system, manufacturer, and product codes
- **Scan History**: Track all detected codes in session
- **Keyboard Shortcuts**: Press `C` to scan instantly
- **No Special Hardware**: Works with any standard webcam

---

## Requirements

- **OS**: Windows 7 or higher
- **.NET Framework**: 4.7.2+ (pre-installed on modern Windows)
- **Camera**: Any standard webcam
- **For Development**: Visual Studio 2015+

---

## How to Use

1. **Launch** → Click "Add Barcodes"
2. **Select Camera** → Choose from dropdown
3. **Start Camera** → Click "Read Code"
4. **Position Barcode** → Hold product 6-12 inches from camera
5. **Scan** → Press `C` or click "Read Code" again
6. **View Results** → See the barcode, validation, and structural breakdown

### Understanding Results

**Lexical Analysis**: Each character displayed individually with position  
**Structural Breakdown** (EAN-13): System code • Manufacturer code • Product code • Check digit  
**Validation**: Mathematical verification of check digit authenticity  

---

## Use Cases

- **Retail & Inventory**: Product identification without dedicated scanners
- **Education**: Learn about barcode encoding and validation algorithms  
- **Quality Control**: Verify product codes and detect counterfeits
- **Development**: Test barcode implementations
- **Home Organization**: Catalog personal collections

---


## Troubleshooting

| Issue | Solution |
|-------|----------|
| Camera not detected | Close other apps using webcam; check Device Manager |
| Barcode not scanning | Improve lighting; adjust distance; clean barcode |
| "Invalid" result | May be counterfeit, damaged, or incorrectly printed |

---

## Acknowledgments

This project uses powerful open-source libraries:

- **[AForge.NET](http://www.aforgenet.com/)** by Andrew Kirillov - Computer vision and video processing
- **[ZXing.NET](https://github.com/micjahn/ZXing.Net)** - Industry-standard barcode detection
- **GS1 Organization** - EAN-13 standard specification

---

## 🔧 Technical Stack

| Component | Technology |
|-----------|-----------|
| Language | C# (.NET Framework 4.7.2) |
| Video Capture | AForge.NET v2.2.5 |
| Barcode Engine | ZXing.NET v0.16.10 |
| UI Framework | Windows Forms |

### How It Works

1. **Capture** → AForge captures frames from DirectShow cameras
2. **Process** → Thread-safe bitmap conversion and buffering
3. **Decode** → ZXing detects barcodes with TryHarder + AutoRotate modes
4. **Validate** → EAN-13 check digit algorithm verification
5. **Display** → Real-time visual feedback with bounding boxes

---


## Contributing

Contributions welcome! Fork the repo, create a feature branch, and submit a PR.

**Ideas for Enhancement:**
- Additional barcode formats (DataMatrix, PDF417)
- Batch scanning mode
- Export scan history to CSV
- Database integration
- Multi-language UI
- Dark mode theme

---

## 📦 Project Structure

```
LectorBarcodes/
├── Program.cs              # Entry point
├── Form1.cs               # Main menu
├── AddBarcodes.cs         # Scanner + validation logic
├── packages.config        # NuGet dependencies
└── Properties/            # Assembly info
```

---
<div align="center">

**⭐ If you find this project useful, consider giving it a star! ⭐**

Made by [Aaron Casildo](https://github.com/AaronCasildo)

</div>