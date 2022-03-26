#include "board.h"

void* Board::PrintThreadHelper(void *context)
{
   return ((Board *)context)->InputThread();
}

void* Board::PrintThread()
{
   while(true)
   {
      if (CheckThreadRunStatus())
         break;

      clear();
      refresh();
   }

   return 0;
}

void Board::PrintBoard()
{
   
}