#pragma once

typedef class character
{
public:
   character(int hp, int atk,
             double atkDistance,
             bool active = true);

   // 요약
   //    데미지를 처리합니다.
   void Damage(int damage);


   int      _hp;
   int      _atk;
   bool     _dead;
   double   _atkDistance;

   bool _active;

private:
   // 요약
   //    사망을 처리합니다.
   void Dead();

} CHARACTER;