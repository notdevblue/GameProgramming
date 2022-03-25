#include "./board.h"

void *Board::InputThreadHelper(void *context)
{
   return ((Board *)context)->InputThread();
}

void *Board::InputThread()
{
   
}