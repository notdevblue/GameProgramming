#include "./character.h"
#include <cmath>

character::character(int hp, int atk,
                     double atkDistance, COORD* coord,
                     bool active) :
         _hp(hp),
         _atk(atk),
         _atkDistance(atkDistance),
         _active(active),
         _coord(coord)
{
   _dead = false;
}

void character::Damage(int damage)
{
   _hp -= damage;
   if(_hp <= 0)
      Dead();
}

void character::Attack(character *target)
{
   target->Damage(_atk);
}

double CHARACTER::Distance(CHARACTER target)
{
   int x = _coord->x - target._coord->x;
   int y = _coord->y - target._coord->y;

   return std::sqrt(x * x + y * y);
}

void character::Dead()
{
   _dead = true;
   _active = false;
}
