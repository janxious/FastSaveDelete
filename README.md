# Fast Save Delete

BattleTech Mod (using [BTML](https://github.com/Mpstark/BattleTechModLoader) and [ModTek](https://github.com/Mpstark/ModTek)).

## Features
* No comfirmation prompt for deleting save games
* _Do_ prompt for most recent save

## Download
Downloads can be found on [Github](https://github.com/janxious/FastSaveDelete/releases).

## Install
- [Install BTML and Modtek](https://github.com/Mpstark/ModTek/wiki/The-Drop-Dead-Simple-Guide-to-Installing-BTML-&-ModTek-&-ModTek-mods).
- Put the `FastSaveDelete.dll` and `mod.json` files into `\BATTLETECH\Mods\FastSaveDelete` folder.
- If you want to change the settings do so in the mod.json.
- Start the game.

## Special Thanks

HBS, @Mpstark, @Morphyum

## Maintainer Notes: New HBS Patch Instructions

* pop open VS
* grab the latest version of the assembly
* copy the new version of the methods in `original_src` over the existing ones
* see if anything important changed via git
