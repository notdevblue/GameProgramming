#include "./conway.h"
#include <cmath>

Conway::Conway(int area) : _length(sqrt(area))
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

int Conway::GetNearUnitCount(const int& x, const int& y)
{
   int unitcount  = 0; // 주변에 있는 유닛 수
   int cachedX    = x;
   int cachedY    = y;

   for (--cachedY; cachedY < y + 1; ++cachedY)
   {
      for (--cachedX; cachedX < x + 1; ++cachedX)
      {
         if(GetClampedBoardInfo(cachedX, cachedY))
            ++unitcount;
      }
   }

   return unitcount - 1; // 자기 자신 제외
}

bool Conway::GetClampedBoardInfo(int x, int y)
{
   int arrLength = _length - 1;

   x = x % (arrLength);
   y = y % (arrLength);

   if(x < 0)
      x = arrLength;
   if(y < 0)
      y = arrLength;

   return _board[y][x];
}

bool Conway::AddUnit(const int& x, const int& y)
{
   if (_board[y][x])
      return false;
   
   _board[y][x] = true;
   return true;
}