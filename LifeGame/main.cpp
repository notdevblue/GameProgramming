#include "./Conway/conway.h"
#include <iostream>

int main()
{
   Conway* conway = new Conway(11, 12);

   conway->AddUnit(4, 5);
   conway->AddUnit(5, 5);
   conway->AddUnit(6, 5);
   conway->AddUnit(5, 5);
   conway->AddUnit(5, 4);
   conway->AddUnit(5, 6);


   while ((!conway->CheckIsAllDead()) && (!conway->TurnLimit()))
   {
      system("sleep 0.2; clear");
      conway->Print('0', '-');
      conway->Turn();
   }


   delete conway;
}