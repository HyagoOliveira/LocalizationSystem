# Localization System

* Scripts and tools for Localization.
* Unity minimum version: **6000.1**
* Current version: **1.1.0**
* License: **MIT**
* Dependencies:
	- [com.unity.localization : 1.5.7](https://docs.unity3d.com/Packages/com.unity.localization@1.5/changelog/CHANGELOG.html#157---2025-08-07)
	- [com.actioncode.game-data-system : 0.3.0](https://github.com/HyagoOliveira/GameDataSystem#0.3.0)

## Summary

This package has some tools to facilitate Unity development with localization. It uses the Unity Localization package.

## Find Translation Tables

You can quickly find the Translations Tables inside your project by going to Tools > Find > Localization Folder.

## Start Game using Serialized Localization

Starts your game using the serialized data from any [AbstractGameData](https://github.com/HyagoOliveira/GameDataSystem/blob/main/Runtime/AbstractGameData.cs) implementation (from Game Data System package).

Go to Project Settings > Localization, Locale Selectors and add the [Game Data Locale Selector](/Runtime/GameDataLocaleSelector.cs).

![Game Data Locale Selector](/Docs~/GameDataLocaleSelector.png)

Make sure to place it as the first list item and use your project Game Data (a Scriptable Object implementation from AbstractGameData).

![Locale Selectors](/Docs~/LocaleSelectors.png)

## Installation

### Using the Package Registry Server

Follow the instructions inside [here](https://cutt.ly/ukvj1c8) and the package **ActionCode-LocalizationSystem** 
will be available for you to install using the **Package Manager** windows.

### Using the Git URL

You will need a **Git client** installed on your computer with the Path variable already set. 

- Use the **Package Manager** "Add package from git URL..." feature and paste this URL: `https://github.com/HyagoOliveira/LocalizationSystem.git`

- You can also manually modify you `Packages/manifest.json` file and add this line inside `dependencies` attribute: 

```json
"com.actioncode.localization-system":"https://github.com/HyagoOliveira/LocalizationSystem.git"
```

---

**Hyago Oliveira**

[GitHub](https://github.com/HyagoOliveira) -
[BitBucket](https://bitbucket.org/HyagoGow/) -
[LinkedIn](https://www.linkedin.com/in/hyago-oliveira/) -
<hyagogow@gmail.com>