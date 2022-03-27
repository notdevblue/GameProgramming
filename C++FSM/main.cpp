#include "./Board/board.h"

int main()
{
   Board *board = new Board(10, 10, 4, 4);

   board->WaitAllThreads();

   delete board;
   return (0);
}