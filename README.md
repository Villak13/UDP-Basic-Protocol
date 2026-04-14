# 🛰️ UDP Basic Protocol (MAUI)

A lightweight, cross-platform mobile and desktop application built with **.NET MAUI**. This project demonstrates real-time, asynchronous UDP packet communication with a reactive user interface.

---

## 📂 Source Code
> [!TIP]
> The active development and source code for this project are located in the feature branch.
> 🔗 **[View Source Code (udp-basic-networking)](https://github.com/Villak13/MAUI/tree/udp-basic-networking)**

---

## 🚀 Key Features
* **Non-Blocking UDP Listener:** Uses `Task.Run` to listen for incoming packets without freezing the UI.
* **Interactive Chat UI:** Uses a `ScrollView` wrapped `VerticalStackLayout` for a smooth message stream.
* **Smart Data Toggling:** Tap any message label to switch between the **Username** and the sender's **IP/Endpoint**.
* **Crash-Proof Validation:** Implements strict `IPEndPoint.TryParse` logic to handle malformed IP inputs safely.
* **Cross-Platform:** Optimized for Android, iOS, Windows, and macOS.

---

## 🛠️ How to Run
1.  **Prerequisites:** * Visual Studio 2022 with the **.NET MAUI workload** installed.
    * .NET 8.0 or 9.0 SDK.
2.  **Clone & Open:**
    ```bash
    git clone https://github.com/Villak13/UDP-Basic-Protocol.git
    ```
3.  **Launch:**
    Open the solution and press **F5** to run on your preferred emulator or local machine.

---

## 📖 Technical Implementation
* **Separation of Concerns:** Networking logic is encapsulated in the `PacketHandler` namespace.
* **Thread Safety:** UI updates from background network threads are handled via `MainThread.BeginInvokeOnMainThread`.
* **Resource Management:** Designed to handle socket lifecycle to prevent "Port already in use" errors.

---

## 🤝 Contributing
1. Fork the project.
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`).
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`).
4. Push to the Branch (`git push origin feature/AmazingFeature`).
5. Open a Pull Request.

---
*Built with 💙 by Villak13 using C# and .NET MAUI*
