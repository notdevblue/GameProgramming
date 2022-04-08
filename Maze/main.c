#include <stdio.h>
#include <stdlib.h>

int g_maze[8][8] =
{
   {0, 0, 0, 0, 0, 0, 0, 0},
   {1, 1, 0, 1, 1, 1, 1, 0},
   {1, 1, 0, 1, 1, 1, 1, 0},
   {1, 1, 0, 1, 1, 1, 1, 0},
   {1, 1, 0, 0, 1, 1, 1, 0},
   {1, 1, 1, 0, 0, 0, 0, 0},
   {1, 1, 1, 0, 1, 1, 1, 1},
   {1, 0, 0, 0, 0, 0, 0, 3}
};

int g_visited[8][8];

int g_dx[4] = {0, 0, 1, -1};
int g_dy[4] = {1, -1, 0, 0};

// int g_dx[4] = {1, 0, 0, -1};
// int g_dy[4] = {0, 1, -1, 0};

int g_x = 0;
int g_y = 0;

void search();
void print();

int main()
{
   search();

   return (0);
}

void search()
{
   int x = g_x;
   int y = g_y;

   while (1)
   {
      for (int i = 0; i < 4; ++i)
      {
         x = g_x + g_dx[i];
         y = g_y + g_dy[i];

         if ((g_visited[y][x]) || (x > 7 || x < 0 || y > 7 || y < 0))
            continue;  

         if (g_maze[y][x] == 3)
         {
            g_x = x;
            g_y = y;
            print();
            return;
         }

         if (!g_maze[y][x])
         {
            g_visited[y][x] = 1;
            g_x = x;
            g_y = y;
            break;
         }
      }

      print();

      system("sleep 0.1; clear");
   }
}


void print()
{
   for (int y = 0; y < 8; ++y)
   {
      for (int x = 0; x < 8; ++x)
      {
         if (g_x == x && g_y == y)
            printf("x");
         else
            printf("%c", g_maze[y][x] ? (g_maze[y][x] == 3 ? '$' : '@') : ' ');
      }
      printf("\r\n");
   }
}