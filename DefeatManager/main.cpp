#include <iostream>
#include <string>
#include "DefeatManager.h"

DefeatManager * defeatManager;

enum GameResult { VICTORY, DEFEAT };

void getInitNumbers(int& nbPlayers, int& maxDefeat) {

	std::cout << "Combien de joueurs ?\n";
	std::cin >> nbPlayers;
	std::cout << "Combien de defaites max ?\n";
	std::cin >> maxDefeat;
}

void displayGameInfo() {
	std::cout << "Nombre de jokers restants : " << defeatManager->getNbJokers() << "\n";
	std::cout << "Nombre de defaites restantes : " << defeatManager->getRemainingLoses() << "\n\n";
}

bool wantToUseJoker() {
	std::string useJoker;
	std::cout << "\nUtiliser joker ? (o/n)\n";
	std::cin >> useJoker;

	return (useJoker == "o");
}

GameResult askForGameResult() {
	std::string result;
	std::cout << "\nResultat de la game ? (v/d) \n";
	std::cin >> result;

	if (result == "v")
		return VICTORY;
	else
		return DEFEAT;
}

bool hasRematched() {
	std::string rematchAnswer;
	std::cout << "\nRematch ? (o/n)";
	std::cin >> rematchAnswer;
	
	return (rematchAnswer == "o");
}

int main() {

	int nbPlayers, maxDefeat;
	getInitNumbers(nbPlayers, maxDefeat);
	
	defeatManager = new DefeatManager(nbPlayers, maxDefeat);

	system("cls");
	std::cout << "Ca commence, good luck !\n\n";

	while (defeatManager->isGameOver() == false) {

		displayGameInfo();

		if (wantToUseJoker()) {

			if (defeatManager->useJoker() == false) {
				std::cout << "Plus de jokers disponibles !\n\n";
			}
		}

		if (askForGameResult() == VICTORY) {
			defeatManager->addWin();
		}
		else {
			if (hasRematched() && (askForGameResult() == VICTORY)) {
				defeatManager->resetWinStreak();
			}
			else {
				defeatManager->addLose();
			}
		}

		system("cls");
	}

	return 0;
}


