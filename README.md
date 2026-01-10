## 🚀 **Prerequisites**  
1. **Unity Hub** ([Download here](https://unity.com/download))  
2. **Unity Editor 6000.2.14f1**  
   - Install via Unity Hub → `Installs` → `Add` → Select version `6000.2.14f1`.  
3. **Git** ([Download here](https://git-scm.com/)) or another git client of choice  

---

## 📥 **Installation**  

### **1. Clone the Repository**  
```bash
git clone https://github.com/AHoroszkiewicz/Inzynierka.git
cd your-repo
```

### **2. Open the Project in Unity**  
- Launch **Unity Hub**  
- Click `Open` → Select the cloned project folder  
- Ensure Unity **6000.2.14f1** is selected  

> ⚠️ **If prompted to upgrade/downgrade**, **DO NOT** proceed. Use **6000.2.14f1**.  

### **3. Resolve Dependencies (If Needed)**  
- If errors appear, try:  
  - `Window` → `Package Manager` → Update packages  
  - Reimport assets: `Assets` → `Reimport All`  

---

## 🎮 **Running the Project**
Project doesn't have a working build yet.  
1. Open the main scene:  
   - Navigate to `Assets/Scenes/MainMenu.unity`
2. Press **▶ Play** in the Unity Editor.  

---

## 📦 **Project Structure**  
```
Assets/
├── Audio/                          # Audio files
│
├── Plugins/                        # Plugin related files
│
├── Prefabs/                        # Prefab objects
│   └── UI/                         # UI prefabs
│       └── MainMenu/               # MainMenu prefabs
│
├── Resources/                      # Plugin related files
│
├── Scenes/                         # Unity scene files
│
├── Scripts/                        # C# scripts
│   ├── Cards/                      # Card related scripts
│   │    └── Effects/               # Card effects related scripts
│   └── UI/                         # UI related scripts
│
├── Settings/                       # Unity settings files
│
├── SO/                             # Scriptable Objects
│   ├── CardsSO/                    # Cards related SO
│   │    ├── Numbers/               # Cards SO with numbers
│   │    └── Symbols/               # Cards SO with symbols
│   └── GameModeSO/                 # Game mode related SO
│
├── Sprites/                        # 2D textures and UI art
│   ├── Cards/                      # Sprites related with cards
│   │    ├── Numbers/               # Sprites of numbers for cards
│   │    └── Symbols/               # Sprites of symbols for cards
│   └── UI/                         # UI related sprites
│
└── TextMesh Pro/                   # TMPro related files

```
