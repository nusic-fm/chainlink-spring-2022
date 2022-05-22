# Chainlink Spring 2022
## Player Download

Coming soon

## Developer Download
### Install all dependencies:

- [Unity Hub](https://unity3d.com/get-unity/download)
- [Visual Studio](https://visualstudio.microsoft.com/)

### [Download latest Nusic Asset Package Release](https://github.com/nusic-fm/chainlink-spring-2022/releases)

### Create a New Unity Project and Import the Package

- Open Unity Hub
- Click on the 'NEW' button and create a new project and specify (or download) the version of Unity you want to use
  > This project was made in Unity3D **2020.3.26**
  > 
  > The boilerplate project has been tested with the following Unity3D Releases:
  > - 2020.2
  > - 2020.3.31 (latest)
  > - 2021.2.5
  > 
  > If you do not see the version of Unity you want in Unity Hub, find and download it in the [Unity Download Archive](https://unity3d.com/get-unity/download/archive)*
- When the project opens, open Edit->Preferences->External Tools (on MAC this is Unity->Preferences->External Tools) and make sure "Script Editor" is set to your installed Visual Studio instance. IMPORTANT: This step must be done before importing the package.
- Navigate to the folder you downloaded the package to. Drag and drop the package into the Unity project (or double-click on the .unitypackage).
  
  <img src="https://raw.githubusercontent.com/ethereum-boilerplate/web3-unity-boilerplate/main/gifs/add.gif" width="600" height="346" />

- If you receive an error regarding Newtonsoft, follow these steps:

  - In Right click on Packages and select "Show In Explorer". Fix Newtonsoft 1
  - Open the Packages folder Fix Newtonsoft 2
  - Edit the manifest.json file Fix Newtonsoft 3
  - Add an entry for "com.unity.nuget.newtonsoft-json": "2.0.0", Fix Newtonsoft 4
  - Save the file and return to Unity, it should auto-load the Newtonsoft package.
- Open MoralisWeb3ApiSdk->Example and double-click on the DemoScene object.
- In the "Hierachy" panel under DemoScene select "MoralisSetup".
- In the "Inspector" section find the sub-section titled "MoralisController".
- If the "MoralisController" sub-section is not expanded, expand it.
- Using the information from your Moralis Server, fill in Application Id, and Server URL. insertvalues

  <img src="https://raw.githubusercontent.com/ethereum-boilerplate/web3-unity-boilerplate/main/gifs/insertvalues.gif" width="600" height="346" />

- NOTE Your wallet must be connected to the Polygon Mumbai test network and your account will need some funds. Use the Polygon Faucet to send yourself test funds.
- In your Unity Project Window, navigate to the Assets>Scenes and double-click on the Nusic Scene.
- Run the application by clicking the Play icon located at the top, center of the Unity3D IDE.

For more help with Moralis setup, visit 
- [Moralis Web3 for Unity Boilerplate](https://github.com/ethereum-boilerplate/web3-unity-boilerplate)
- [Building Web3 Games in Unity using Avalanche and Moralis](https://www.youtube.com/watch?v=XJgg81UZ1C0&t=2679s)

## Controls 
- To walk around use the mouse for direction, the 'W' key to move forward and the 'S' key to move backwards. 
- Use the 'SHIFT' key with the 'W' and 'S' keys to run.
- Use the space bar to jump.
