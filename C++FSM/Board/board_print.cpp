#include "board.h"

void* Board::PrintThreadHelper(void *context)
{
   return ((Board *)context)->PrintThread();
}

void* Board::PrintThread()
{
   while(true)
   {
      if (CheckThreadRunStatus())
         break;
   
      if(Redraw())
      {
         clear();
         PrintBoard();
         refresh(); // FIXME: 이상한 쓰래기 문자 가끔 출력됨
      }

   }

   return 0;
}

void Board::PrintBoard()
{
   mvprintw(_player->y, _player->x, "a");
   mvprintw(_enemy->y, _enemy->x, "o");
}