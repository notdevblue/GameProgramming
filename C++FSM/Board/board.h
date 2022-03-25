#pragma once

#include <map>
#include <string>
#include "../coord.h"

class Board
{
public:
   Board(int x, int y);
   ~Board();

   // 요약
   //    적을 넘겨진 좌표애 추가합니다.
   void AddEnemy(int x, int y);

   // 요약
   //    플레이어와 거리를 확인합니다.
   //
   // 반환
   //    플레이어와의 거리 (부호 없음)
   float DistanceWithPlayer();

private:

   std::map<std::string, COORD*> _unitmap;
   int _enemyCount = 0; // 적 아이디 용
};