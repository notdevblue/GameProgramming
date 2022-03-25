#include "./board.h"
#include <cstring>

Board::Board(int x, int y)
{
   _unitmap.insert(std::make_pair("PLAYER", new COORD(x, y)));
}

Board::~Board()
{
   for (auto& [key, value] : _unitmap)
   {
      delete value;
   }
}


void Board::AddEnemy(int x, int y)
{
   std::string key = "ENEMY" + std::to_string(_enemyCount);
   _unitmap.insert(std::make_pair(key, new COORD(x, y)));
}