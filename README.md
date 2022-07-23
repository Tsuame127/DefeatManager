Requirements:  Visual Studio 2022 with WPF .NET Framework


Mechanics: 
Start by setting up the number of matches that you are allowed to lose and the number of players.

Every player gets a joker.

If you lose, you have the possibility to rematch, but if you win it will not count as a lost match, but if you lose the rematch the defeat remaining will decrease.

If you win two matches in a row, it will increase the number of defeats remaining. Rematch win doesn't put you on a winning streak. You have to win two games separately.

If any player uses a joker, the next defeat will not count. If you win with a joker activated, it will reset your winning streak.

When you have no more defeats remaining, your game should close automatically (in this code, the process that gets killed is "BrawlhallaGame")
