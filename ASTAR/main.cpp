#include <iostream>
#include <cmath>

#define S 2 // Starting position
#define G 3 // Goal position

typedef class node
{
public:
   inline node(int f, int g, int h, int d) :
      f(f), 
      g(g), 
      h(h), 
      d(d),
      c(0)
      {};
   
   int f;
   int g;
   int h;
   int d; // data
   int c; // checked
} NODE;

NODE* board[7][7];

int boardData[7][7] =
{
   {0, 0, 0, 0, 0, 0, 0},
   {0, 0, 0, 0, 0, 0, 0},
   {0, 0, 0, 1, 0, 0, 0},
   {0, S, 0, 1, 0, G, 0},
   {0, 0, 0, 1, 0, 0, 0},
   {0, 0, 0, 0, 0, 0, 0},
   {0, 0, 0, 0, 0, 0, 0},
};

int main()
{
   int startPosX = 1;
   int startPosY = 3;

   int goalPosX = 5;
   int goalPosY = 3;

   for (int y = 0; y < 7; ++y)
   {
      for (int x = 0; x < 7; ++x)
      {
         int g = sqrt(pow((x - startPosX), 2) + pow((y - startPosY), 2));
         int h = sqrt(pow((x - goalPosX), 2) + pow((y - goalPosY), 2));
         int f = g + h;

         board[y][x] = new NODE(f, g, h, boardData[y][x]);
      }
   }

   

   for (int y = 0; y < 7; ++y)
   {
      for (int x = 0; x < 7; ++x)
      {
         delete board[y][x];
      }
   }

   return (0);
}