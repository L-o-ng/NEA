**NEA Overview**

This is a local network consisting of one consoleapp server and may windows forms clients. The client is used to gather requested parameters to send to the server, which does the generation. The server does all heavy lifting by generating mazes with the requested parameters, solving them with the requested algorithm, and returning them to the respective client, which shows the maze on screen. 

There is also room for additional features, such as a login system, the ability to play mazes instead of the server solving them, and the server gathering stats which the client can view via a windows forms graph on a seperate tab.


**Potential Algorithms for inclusion**<br/><br/>
Binary Tree: Great for testing, bad for complexity.<br/><br/>
Depth-first: Good first algorithm to implement, perhaps via a linked list. Easy and fast to generate with a cell structure, but with a decent complexity via potential for a recersive implementation or a stack implementation (both on mark scheme).<br/><br/>
Kruskal's algorithm: Great algorithm to look at, as generation involves using complex techniques (sets, maybe graphs or trees).<br/><br/>
Prim's algorithm: Good algorithm and can introduce lots of flexible complexity with a weighting system.<br/><br/>
Wilson's algorithm: Really complex.<br/><br/>
Aldous-Broder algorithm: Similar but inefficient generation.<br/><br/>
