#include <iostream>
#include <cmath>
#include <stack>

#define S 2 // Starting position
#define G 3 // Goal position

typedef class _node
{
public:
   inline _node(int f, int g, int h, int c) :
      f(f), 
      g(g), 
      h(h),
      c(c)
      {};
   
   int f;
   int g;
   int h;
   int c; // checked
} NODE;

typedef struct _coord
{
   int x;
   int y;
} COORD;

NODE* g_board[7][7];

int g_boardData[7][7] =
{
   {0, 0, 0, 0, 0, 0, 0},
   {0, 0, 0, 0, 0, 0, 0},
   {0, 0, 0, 1, 0, 0, 0},
   {0, S, 0, 1, 0, G, 0},
   {0, 0, 0, 1, 0, 0, 0},
   {0, 0, 0, 0, 0, 0, 0},
   {0, 0, 0, 0, 0, 0, 0},
};

const COORD g_begin{1, 3};
const COORD g_end{5, 3};
      COORD g_current = g_begin;

std::stack<COORD> g_coordHistory;

void PrintMapdata();
void Search();

int main()
{


   for (float y = 0; y < 7; ++y)
   {
      for (float x = 0; x < 7; ++x)
      {
         int g = sqrt(pow(abs(x - g_begin.x) * 10.0f, 2) + pow(abs(y - g_begin.y) * 10.0f, 2));
         int h = abs(x - g_end.x) * 10.0f + abs(y - g_end.y) * 10.0f;
         int f = g + h;

         g_board[(int)y][(int)x] =
            new NODE(f, g, h,
                     g_boardData[(int)y][(int)x] == 1 ? 1 : 0);
      }
   }

   // PrintMapdata();

   Search();

   for (int y = 0; y < 7; ++y)
   {
      for (int x = 0; x < 7; ++x)
      {
         delete g_board[y][x];
      }
   }

   return (0);
}

void Search()
{
   
}

void PrintMapdata()
{
   for (int y = 0; y < 7; ++y)
   {
      for (int x = 0; x < 7; ++x)
      {
         printf("G: %02d ,H: %02d ,F: %03d\t", g_board[y][x]->g, g_board[y][x]->h, g_board[y][x]->f);
      }
      printf("\r\n");
   }
}