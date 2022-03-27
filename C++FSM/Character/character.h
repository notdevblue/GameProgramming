#pragma once
#include "../Coord/coord.h"

typedef class character
{
public:
   character(int hp, int atk,
             double atkDistance, COORD* coord,
             bool active = true);

   // 요약
   //    데미지를 처리합니다.
   void Damage(int damage);

   // 요약
   //    데미지를 가합니다.
   void Attack(character *target);

   // 요약
   //    다른 Character 와 거리를 확인합니다.
   //
   // 반환
   //    다른 Character 와의 거리 (부호 없음)
   double Distance(character target);

   void Move(int x, int y);

   int      _hp;
   int      _atk;
   bool     _dead;
   double   _atkDistance;
   bool     _active;
   COORD*   _coord;

private:
   // 요약
   //    사망을 처리합니다.
   void Dead();

} CHARACTER;