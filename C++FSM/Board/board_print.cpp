#include "board.h"

void* Board::PrintThreadHelper(void *context)
{
   return ((Board *)context)->PrintThread();
}

void* Board::PrintThread()
{
   float framerate = 1.0f / 60.0f;
   const char *sleep =
       ("sleep " + std::to_string(framerate)).c_str();

   while (true)
   {
      if (CheckThreadRunStatus())
         break;

      system(sleep);

      clear();
      PrintBoard();
      refresh(); // FIXME: 이상한 쓰래기 문자 가끔 출력됨
   

   }

   return 0;
}

void Board::PrintBoard()
{
   if(_playerData->_active)
      mvprintw(_player->y, _player->x, "a");

   if(_enemyData->_active)
      mvprintw(_enemy->y, _enemy->x, "o");
}