# Photo Albums

I opted for the Photo Album project. The Project is in Core 3.1 & C#.
I chose Core to minimize compatiblity issues on different machines since I didn't know what you guys would be running it on. The program doesn't require anything special and can be built and run in VS right after cloning.

I opted to change the formatting of the album output away from raw JSON into something that looked more like a directory tree to me. To do this I created objects to hold the photos returned and the list of photos, which I called an album, and created a ToString override for them. It wasn't strictly necessary and made the program a bit larger, but if the program was getting these results with the desire to do more with them it would be helpful to have them built out.
