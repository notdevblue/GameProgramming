#pragma once
#include "character.h"
#include <pthread.h>

typedef class Enemy : public CHARACTER
{
public:
   Enemy(int hp, int atk, double atkDistance, COORD* coord);
   ~Enemy();

   // 요약
   //    모든 스레드가 join 하기 전 까지 block 합니다.
   void WaitAllThreads();

private:
   static void *FSMThreadHelper(void *context);

   // 요약
   //    FSM 을 연산하는 함수 (Thread)
   void *FSMThread();

#pragma region States

   // 요약
   //    랜덤하게 맵을 돌아다니면서 플레이어를 탐색합니다.
   void Patrol();
   
   // 부모에서 구현됨
   // void Dead();

   // 요약
   //    플레이어에게서 도망칩니다.
   void Runaway();

   // 요약
   //    플레이어를 공격합니다.
   void Attack();

   // 요약
   //    아무것도 하지 않습니다.
   void Idle();

#pragma endregion // States

   // 요약
   //    사망했는지 확인합니다.
   //
   // 반환
   //    사망 시 true
   bool CheckDead();



   pthread_t _fsmThread;
   pthread_mutex_t _mutex;
} ENEMY;