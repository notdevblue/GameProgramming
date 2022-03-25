#include "./Board/board.h"
#include <iostream>

int main()
{
   Board *board = new Board(10, 10, 4, 4);
   std::cout << board->DistanceWithPlayer() << std::endl;

   delete board;
   return (0);
}