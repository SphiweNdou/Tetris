# Tetris – WPF Desktop Game (C#)

This is a Tetris clone developed using **Windows Presentation Foundation (WPF)** in C#. It features a modular structure, real-time gameplay, and responsive keyboard controls. Each Tetris block (Tetromino) is implemented as a unique class, making the game extendable and cleanly architected.

## 🎮 Features

- 🧱 Classic Tetris Gameplay with 7 Tetromino types
- ⌨️ Keyboard Input for rotation and movement
- 🧠 Game logic handled by `GameController.cs`
- 📐 UI rendering with XAML (`MainWindow.xaml`)
- 💡 Real-time playfield and collision detection via `Playfield.cs`

## 🧰 Tech Stack

- **Language:** C#
- **Framework:** .NET WPF
- **UI:** XAML
- **IDE:** Visual Studio 2022

## 🛠️ Setup Instructions

### 1. Clone the Repository
```bash
git clone https://github.com/SphiweNdou/tetris-wpf.git
cd tetris-wpf
```

### 2. Open in Visual Studio
- Open `Tetris.sln`
- Set the `Tetris` project as the startup project
- Build and run using `F5`

## 🧩 Database Setup

> This project does **not** require a database. All game state is handled in memory for real-time performance.

## 🖼️ User Interface

The interface is built with XAML and rendered through the `MainWindow.xaml` file. The Tetris board is dynamically updated as Tetrominoes fall and interact with the playfield. The interface includes:

- A canvas for the game grid
- Colored blocks for each Tetromino type
- Responsive redraw on each game tick

## 🎮 Game Controls

- **← / →** – Move left/right
- **↓** – Soft drop
- **↑ or Space** – Rotate block

## 🧩 Project Structure

- `Bricks/` – Individual Tetromino classes
- `GameController.cs` – Main game loop and control logic
- `Playfield.cs` – Collision and placement logic
- `MainWindow.xaml` – WPF canvas and visual layout

## 👨‍💻 Author

**Sphiwe Ndou**  
Game Dev Hobbyist | Full-Stack .NET Developer  
GitHub: [@SphiweNdou](https://github.com/SphiweNdou)  
LinkedIn: [linkedin.com/in/yourprofile](https://linkedin.com/in/ndivhuho-ndou-39246515a)

---

Enjoy the game or build on top of it. Contributions are always welcome!
