#pragma once

#include <map>
#include <string>
#include <pthread.h>
#include "../Coord/coord.h"

class Board
{
public:
   Board(int x, int y, int enemyX, int enemyY);
   ~Board();

   // 요약
   //    플레이어와 거리를 확인합니다.
   //
   // 반환
   //    플레이어와의 거리 (부호 없음)
   double DistanceWithPlayer();

private:
#pragma region Thread
   static void *InputThreadHelper(void *context);
   void *InputThread();
#pragma endregion

   std::map<std::string, COORD*> _unitmap;
   int _enemyCount = 0; // 적 아이디 용

   pthread_t _inputThread;

   COORD *_player;
   COORD *_enemy;
};