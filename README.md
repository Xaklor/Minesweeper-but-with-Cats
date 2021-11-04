# Minesweeper but with Cats

This is a Minesweeper game. But there's also cat pictures.

# Controls

* Left-click a hidden tile to reveal it. If the tile has 0 mines surrounding it, it will reveal everything else around it too.
* Hold Left-click on a revealed tile to highlight any neighboring hidden tiles. This can be useful for visualizing where the mines might be.
* If a revealed tile has the same number of flags next to it as there are mines, you can left-click to reveal everything around it at once since those tiles should be safe. Careful though! If you have incorrectly flagged a tile, then you have left a mine as "safe" and it will be revealed. Your incorrect flag will be highlighted so you can avoid the mistake in the future.
* Right-click a hidden tile to flag it as a mine. Right-click again to un-flag it. Flagged tiles won't be revealed until you un-flag them, and they let you take notes on what is and isn't a mine. 

# Features

* Cat Pictures!

When the game starts up, it will connect to the r/cats subreddit and pull all the images from the 50 latest posts and save them to a folder called "cats". Once this is finished, every time you start a new game it will select a cat picture at random from that folder to use as the background image for the minesweeper board. The picture gets revealed bit by bit as you clear sections of board progressively, and when you win the entire picture is fully revealed. When you win, the image is moved into a different folder called "completed", but if you lose the image stays put. If you win the game will also save an extra copy of the image to a file named "recent" next to the application so you can easily find it instead of hunting through the entire completed folder. This copy will get overwritten by future pictures from won games, but the original will always be untouched inside of the completed folder. Once the number of pictures in the cats folder gets low, the game will automatically pull pictures from r/cats again. On startup there will be a popup telling you when the images have finished downloading, but all future refreshes happen silently in the background without interrupting the game you might be in the middle of. You can also start immediately without waiting for the images to be downloaded if you want, but you may not have any cat pictures and so you'll have a default background image. 

* Custom Pictures!

Want to use pictures of your own cats? What about your dogs? You can easily include any image you want in the pool of background images by simply dropping the image into the cats folder. The game won't care where the image came from, it'll take anything inside of that folder. So you can load it up with dogs, or parrots, or fish, or amazing landscapes, or flowers, or memes or anything else you want! There is one catch though, the image *must* be either a .png or a .jpg. Anything else won't get noticed by the program. 

* Offline Mode!

In case you don't want new cat pictures either because you're using a custom image set or your internet connection is spotty or missing entirely, there's an optional offline mode you can enable in the options menu. When enabled, the application won't visit reddit for more cat pics even if the cats folder is completely empty. It will also stop removing images from the cats folder so you don't run out of background images in the meantime. Offline mode is also automatically enabled any time the application encounters a connection problem when downloading images to prevent any further bugging out until you've addressed your internet connection issues.

* Custom Board Sizes!

In addition to the 3 standard difficulty modes, you can input any custom dimensions and number of mines for a custom experience. The max allowed dimensions are 30x30.

* Themes!

There are 4 different visual themes included in the game: Cats, Classic, Bubbles, and Dark. The Cats theme is enabled by default, but you can change it at any time in the options menu. There is also an option to use large or small tiles in the game, depending on which suits your needs and/or screen size better.

* Stats!

The game keeps track of your top 3 times for beating easy, normal, and hard mode boards, as well as your win ratio. Custom board times aren't tracked because there's too many different possible boards. 

# Important things

* This application will create save files and image folders nearby itself, so make sure to put it in its own folder or someplace you don't care about clutter before running it. 
* When starting up for the first time the application needs to get images from r/cats before you can play with them, so if you want cat pictures please wait until a popup appears letting you know the pictures are ready. You can start before then and the game will run normally, you just might not have any pictures. You shouldn't need to wait for this ever again after the initial pull.
* This probably only runs on Windows machines, but I don't have a Mac to try it on and see what happens. You're welcome to try if you're a Mac user but I'm pretty sure you need Windows for this.
* You may get some warning on your computer saying this thing hasn't been frequently downloaded and you might not want to trust it. There isn't really anything I can do about this since I'm some nobody on the internet making a fun little minesweeper game in their free time, but if you're concerned about it the source code is all in this repo and here's a [VirusTotal](https://www.virustotal.com/gui/file/1c9835f501373ab3ee8cfb8d212606d9f222cdc770d54a3e10a562b2b98ed4f6/detection) link for the application.
