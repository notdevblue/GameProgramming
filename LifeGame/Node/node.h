#pragma once

class Node
{
   public:
      Node(int x, int y);
      ~Node();

      void Life();

   private:
      int _x; // 자기 위치 (x)
      int _y; // 자기 위치 (y)
};