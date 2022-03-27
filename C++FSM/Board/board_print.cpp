#include "./board.h"

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
      refresh();
   

   }

   return 0;
}

void Board::PrintBoard()
{
   if(_playerData->_active)
      mvprintw(_playerData->_coord->y, // seg fault
               _playerData->_coord->x, "a");

   if(_enemyData->_active)
      mvprintw(_enemyData->_coord->y,
               _enemyData->_coord->x, "o");
}