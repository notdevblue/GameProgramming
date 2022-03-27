#include "./enemy.h"

Enemy::Enemy(int hp, int atk,
             double atkDistance, COORD* coord) :
             character(hp, atk, atkDistance, coord)
{
   pthread_create(&_fsmThread, NULL, &Enemy::FSMThreadHelper, this);
}

Enemy::~Enemy()
{

}

void Enemy::WaitAllThreads()
{
   pthread_join(_fsmThread, NULL);
}

void *Enemy::FSMThreadHelper(void *context)
{
   return ((Enemy *)context)->FSMThread();
}

void *Enemy::FSMThread()
{
   while(true)
   {
      if(CheckDead()) break;


   }

   return 0;
}



bool Enemy::CheckDead()
{
   bool result;
   pthread_mutex_lock(&_mutex);
   result = _dead;
   pthread_mutex_unlock(&_mutex);
   return result;
}
