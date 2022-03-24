#include "./conway.h"

#include <cmath>
#include <iostream>

Conway::Conway(const int length, const int turn) :
      _length(length),
      _turn(turn),
      _curTurn(0)
{
   _board = new bool *[_length];

   for (int i = 0; i < _length; ++i)
   {
      _board[i] = new bool[_length];
   }

   ForEach([](bool* node, int x, int y)
   {
      *node = false;
   });
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
         if(GetClampedBoardInfo(cachedX, cachedY))
            ++unitcount;
      }

      cachedX = x - 1;
   }
   
   return _board[y][x] ? unitcount - 1 : unitcount; // 자기 자신 제외
}

bool Conway::GetClampedBoardInfo(int x, int y)
{
   x = x % _length;
   y = y % _length;

   if(x < 0)
      x = _length - 1;
   if (y < 0)
      y = _length - 1;

   return _board[y][x];
}

bool Conway::CheckIsAllDead()
{
   bool result = true;
   ForEach([&](bool* node, int x, int y)
   {
      if(*node)
         result = false;
   });

   return result;
}

bool Conway::TurnLimit()
{
   return _curTurn > _turn;
}

void Conway::AddUnit(const int x, const int y)
{
   _board[y][x] = true;
}

void Conway::Turn()
{
   bool **board = Copy();
   ++_curTurn;

   auto check = [&](bool *status, int x, int y)
   {
      int count = GetNearUnitCount(x, y);

      switch (*status)
      {
      case true: // 노드가 있음
         if (count == 2 || count == 3)
         {
            board[y][x] = true;
         }
         else
         {
            board[y][x] = false;
         }
         break;
      case false: // 노드가 없음
         if (count == 3)
         {
            board[y][x] = true;
         }
         else
         {
            board[y][x] = false;
         }
         break;
      }
   };

   ForEach(check);

   Override(board);
   DeleteCopied(board);
}

void Conway::Print(char node, char empty)
{
   auto callback = [&](bool* status, int x, int y)
   {
      std::cout << (*status ? node : empty);
   };

   auto newLine = []()
   {
      std::cout << "\r\n";
   };

   ForEach(callback, newLine);
}

void Conway::ForEach(std::function<void(bool* node, int x, int y)> callback,
                     std::function<void()> eol)
{
   for (int y = 0; y < _length; ++y)
   {
      for (int x = 0; x < _length; ++x)
      {
         callback(&_board[y][x], x, y);
      }

      if(eol != NULL)
         eol();
   }
}

bool** Conway::Copy()
{
   bool **board = new bool *[_length];

   for (int i = 0; i < _length; ++i)
   {
      board[i] = new bool[_length];
   }

   return board;
}

void Conway::Override(bool** copied)
{
   ForEach([&](bool *node, int x, int y)
   {
      *node = copied[y][x];
   });
}

void Conway::DeleteCopied(bool **copied)
{
   for (int i = 0; i < _length; ++i)
   {
      delete[] copied[i];
   }

   delete[] copied;
}