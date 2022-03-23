#include "./Conway/conway.h"
#include <iostream>

int main()
{
   Conway* conway = new Conway(5);
   std::cout << conway->AddUnit(3, 2) << std::endl;
   std::cout << conway->AddUnit(2, 2) << std::endl;
   std::cout << conway->AddUnit(1, 2) << std::endl;

   std::cout << conway->GetNearUnitCount(2, 2) << std::endl;

   std::cout << std::endl;

   conway->Print('O');

   delete conway;
}