#pragma once

#include <string>;


class DefeatManager
{
public:
	DefeatManager(int nbPlayers, int maxDefeat);
	bool isGameOver();
	bool useJoker();
	int getNbJokers();
	int getRemainingLoses();
	void addWin();
	void addLose();
	void resetWinStreak();

private:

	int nbJokers;
	int maxDefeat;
	int nbDefeat;
	bool isInWinStreak;
	bool isUsingJoker;
	
};


