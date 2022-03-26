#include "./character.h"

character::character(int hp, int atk,
                     double atkDistance,
                     bool active) :
         _hp(hp),
         _atk(atk),
         _atkDistance(atkDistance),
         _active(active)
{
   _dead = false;
}

void character::Damage(int damage)
{
   _hp -= damage;
   if(_hp <= 0)
      Dead();
}

void character::Dead()
{
   _dead = true;
   _active = false;
}
