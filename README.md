This is "Endless Runner", a game intended to help me learn Unity Engine Game Development. It will be updated in the future.



# "Technical" Writeup 

### Current state of the project

Not being actively worked on in favor of other projects, but I plan to come back and finish some stuff up when I get the time. The core functionality of the game is done, it's mostly just figuring out Unity's scene system and making it all flow a little smoother.

### What's next for the project?

##### High Priority

- Make a menu system so that the user isn't immediately thrust into the game (although the game itself works great)

##### Relatively Low Priority

- Make an options menu that changes the difficulty of the game
- Implement sounds (though there aren't really many things in my game that need sounds, maybe just like music or something 
- Optimize the game a little bit, because the current method of making the path (like 60 recycled sprites) isn't exactly efficient and seems too brute forcey

### Challenges I faced

Some of the systems in this game were easy to program, and others much harder. 

Stuff like simply moving the character or doing all the texture work wasn't that complex, but it took time. 

Some stuff was harder, like collision. The collision methods I found through the unity documentation and the internet weren't really appropriate for my program, so I had to make one myself, and it turns out collision is kind of difficult to program. This was made a little easier by the fact that my game was 2D, and I worked out a system which used only x and y coordinates to control collision, and it is surprisingly accurate.

### On using Unity Engine / C#

C# was already familiar to me, due to me doing a game project on it a few years ago with the XNA Framework, as well as me knowing a good amount of Java, which is very syntactically similar. 

As a whole, once I got over the initial Unity Engine learning curve, this turned out not to be too hard of a project, but it was time-intensive and not without a lot of issues that got smoothed out. It has made me a better programmer for sure, though.

I did figure out that I liked Unity Engine a lot, though. 

### What's next for the project?

A few things I would like to implement when I get the time:

- A menu system instead of throwing you into the game right away
- Difficulty settings that control path speed and player control speed
- Maybe powerups 
- A pixel-perfect collision system (very complex, though)


