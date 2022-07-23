#include "DefeatManager.h"

DefeatManager::DefeatManager(int nbPlayers, int maxDefeat) {
	this->nbJokers = nbPlayers;
	this->maxDefeat = maxDefeat;
	this->nbDefeat = 0;
	this->isInWinStreak = false;
	this->isUsingJoker = false;
}

bool DefeatManager::isGameOver() {
	return (this->maxDefeat <= this->nbDefeat);
}

bool DefeatManager::useJoker() {
	
	if (this->nbJokers > 0) {
		this->isInWinStreak = false;
		this->nbJokers--;
		this->isUsingJoker = true;

		return true;
	}

	return false;
}

int DefeatManager::getNbJokers() {
	return this->nbJokers;
}

int DefeatManager::getRemainingLoses() {
	return this->maxDefeat - this->nbDefeat;
}
void DefeatManager::addWin() {
	if (this->isInWinStreak) {

		this->isInWinStreak = false;

		if (this->nbDefeat > 0) {
			this->nbDefeat--;
		}
	}
	else
		this->isInWinStreak = true;
}

void DefeatManager::addLose() {
	if (this->isUsingJoker == false) {

		this->isInWinStreak = false;
		this->nbDefeat++;
	}
	this->isUsingJoker = false;
}

void DefeatManager::resetWinStreak() {
	this->isInWinStreak = false;
}
