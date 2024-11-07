# Syncfusion Semantic Kernel MAUI

[![Build Status](https://img.shields.io/badge/build-passing-brightgreen)](#)

Integrate AI-assisted features into your MAUI applications! This project allows you to interact and switch between multiple AI services seamlessly. Leveraging **Syncfusion's MAUI components** and **Semantic Kernel**, it provides a robust function-calling app with breathtaking UIs.

## Table of Contents

- [About the Project](#about-the-project)
- [Features](#features)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Usage](#usage)
- [Screenshots](#screenshots)
- [Roadmap](#roadmap)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)
- [Acknowledgments](#acknowledgments)
- [FAQ](#faq)

---

## About the Project

This MAUI (Multi-platform App UI) project integrates AI-assisted features for interacting with and switching between multiple AI services. By leveraging **Syncfusion's MAUI components** and **Semantic Kernel**, it offers a robust function-calling app with stunning user interfaces.

## Features

- 🤖 **Multi-AI Service Integration**: Seamlessly interact with various AI services through a unified kernel.
- 🎨 **Breathtaking UIs**: Utilize Syncfusion's powerful MAUI controls to create stunning cross-platform applications.
- 🔄 **Easy Switching Between Providers**: Change AI service providers effortlessly by updating configurations.
- ⚡ **Extensible Architecture**: Expand the application to support more providers and functionalities.
- 🚀 **Cross-Platform Support**: Build applications for iOS, Android, Windows, and more using MAUI.

## Getting Started

### Prerequisites

- **Development Environment**: Visual Studio 2022 with MAUI workload installed
- **.NET SDK**: .NET 6 or later
- **API Keys**: Obtain API keys for the AI services you wish to use
- **Syncfusion License Key**: Required for Syncfusion components (free community licenses are available)

### Installation

1. **Clone the Repository**
   ```bash
   git clone https://github.com/yourusername/syncfusion-semantic-kernel-maui.git
   ```
2. **Open the Project**
   - Open the solution file (`.sln`) in Visual Studio 2022.
3. **Update API Keys**
   - Locate the `appsettings.json` file.
   - Update the `ApiKeys` section with your respective API keys.
4. **Register Syncfusion License**
   - Add your Syncfusion license key in the `App.xaml.cs` file:
     ```csharp
     Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");
     ```
5. **Install Dependencies**
   - Restore NuGet packages via Visual Studio:
     - Right-click on the solution and select **Restore NuGet Packages**.
6. **Run the Application**
   - Select your target platform (iOS, Android, Windows, etc.) and run the application.

## Usage

- **Interact with AI Services**
  - Use the app to call functions from different AI services.
- **Switch Between Providers**
  - Change the AI service provider by updating the configuration in `appsettings.json`.
- **Customize the UI**
  - Leverage Syncfusion MAUI controls to modify and enhance the user interface.
- **Extend Functionality**
  - Add new features and providers using the extensible architecture.

## Screenshots



https://github.com/user-attachments/assets/d98ad0a9-0479-42a3-aeda-471c4da194d2



## Roadmap

- **Upcoming Features**
  - 📸 **Image Analysis**: Add a feature to take pictures and analyze them using a multimodal service.
  - 🛠️ **More AI Functions**: Implement additional AI functionalities like voice recognition and natural language processing.
- **Long-Term Goals**
  - 🌐 **Expand Provider Support**: Integrate more AI services and providers.
  - 🎯 **Enhanced UI/UX**: Incorporate more Syncfusion components for richer user experiences.

Stay tuned for exciting updates!

## Contributing

Contributions are what make the open-source community such an amazing place to learn, inspire, and create. **Any contributions you make are greatly appreciated**.

1. **Fork the Project**
2. **Create your Feature Branch** (`git checkout -b feature/AmazingFeature`)
3. **Commit your Changes** (`git commit -m 'Add some AmazingFeature'`)
4. **Push to the Branch** (`git push origin feature/AmazingFeature`)
5. **Open a Pull Request**

## License

Distributed under the **MIT License**. See `LICENSE` file for more information.

## Contact

- **Email**: [peopleworks@gmail.com](mailto:peopleworks@gmail.com)

## Acknowledgments

- 💙 **Microsoft® Semantic Kernel Team**: For their outstanding work.
- ⭐ **Syncfusion**: For providing the best components in the .NET ecosystem.
- 🛠️ **Ollama**: For their great tools.
- 🚀 **Google**: For their fast and well-done models.
- 🤝 **Groq**: For being a part of the developer community.
- 🌐 **Meta**: For supporting open-source initiatives.

## FAQ

### ❓ Can I use other AI service providers?

Yes! The architecture is designed to be extensible. You can add or switch providers by updating the configuration and implementing the necessary interfaces.

### ❓ Do I need a Syncfusion license?

Syncfusion offers a free community license if you qualify; otherwise, you may need to purchase a license for their components. Check their [licensing page](https://www.syncfusion.com/sales/communitylicense) for more information.

### ❓ How can I contribute?

See the [Contributing](#contributing) section above for details on how to get started.

---

*This README aims to provide a comprehensive overview of the Syncfusion Semantic Kernel MAUI project, assisting developers and contributors in harnessing the power of AI in cross-platform MAUI applications with stunning UI components.*

---

