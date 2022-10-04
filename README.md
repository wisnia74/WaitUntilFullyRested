
# WaitUntilFullyRested

Simple, QoL Bannerlord mod.

## About the mod
I was getting slightly frustrated anytime I wanted the "wait" sequence in settlement to stop automatically, once my character regenerated back to 100% stamina and the wait just kept on running. So I wrote a mod that does exactly that.

***Need to smith a lot and can't be bothered with "guessing" at what point your character regenerated back to 100% stamina? This mod is for you!***

The mod is fully localised, however I achieved that using Google Translate so the results might not be good in some cases.

Since it's really small and simple, it has no dependencies.

There's probably a ton of stamina mods out there, but I really wanted to just have a QoL feature and not something that would alter the gameplay in any way.

## How it works
It adds a simple button "Wait until you are fully rested" to towns and castles (not to villages because waiting in a village does not regenerate stamina anyway).

**The button will be visible only if your main hero is below 100% stamina.**

It will trigger a regular wait menu with one twist - once you reach 100% stamina, the wait will stop and you will be taken back to main settlement menu.

This way, you wait exactly as long as it takes to regenarate stamina back to 100%. Isn't that beautiful?

## Installation
Just [download the mod from NexusMods](https://www.nexusmods.com/mountandblade2bannerlord/mods/4515?tab=files) and extract the 7z archive into Modules folder inside you main game data directory.

For steam users that could be for example: `C:\Program Files\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules`.

## Compatibility
Written with Bannerlord `v1.7.2` in mind, mid-work game got updated to `e1.8.1.1942` so I tested with it too and encountered no issues.

The mod is compatible with both those versions - I didn't test with pre `v1.7.2` though so keep that in mind.

The mod does not modify any major campaign behaviors or whatnot, it only edits 1 default game menu and registers 2 new ones. As long as core APIs, that are responsible for that, didn't change, the mod should work with any version of Bannerlord.

## Credits
Shout out to [LesserScholar﻿](https://www.youtube.com/c/LesserScholar) - his "Artisan Workshop Mod Tutorial" series on YT helped me a ton with going about writing my own little mod.
