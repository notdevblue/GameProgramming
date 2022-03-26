#pragma once

#include <map>
#include <string>
#include <pthread.h>
#include <ncurses.h>
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

   // 요약
   //    유닛을 이동시킵니다.
   void Move(COORD *unit, int x, int y);

   // 요약
   //    모든 스레드가 join 하기 전 까지 block 합니다.
   void WaitAllThreads();

private:

#pragma region Move
   static void *InputThreadHelper(void *context);

   // 요약
   //    입력을 담당하는 Thread
   void *InputThread();

   // 요약
   //    입력받은 input 을 처리합니다.
   void ProcessInput(int input);

   pthread_t _inputThread;
#pragma endregion // Move

#pragma region Print
   static void *PrintThreadHelper(void *context);

   // 요약
   //    화면 출력을 담당하는 Thread
   void *PrintThread();

   // 요약
   //    보드를 화면에 출력합니다.
   void PrintBoard();

   pthread_t _printThread;
#pragma endregion

   // 요약
   //    스레드를 계속 돌릴지 판단합니다.
   //
   // 반환
   //    스레드를 중지시켜야 하면 true
   bool CheckThreadRunStatus();

   std::map<std::string, COORD*> _unitmap;
   int _enemyCount = 0; // 적 아이디 용

   pthread_mutex_t _mutex;
   bool _stopThread; // true 인 경우 스레드를 멈춤

   COORD *_player;
   COORD *_enemy;
   COORD *_screen; // 화면 크기

   WINDOW *w;
};