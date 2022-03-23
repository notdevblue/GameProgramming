#include "./conway.h"
#include <cmath>
#include <iostream>

Conway::Conway(const int length) : _length(length)
{
   _board = new bool*[_length];

   for (int i = 0; i < _length; ++i)
   {
      _board[i] = new bool[_length];
   }
}

Conway::~Conway()
{
   for (int i = 0; i < _length; ++i)
   {
      delete[] _board[i];
   }

   delete[] _board;
}

int Conway::GetNearUnitCount(const int x, const int y)
{
   int unitcount  = 0; // 주변에 있는 유닛 수
   int cachedX    = x - 1;
   int cachedY    = y - 1;

   for (cachedY; cachedY <= y + 1; ++cachedY)
   {
      for (cachedX; cachedX <= x + 1; ++cachedX)
      {
         if(GetClampedBoardInfo(cachedY, cachedX))
            ++unitcount;
      }

      cachedX = x - 1;
   }

   return unitcount - 1; // 자기 자신 제외
}

bool Conway::GetClampedBoardInfo(int y, int x)
{
   int arrLength = _length - 1;

   y = y % (arrLength);
   x = x % (arrLength);

   if(y < 0)
      y = arrLength;
   if(x < 0)
      x = arrLength;

   return _board[x][y];
}

bool Conway::AddUnit(const int x, const int y)
{
   if (_board[y][x])
      return false;
   
   _board[y][x] = true;
   return true;
}

void Conway::Print(char node)
{
   for (int y = 0; y < _length; ++y)
   {
      for (int x = 0; x < _length; ++x)
      {
         std::cout << (_board[y][x] ? node : ' ');
      }
      std::cout << std::endl;
   }
}