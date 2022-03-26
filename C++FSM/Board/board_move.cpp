#include "./board.h"

void *Board::InputThreadHelper(void *context)
{
   return ((Board *)context)->InputThread();
}

void *Board::InputThread()
{
   int input;

   while(true)
   {
      if (CheckThreadRunStatus())
         break;

      input = getch(); // blocking
      ProcessInput(input);
   }

   return 0;
}

void Board::Move(COORD *unit, int x, int y)
{
   unit->x = x;
   unit->y = y;
}

void Board::ProcessInput(int input)
{
   switch(input)
   {
   case KEY_UP:
      break;
   case KEY_DOWN:
      break;
   case KEY_LEFT:
      break;
   case KEY_RIGHT:
      break;

   case 'q':
      pthread_mutex_lock(&_mutex);
      _stopThread = true;
      pthread_mutex_unlock(&_mutex);
      break;
   
   default:
      break;
   }
}