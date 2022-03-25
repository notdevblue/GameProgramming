#include "./board.h"
#include <iostream>
#include <cstring>
#include <cmath>

Board::Board(int x, int y, int enemyX, int enemyY)
{
   _player = new COORD(x / 2, y / 2);
   _enemy = new COORD(enemyX, enemyY);

   _unitmap.insert(std::make_pair("PLAYER", _player));
   _unitmap.insert(std::make_pair("ENEMY", _enemy));

   pthread_create(&_inputThread, NULL, &Board::InputThreadHelper, this);
}

Board::~Board()
{
   pthread_join(_inputThread, NULL);

   delete _player;
   delete _enemy;
}

double Board::DistanceWithPlayer()
{
   int x = _player->x - _enemy->x;
   int y = _player->y - _enemy->y;

   return std::sqrt(x * x + y * y);
}